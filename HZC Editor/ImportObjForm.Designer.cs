namespace HZC_Editor
{
    partial class ImportObjForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            objPathLabel = new Label();
            objPathTextBox = new TextBox();
            browseButton = new Button();
            groupsDataGridView = new DataGridView();
            GroupName = new DataGridViewTextBoxColumn();
            FaceCount = new DataGridViewTextBoxColumn();
            AssignTo = new DataGridViewTextBoxColumn();
            settingsGroupBox = new GroupBox();
            keepExistingAttributesCheckBox = new CheckBox();
            gridZNumericUpDown = new NumericUpDown();
            gridZLabel = new Label();
            gridYNumericUpDown = new NumericUpDown();
            gridYLabel = new Label();
            gridXNumericUpDown = new NumericUpDown();
            gridXLabel = new Label();
            okButton = new Button();
            cancelButton = new Button();
            autoDetectButton = new Button();
            ((System.ComponentModel.ISupportInitialize)groupsDataGridView).BeginInit();
            settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridZNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridYNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridXNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // objPathLabel
            // 
            objPathLabel.BorderStyle = BorderStyle.FixedSingle;
            objPathLabel.Location = new Point(12, 9);
            objPathLabel.Name = "objPathLabel";
            objPathLabel.Size = new Size(59, 23);
            objPathLabel.TabIndex = 0;
            objPathLabel.Text = "OBJ Path:";
            objPathLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // objPathTextBox
            // 
            objPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            objPathTextBox.Location = new Point(70, 9);
            objPathTextBox.Name = "objPathTextBox";
            objPathTextBox.ReadOnly = true;
            objPathTextBox.Size = new Size(290, 23);
            objPathTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Cursor = Cursors.Hand;
            browseButton.Location = new Point(366, 9);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // groupsDataGridView
            // 
            groupsDataGridView.AllowUserToAddRows = false;
            groupsDataGridView.AllowUserToDeleteRows = false;
            groupsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            groupsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            groupsDataGridView.Columns.AddRange(new DataGridViewColumn[] { GroupName, FaceCount, AssignTo });
            groupsDataGridView.Location = new Point(12, 38);
            groupsDataGridView.Name = "groupsDataGridView";
            groupsDataGridView.RowHeadersVisible = false;
            groupsDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            groupsDataGridView.Size = new Size(641, 307);
            groupsDataGridView.TabIndex = 3;
            // 
            // GroupName
            // 
            GroupName.FillWeight = 40F;
            GroupName.HeaderText = "Group name";
            GroupName.Name = "GroupName";
            GroupName.ReadOnly = true;
            // 
            // FaceCount
            // 
            FaceCount.FillWeight = 15F;
            FaceCount.HeaderText = "Face count";
            FaceCount.Name = "FaceCount";
            FaceCount.ReadOnly = true;
            // 
            // AssignTo
            // 
            AssignTo.FillWeight = 45F;
            AssignTo.HeaderText = "Assign to (attribute or blank)";
            AssignTo.Name = "AssignTo";
            // 
            // settingsGroupBox
            // 
            settingsGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            settingsGroupBox.Controls.Add(keepExistingAttributesCheckBox);
            settingsGroupBox.Controls.Add(gridZNumericUpDown);
            settingsGroupBox.Controls.Add(gridZLabel);
            settingsGroupBox.Controls.Add(gridYNumericUpDown);
            settingsGroupBox.Controls.Add(gridYLabel);
            settingsGroupBox.Controls.Add(gridXNumericUpDown);
            settingsGroupBox.Controls.Add(gridXLabel);
            settingsGroupBox.Location = new Point(12, 351);
            settingsGroupBox.Name = "settingsGroupBox";
            settingsGroupBox.Size = new Size(641, 70);
            settingsGroupBox.TabIndex = 4;
            settingsGroupBox.TabStop = false;
            settingsGroupBox.Text = "Settings";
            // 
            // keepExistingAttributesCheckBox
            // 
            keepExistingAttributesCheckBox.AutoSize = true;
            keepExistingAttributesCheckBox.Location = new Point(6, 45);
            keepExistingAttributesCheckBox.Name = "keepExistingAttributesCheckBox";
            keepExistingAttributesCheckBox.Size = new Size(148, 19);
            keepExistingAttributesCheckBox.TabIndex = 7;
            keepExistingAttributesCheckBox.Text = "Keep existing attributes";
            keepExistingAttributesCheckBox.UseVisualStyleBackColor = true;
            // 
            // gridZNumericUpDown
            // 
            gridZNumericUpDown.Location = new Point(280, 19);
            gridZNumericUpDown.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            gridZNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gridZNumericUpDown.Name = "gridZNumericUpDown";
            gridZNumericUpDown.Size = new Size(65, 23);
            gridZNumericUpDown.TabIndex = 6;
            gridZNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // gridZLabel
            // 
            gridZLabel.BorderStyle = BorderStyle.FixedSingle;
            gridZLabel.Location = new Point(236, 19);
            gridZLabel.Name = "gridZLabel";
            gridZLabel.Size = new Size(45, 23);
            gridZLabel.TabIndex = 5;
            gridZLabel.Text = "Grid Z:";
            gridZLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gridYNumericUpDown
            // 
            gridYNumericUpDown.Location = new Point(165, 19);
            gridYNumericUpDown.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            gridYNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gridYNumericUpDown.Name = "gridYNumericUpDown";
            gridYNumericUpDown.Size = new Size(65, 23);
            gridYNumericUpDown.TabIndex = 4;
            gridYNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // gridYLabel
            // 
            gridYLabel.BorderStyle = BorderStyle.FixedSingle;
            gridYLabel.Location = new Point(121, 19);
            gridYLabel.Name = "gridYLabel";
            gridYLabel.Size = new Size(45, 23);
            gridYLabel.TabIndex = 3;
            gridYLabel.Text = "Grid Y:";
            gridYLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gridXNumericUpDown
            // 
            gridXNumericUpDown.Location = new Point(50, 19);
            gridXNumericUpDown.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            gridXNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gridXNumericUpDown.Name = "gridXNumericUpDown";
            gridXNumericUpDown.Size = new Size(65, 23);
            gridXNumericUpDown.TabIndex = 2;
            gridXNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // gridXLabel
            // 
            gridXLabel.BorderStyle = BorderStyle.FixedSingle;
            gridXLabel.Location = new Point(6, 19);
            gridXLabel.Name = "gridXLabel";
            gridXLabel.Size = new Size(45, 23);
            gridXLabel.TabIndex = 1;
            gridXLabel.Text = "Grid X:";
            gridXLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Cursor = Cursors.Hand;
            okButton.Location = new Point(578, 427);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 5;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.Location = new Point(497, 427);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // autoDetectButton
            // 
            autoDetectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            autoDetectButton.Cursor = Cursors.Hand;
            autoDetectButton.Location = new Point(447, 9);
            autoDetectButton.Name = "autoDetectButton";
            autoDetectButton.Size = new Size(128, 23);
            autoDetectButton.TabIndex = 7;
            autoDetectButton.Text = "Auto-detect by name";
            autoDetectButton.UseVisualStyleBackColor = true;
            autoDetectButton.Click += autoDetectButton_Click;
            // 
            // ImportObjForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(665, 462);
            Controls.Add(autoDetectButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(settingsGroupBox);
            Controls.Add(groupsDataGridView);
            Controls.Add(browseButton);
            Controls.Add(objPathTextBox);
            Controls.Add(objPathLabel);
            MinimumSize = new Size(391, 290);
            Name = "ImportObjForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Import OBJ";
            ((System.ComponentModel.ISupportInitialize)groupsDataGridView).EndInit();
            settingsGroupBox.ResumeLayout(false);
            settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridZNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridYNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridXNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label objPathLabel;
        private TextBox objPathTextBox;
        private Button browseButton;
        private DataGridView groupsDataGridView;
        private GroupBox settingsGroupBox;
        private Label gridXLabel;
        private CheckBox keepExistingAttributesCheckBox;
        private NumericUpDown gridZNumericUpDown;
        private Label gridZLabel;
        private NumericUpDown gridYNumericUpDown;
        private Label gridYLabel;
        private NumericUpDown gridXNumericUpDown;
        private Button okButton;
        private Button cancelButton;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn FaceCount;
        private DataGridViewTextBoxColumn AssignTo;
        private Button autoDetectButton;
    }
}