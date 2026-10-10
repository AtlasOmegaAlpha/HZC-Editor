using Horizon;
using HZC_Editor.Converter;
using System.Diagnostics;
using System.Reflection;

namespace HZC_Editor
{
    public partial class Form1 : Form
    {
        const string HZC_FILTER = "HZC files (*.hzc)|*.hzc|All files (*.*)|*.*";

        private string filePath = "";
        private HZC? loadedHzc = null;
        private bool isDirty = false;

        public Form1()
        {
            InitializeComponent();
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string dirtyMark = this.isDirty ? "* " : "";
            this.Text = fvi.ProductName + " v" + fvi.FileVersion + (string.IsNullOrWhiteSpace(this.filePath) ? "" : $" - {dirtyMark}{this.filePath}");
        }

        private void MarkDirty()
        {
            this.isDirty = true;
            UpdateTitle();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void NewFile()
        {
            if (!ConfirmDiscard())
                return;

            ClearState();
            HZC hzc = new HZC();
            hzc.RebuildGrid();
            SetHZC(hzc, "");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void OpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = HZC_FILTER
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                OpenFile(ofd.FileName);
        }

        public void OpenFile(string fileName)
        {
            ClearState();
            EndianReader reader = new EndianReader(new MemoryStream(File.ReadAllBytes(fileName)), Endianness.LittleEndian);
            HZC hzc = new HZC();
            hzc.Read(reader);
            reader.Close();
            SetHZC(hzc, fileName);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.isDirty && !ConfirmDiscard())
                return;

            ClearState();
        }

        private bool ConfirmDiscard()
        {
            if (!this.isDirty)
                return true;

            DialogResult result = MessageBox.Show("There are unsaved changes. Discard them?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        private void ClearState()
        {
            this.treeView1.Nodes[0].ContextMenuStrip = null;
            foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
            {
                node.Nodes.Clear();
            }

            this.propertyGrid1.SelectedObject = null;
            UpdateButtons(false);
            this.loadedHzc = null;
            this.filePath = "";
            this.isDirty = false;
            UpdateTitle();
        }

        private void UpdateButtons(bool enabled)
        {
            this.treeView1.Enabled = enabled;
            this.closeToolStripMenuItem.Enabled = enabled;
            this.saveToolStripMenuItem.Enabled = enabled;
            this.saveAsToolStripMenuItem.Enabled = enabled;
            this.viewerToolStripMenuItem.Enabled = enabled;
            this.importOBJToolStripMenuItem.Enabled = enabled;
            this.exportOBJToolStripMenuItem.Enabled = enabled;
            this.saveToolStripButton.Enabled = enabled;
            this.saveAsToolStripButton.Enabled = enabled;
            this.viewerToolStripButton.Enabled = enabled;
            this.importObjToolStripButton.Enabled = enabled;
            this.exportObjToolStripButton.Enabled = enabled;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(this.filePath);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save(this.filePath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = HZC_FILTER,
                FileName = Path.GetFileName(this.filePath),
            };

            if (sfd.ShowDialog() == DialogResult.OK)
                Save(sfd.FileName);
        }

        private void Save(string path)
        {
            if (this.loadedHzc == null)
                return;

            if (string.IsNullOrWhiteSpace(path))
            {
                SaveAs();
                return;
            }

            try
            {
                using MemoryStream ms = new MemoryStream();
                using EndianWriter writer = new EndianWriter(ms, Endianness.LittleEndian);
                this.loadedHzc.Write(writer);
                File.WriteAllBytes(path, ms.ToArray());

                this.filePath = path;
                this.isDirty = false;
                UpdateTitle();
                MessageBox.Show("File saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetHZC(HZC hzc, string fileName)
        {
            if (hzc == null)
                return;

            this.loadedHzc = hzc;
            PopulateTree();

            this.isDirty = false;
            this.treeView1.SelectedNode = this.treeView1.Nodes[0];
            this.filePath = fileName;
            this.propertyGrid1.SelectedObject = this.loadedHzc;
            UpdateButtons(true);
            UpdateTitle();
        }

        private void PopulateTree()
        {
            this.treeView1.BeginUpdate();
            foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
            {
                node.Nodes.Clear();
            }

            if (this.loadedHzc == null)
            {
                this.treeView1.EndUpdate();
                return;
            }

            this.treeView1.Nodes[0].Tag = "Header";
            this.treeView1.Nodes[0].Nodes[0].Tag = "VerticesRoot";
            for (int i = 0; i < this.loadedHzc.Vertices.Count; i++)
            {
                this.treeView1.Nodes[0].Nodes[0].Nodes.Add(new TreeNode($"Vertex {i}") { Tag = "Vertex", ImageKey = "draw_vertex.png", SelectedImageKey = "draw_vertex.png" });
            }

            this.treeView1.Nodes[0].Nodes[1].Tag = "TrianglesRoot";
            this.treeView1.Nodes[0].Nodes[1].ContextMenuStrip = this.triangleContextMenuStrip;
            for (int i = 0; i < this.loadedHzc.Triangles.Count; i++)
            {
                this.treeView1.Nodes[0].Nodes[1].Nodes.Add(new TreeNode($"Triangle {i}") { Tag = "Triangle", ImageKey = "draw_triangle.png", SelectedImageKey = "draw_triangle.png", ContextMenuStrip = this.triangleContextMenuStrip });
            }

            this.treeView1.Nodes[0].Nodes[2].Tag = "Grid";
            this.treeView1.Nodes[0].Nodes[2].ContextMenuStrip = this.gridContextMenuStrip;
            this.treeView1.Nodes[0].Nodes[3].Tag = "AttributesRoot";
            this.treeView1.Nodes[0].Nodes[3].ContextMenuStrip = this.attributesRootContextMenuStrip;
            for (int i = 0; i < this.loadedHzc.Attributes.Count; i++)
            {
                this.treeView1.Nodes[0].Nodes[3].Nodes.Add(new TreeNode(this.loadedHzc.Attributes[i].Key) { Tag = "Attribute", ImageKey = "molecule.png", SelectedImageKey = "molecule.png", ContextMenuStrip = this.attributesRootContextMenuStrip });
            }

            this.treeView1.Nodes[0].Expand();
            this.treeView1.EndUpdate();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0 && ConfirmDiscard())
                OpenFile(files[0]);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmDiscard())
                e.Cancel = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.loadedHzc == null || e.Node == null)
                return;

            switch ((string)e.Node.Tag)
            {
                case "Header":
                    this.propertyGrid1.SelectedObject = this.loadedHzc;
                    break;

                case "VerticesRoot":
                    this.propertyGrid1.SelectedObject = new CountProperty<VertexS32>(this.loadedHzc.Vertices);
                    break;

                case "Vertex":
                    this.propertyGrid1.SelectedObject = this.loadedHzc.Vertices[e.Node.Index];
                    break;

                case "TrianglesRoot":
                    this.propertyGrid1.SelectedObject = new CountProperty<ColTriangle>(this.loadedHzc.Triangles);
                    break;

                case "Triangle":
                    this.propertyGrid1.SelectedObject = this.loadedHzc.Triangles[e.Node.Index];
                    break;

                case "Grid":
                    this.propertyGrid1.SelectedObject = this.loadedHzc.Grid;
                    break;

                case "AttributesRoot":
                    this.propertyGrid1.SelectedObject = new CountProperty<ColAttribute>(this.loadedHzc.Attributes);
                    break;

                case "Attribute":
                    this.propertyGrid1.SelectedObject = this.loadedHzc.Attributes[e.Node.Index];
                    break;

                default:
                    this.propertyGrid1.SelectedObject = null;
                    break;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.treeView1.SelectedNode = e.Node;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            MarkDirty();

            if (this.propertyGrid1.SelectedObject is ColAttribute && (this.treeView1.SelectedNode?.Tag as string) == "Attribute")
                this.treeView1.SelectedNode.Text = ((ColAttribute)this.propertyGrid1.SelectedObject).Key;
        }

        private void recomputeNormalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loadedHzc == null)
                return;

            if ((string)this.treeView1.SelectedNode.Tag == "TrianglesRoot")
            {
                foreach (ColTriangle triangle in this.loadedHzc.Triangles)
                {
                    triangle.ComputeNormal(this.loadedHzc);
                }
            }
            else
                this.loadedHzc.Triangles[this.treeView1.SelectedNode.Index].ComputeNormal(this.loadedHzc);

            MarkDirty();
            this.propertyGrid1.Refresh();
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loadedHzc == null)
                return;

            try
            {
                this.loadedHzc.RebuildGrid();
                MarkDirty();
                this.propertyGrid1.Refresh();
                MessageBox.Show($"Rebuild complete: {this.loadedHzc.Grid.OccupiedCells} occupied cells, {this.loadedHzc.Grid.LinkEntries} link entries.", "Grid Rebuilt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when rebuilding the grid:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loadedHzc == null)
                return;

            this.loadedHzc.AddAttribute("NewAttribute", "float(SurfaceType)=0.000000");
            MarkDirty();
            PopulateTree();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loadedHzc == null)
                return;

            int index = this.treeView1.SelectedNode.Index;
            ColAttribute attribute = this.loadedHzc.Attributes[index];
            this.loadedHzc.RemoveAttribute(index);
            MarkDirty();
            this.propertyGrid1.SelectedObject = null;
            PopulateTree();
        }

        private void importOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportOBJ();
        }

