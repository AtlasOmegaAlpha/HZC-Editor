namespace HZC_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode6 = new TreeNode("Vertices");
            TreeNode treeNode7 = new TreeNode("Triangles");
            TreeNode treeNode8 = new TreeNode("Grid");
            TreeNode treeNode9 = new TreeNode("Custom Attributes");
            TreeNode treeNode10 = new TreeNode("HZC", new TreeNode[] { treeNode6, treeNode7, treeNode8, treeNode9 });
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            importOBJToolStripMenuItem = new ToolStripMenuItem();
            exportOBJToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            versionInformationToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            newToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            saveAsToolStripButton = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            viewerToolStripButton = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            importObjToolStripButton = new ToolStripButton();
            exportObjToolStripButton = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            versionInformationToolStripButton = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            imageList1 = new ImageList(components);
            propertyGrid1 = new PropertyGrid();
            triangleContextMenuStrip = new ContextMenuStrip(components);
            recomputeNormalsToolStripMenuItem = new ToolStripMenuItem();
            gridContextMenuStrip = new ContextMenuStrip(components);
            rebuildToolStripMenuItem = new ToolStripMenuItem();
            attributesRootContextMenuStrip = new ContextMenuStrip(components);
            addToolStripMenuItem = new ToolStripMenuItem();
            attributeContextMenuStrip = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            viewerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            triangleContextMenuStrip.SuspendLayout();
            gridContextMenuStrip.SuspendLayout();
            attributesRootContextMenuStrip.SuspendLayout();
            attributeContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripSeparator3, openToolStripMenuItem, closeToolStripMenuItem, toolStripSeparator1, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = Properties.Resources.document_new;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(233, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(230, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = Properties.Resources.folder;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(233, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            closeToolStripMenuItem.Size = new Size(233, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(230, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Image = Properties.Resources.diskette;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(233, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Image = Properties.Resources.file_save_as;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(233, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(230, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.door_out;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            exitToolStripMenuItem.Size = new Size(233, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewerToolStripMenuItem, toolStripSeparator7, importOBJToolStripMenuItem, exportOBJToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // importOBJToolStripMenuItem
            // 
            importOBJToolStripMenuItem.Enabled = false;
            importOBJToolStripMenuItem.Image = Properties.Resources.package_in;
            importOBJToolStripMenuItem.Name = "importOBJToolStripMenuItem";
            importOBJToolStripMenuItem.Size = new Size(180, 22);
            importOBJToolStripMenuItem.Text = "Import OBJ...";
            importOBJToolStripMenuItem.Click += importOBJToolStripMenuItem_Click;
            // 
            // exportOBJToolStripMenuItem
            // 
            exportOBJToolStripMenuItem.Enabled = false;
            exportOBJToolStripMenuItem.Image = Properties.Resources.package_go;
            exportOBJToolStripMenuItem.Name = "exportOBJToolStripMenuItem";
            exportOBJToolStripMenuItem.Size = new Size(180, 22);
            exportOBJToolStripMenuItem.Text = "Export OBJ...";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { versionInformationToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // versionInformationToolStripMenuItem
            // 
            versionInformationToolStripMenuItem.Image = Properties.Resources.hzceditor_about;
            versionInformationToolStripMenuItem.Name = "versionInformationToolStripMenuItem";
            versionInformationToolStripMenuItem.Size = new Size(187, 22);
            versionInformationToolStripMenuItem.Text = "Version Information...";
            versionInformationToolStripMenuItem.Click += versionInformationToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { newToolStripButton, openToolStripButton, saveToolStripButton, saveAsToolStripButton, toolStripSeparator4, viewerToolStripButton, toolStripSeparator5, importObjToolStripButton, exportObjToolStripButton, toolStripSeparator6, versionInformationToolStripButton });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = Properties.Resources.document_new;
            newToolStripButton.ImageTransparentColor = Color.Magenta;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(23, 22);
            newToolStripButton.Text = "New (Ctrl+N)";
            newToolStripButton.Click += newToolStripButton_Click;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = Properties.Resources.folder;
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "Open (Ctrl+O)";
            openToolStripButton.Click += openToolStripButton_Click;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Enabled = false;
            saveToolStripButton.Image = Properties.Resources.diskette;
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(23, 22);
            saveToolStripButton.Text = "Save (Ctrl+S)";
            saveToolStripButton.Click += saveToolStripButton_Click;
            // 
            // saveAsToolStripButton
            // 
            saveAsToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveAsToolStripButton.Enabled = false;
            saveAsToolStripButton.Image = Properties.Resources.file_save_as;
            saveAsToolStripButton.ImageTransparentColor = Color.Magenta;
            saveAsToolStripButton.Name = "saveAsToolStripButton";
            saveAsToolStripButton.Size = new Size(23, 22);
            saveAsToolStripButton.Text = "Save As (Ctrl+Shift+S)";
            saveAsToolStripButton.Click += saveAsToolStripButton_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // viewerToolStripButton
            // 
            viewerToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            viewerToolStripButton.Enabled = false;
            viewerToolStripButton.Image = Properties.Resources.lcd_tv_test;
            viewerToolStripButton.ImageTransparentColor = Color.Magenta;
            viewerToolStripButton.Name = "viewerToolStripButton";
            viewerToolStripButton.Size = new Size(23, 22);
            viewerToolStripButton.Text = "viewerToolStripButton";
            viewerToolStripButton.ToolTipText = "Open Viewer";
            viewerToolStripButton.Click += viewerToolStripButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // importObjToolStripButton
            // 
            importObjToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            importObjToolStripButton.Enabled = false;
            importObjToolStripButton.Image = Properties.Resources.package_in;
            importObjToolStripButton.ImageTransparentColor = Color.Magenta;
            importObjToolStripButton.Name = "importObjToolStripButton";
            importObjToolStripButton.Size = new Size(23, 22);
            importObjToolStripButton.Text = "Import OBJ";
            importObjToolStripButton.Click += importObjToolStripButton_Click;
            // 
            // exportObjToolStripButton
            // 
            exportObjToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            exportObjToolStripButton.Enabled = false;
            exportObjToolStripButton.Image = Properties.Resources.package_go;
            exportObjToolStripButton.ImageTransparentColor = Color.Magenta;
            exportObjToolStripButton.Name = "exportObjToolStripButton";
            exportObjToolStripButton.Size = new Size(23, 22);
            exportObjToolStripButton.Text = "Export OBJ";
            exportObjToolStripButton.Click += exportObjToolStripButton_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 25);
            // 
            // versionInformationToolStripButton
            // 
            versionInformationToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            versionInformationToolStripButton.Image = Properties.Resources.hzceditor_about;
            versionInformationToolStripButton.ImageTransparentColor = Color.Magenta;
            versionInformationToolStripButton.Name = "versionInformationToolStripButton";
            versionInformationToolStripButton.Size = new Size(23, 22);
            versionInformationToolStripButton.Text = "versionInformationToolStripButton";
            versionInformationToolStripButton.ToolTipText = "Version Information";
            versionInformationToolStripButton.Click += versionInformationToolStripButton_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 52);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(propertyGrid1);
            splitContainer1.Size = new Size(776, 386);
            splitContainer1.SplitterDistance = 189;
            splitContainer1.TabIndex = 2;
            splitContainer1.TabStop = false;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Enabled = false;
            treeView1.ImageKey = "folder_hzc.png";
            treeView1.ImageList = imageList1;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode6.ImageKey = "vertices.png";
            treeNode6.Name = "Node1";
            treeNode6.SelectedImageKey = "vertices.png";
            treeNode6.Text = "Vertices";
            treeNode7.ImageKey = "grid_triangle.png";
            treeNode7.Name = "Node2";
            treeNode7.SelectedImageKey = "grid_triangle.png";
            treeNode7.Text = "Triangles";
            treeNode8.ImageKey = "grid.png";
            treeNode8.Name = "Node3";
            treeNode8.SelectedImageKey = "grid.png";
            treeNode8.Text = "Grid";
            treeNode9.ImageKey = "bubblechart.png";
            treeNode9.Name = "Node4";
            treeNode9.SelectedImageKey = "bubblechart.png";
            treeNode9.Text = "Custom Attributes";
            treeNode10.ImageKey = "folder_hzc.png";
            treeNode10.Name = "Node0";
            treeNode10.SelectedImageKey = "folder_hzc.png";
            treeNode10.Text = "HZC";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode10 });
            treeView1.SelectedImageKey = "folder_hzc.png";
            treeView1.Size = new Size(189, 386);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "folder_hzc.png");
            imageList1.Images.SetKeyName(1, "vertices.png");
            imageList1.Images.SetKeyName(2, "draw_vertex.png");
            imageList1.Images.SetKeyName(3, "grid_triangle.png");
            imageList1.Images.SetKeyName(4, "draw_triangle.png");
            imageList1.Images.SetKeyName(5, "grid.png");
            imageList1.Images.SetKeyName(6, "bubblechart.png");
            imageList1.Images.SetKeyName(7, "molecule.png");
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(583, 386);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // triangleContextMenuStrip
            // 
            triangleContextMenuStrip.Items.AddRange(new ToolStripItem[] { recomputeNormalsToolStripMenuItem });
            triangleContextMenuStrip.Name = "triangleContextMenuStrip";
            triangleContextMenuStrip.Size = new Size(182, 26);
            // 
            // recomputeNormalsToolStripMenuItem
            // 
            recomputeNormalsToolStripMenuItem.Name = "recomputeNormalsToolStripMenuItem";
            recomputeNormalsToolStripMenuItem.Size = new Size(181, 22);
            recomputeNormalsToolStripMenuItem.Text = "Recompute normals";
            recomputeNormalsToolStripMenuItem.Click += recomputeNormalsToolStripMenuItem_Click;
            // 
            // gridContextMenuStrip
            // 
            gridContextMenuStrip.Items.AddRange(new ToolStripItem[] { rebuildToolStripMenuItem });
            gridContextMenuStrip.Name = "gridContextMenuStrip";
            gridContextMenuStrip.Size = new Size(115, 26);
            // 
            // rebuildToolStripMenuItem
            // 
            rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            rebuildToolStripMenuItem.Size = new Size(114, 22);
            rebuildToolStripMenuItem.Text = "Rebuild";
            rebuildToolStripMenuItem.Click += rebuildToolStripMenuItem_Click;
            // 
            // attributesRootContextMenuStrip
            // 
            attributesRootContextMenuStrip.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem });
            attributesRootContextMenuStrip.Name = "attributesRootContextMenuStrip";
            attributesRootContextMenuStrip.Size = new Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(96, 22);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // attributeContextMenuStrip
            // 
            attributeContextMenuStrip.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem });
            attributeContextMenuStrip.Name = "attributeContextMenuStrip";
            attributeContextMenuStrip.Size = new Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(117, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // viewerToolStripMenuItem
            // 
            viewerToolStripMenuItem.Enabled = false;
            viewerToolStripMenuItem.Image = Properties.Resources.lcd_tv_test;
            viewerToolStripMenuItem.Name = "viewerToolStripMenuItem";
            viewerToolStripMenuItem.Size = new Size(180, 22);
            viewerToolStripMenuItem.Text = "Open Viewer";
            viewerToolStripMenuItem.Click += viewerToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(177, 6);
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "HZC Editor";
            FormClosing += Form1_FormClosing;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            triangleContextMenuStrip.ResumeLayout(false);
            gridContextMenuStrip.ResumeLayout(false);
            attributesRootContextMenuStrip.ResumeLayout(false);
            attributeContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton saveAsToolStripButton;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private PropertyGrid propertyGrid1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton newToolStripButton;
        private ContextMenuStrip triangleContextMenuStrip;
        private ToolStripMenuItem recomputeNormalsToolStripMenuItem;
        private ContextMenuStrip gridContextMenuStrip;
        private ToolStripMenuItem rebuildToolStripMenuItem;
        private ContextMenuStrip attributesRootContextMenuStrip;
        private ToolStripMenuItem addToolStripMenuItem;
        private ContextMenuStrip attributeContextMenuStrip;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ImageList imageList1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem importOBJToolStripMenuItem;
        private ToolStripMenuItem exportOBJToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton importObjToolStripButton;
        private ToolStripButton exportObjToolStripButton;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem versionInformationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton viewerToolStripButton;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton versionInformationToolStripButton;
        private ToolStripMenuItem viewerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
    }
}
