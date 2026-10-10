namespace HZC_Editor
{
    partial class AboutWindow
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
            nameLabel = new Label();
            versionLabel = new Label();
            okButton = new Button();
            copyrightLabel = new Label();
            toolLogoPictureBox = new PictureBox();
            linkLabel = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)toolLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(103, 29);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(65, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Tool Name";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(240, 29);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(71, 15);
            versionLabel.TabIndex = 1;
            versionLabel.Text = "Tool Version";
            // 
            // okButton
            // 
            okButton.Cursor = Cursors.Hand;
            okButton.Location = new Point(396, 100);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Location = new Point(103, 59);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(84, 15);
            copyrightLabel.TabIndex = 3;
            copyrightLabel.Text = "Copyright Text";
            // 
            // toolLogoPictureBox
            // 
            toolLogoPictureBox.BackgroundImageLayout = ImageLayout.Center;
            toolLogoPictureBox.Location = new Point(12, 12);
            toolLogoPictureBox.Name = "toolLogoPictureBox";
            toolLogoPictureBox.Size = new Size(64, 64);
            toolLogoPictureBox.TabIndex = 4;
            toolLogoPictureBox.TabStop = false;
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Location = new Point(103, 74);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(29, 15);
            linkLabel.TabIndex = 6;
            linkLabel.TabStop = true;
            linkLabel.Text = "Link";
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // AboutWindow
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 135);
            Controls.Add(linkLabel);
            Controls.Add(toolLogoPictureBox);
            Controls.Add(copyrightLabel);
            Controls.Add(okButton);
            Controls.Add(versionLabel);
            Controls.Add(nameLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)toolLogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label versionLabel;
        private Button okButton;
        private Label copyrightLabel;
        private PictureBox toolLogoPictureBox;
        private LinkLabel linkLabel;
    }
}