        private void importObjToolStripButton_Click(object sender, EventArgs e)
        {
            ImportOBJ();
        }

        private void ImportOBJ()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            List<ColAttribute> existingAttributes = this.loadedHzc?.Attributes ?? new List<ColAttribute>();
            ImportObjForm form = new ImportObjForm(existingAttributes, ofd.FileName);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                HZC hzc = ObjToHzc.Convert(form.Result!);
                SetHZC(hzc, this.filePath);
                MarkDirty();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Import failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportObjToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.loadedHzc == null)
                return;

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*",
                FileName = this.filePath != null ? Path.ChangeExtension(Path.GetFileName(this.filePath), ".obj") : "export.obj",
            };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ObjExporter.Export(this.loadedHzc, sfd.FileName);
                MessageBox.Show($"OBJ exported to {sfd.FileName}", "OBJ Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void versionInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog();
        }

        private void versionInformationToolStripButton_Click(object sender, EventArgs e)
        {
            AboutDialog();
        }

        private void AboutDialog()
        {
            AboutWindow about = new AboutWindow("https://github.com/AtlasOmegaAlpha/HZC-Editor");
            about.ShowDialog();
        }

        private void viewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenViewer();
        }

        private void viewerToolStripButton_Click(object sender, EventArgs e)
        {
            OpenViewer();
        }

        private void OpenViewer()
        {
            if (this.loadedHzc == null)
                return;

            if (!ViewerLauncher.IsAvailable())
            {
                MessageBox.Show($"The HZC Viewer was not found at:\n{ViewerLauncher.GetViewerPath()}\n\nPlease reinstall the program.", "Viewer not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ViewerLauncher.Launch(this.loadedHzc, this.filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the viewer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
