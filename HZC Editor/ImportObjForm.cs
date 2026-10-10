using Horizon;
using HZC_Editor.Converter;

namespace HZC_Editor
{
    public partial class ImportObjForm : Form
    {
        public ObjImportConfig? Result { get; private set; }
        private readonly List<ColAttribute> existingAttributes;
        private ObjMesh? mesh;

        public ImportObjForm(List<ColAttribute> existingAttributes, string? filePath = null)
        {
            this.existingAttributes = existingAttributes;
            InitializeComponent();

            this.keepExistingAttributesCheckBox.Checked = this.existingAttributes.Count > 0;
            this.keepExistingAttributesCheckBox.Enabled = this.existingAttributes.Count > 0;

            if (!string.IsNullOrEmpty(filePath))
                LoadObj(filePath);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
                LoadObj(ofd.FileName);
        }

        private void LoadObj(string filePath)
        {
            try
            {
                this.mesh = ObjImporter.Load(filePath);
                this.objPathTextBox.Text = filePath;
                this.autoDetectButton.Enabled = true;
                RefreshGroupsGrid();

                Dictionary<int, string?> assignedAttributes = AttributeAssign.GetAttributes(this.mesh, this.keepExistingAttributesCheckBox.Checked ? this.existingAttributes : new List<ColAttribute>());
                ApplyDetection(assignedAttributes);

                if (this.mesh.warnings.Count > 0)
                    MessageBox.Show(string.Join("\n", this.mesh.warnings.Take(20)), "Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load OBJ:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGroupsGrid()
        {
            this.groupsDataGridView.Rows.Clear();
            if (this.mesh == null)
                return;

            foreach (ObjGroup group in this.mesh.groups)
            {
                this.groupsDataGridView.Rows.Add(group.name, group.faces.Count.ToString(), "");
            }
        }

        private void autoDetectButton_Click(object sender, EventArgs e)
        {
            if (this.mesh == null)
                return;

            Dictionary<int, string?> assignedAttributes = AttributeAssign.GetAttributes(this.mesh, this.keepExistingAttributesCheckBox.Checked ? this.existingAttributes : new List<ColAttribute>());
            ApplyDetection(assignedAttributes);
        }

        private void ApplyDetection(Dictionary<int, string?> attributes)
        {
            for (int i = 0; i < this.groupsDataGridView.Rows.Count; i++)
            {
                string value = attributes.TryGetValue(i, out string? key) ? (key ?? "") : "";
                this.groupsDataGridView.Rows[i].Cells["AssignTo"].Value = value;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.mesh == null || this.mesh.groups.Count == 0)
            {
                MessageBox.Show("Empty or invalid OBJ file.", "Nothing to import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<GroupAssignment> assignments = new List<GroupAssignment>();
            for (int i = 0; i < this.groupsDataGridView.Rows.Count; i++)
            {
                string? value = this.groupsDataGridView.Rows[i].Cells["AssignTo"].Value?.ToString();
                assignments.Add(new GroupAssignment
                {
                    GroupIndex = i,
                    AttributeKey = string.IsNullOrWhiteSpace(value) ? null : value.Trim()
                });
            }

            this.Result = new ObjImportConfig
            {
                Mesh = this.mesh,
                Assignments = assignments,
                ExistingAttributes = this.keepExistingAttributesCheckBox.Checked ? this.existingAttributes : new List<ColAttribute>(),
                GridX = (int)this.gridXNumericUpDown.Value,
                GridY = (int)this.gridYNumericUpDown.Value,
                GridZ = (int)this.gridZNumericUpDown.Value,
            };

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
