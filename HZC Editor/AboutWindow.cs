using System.Diagnostics;
using System.Reflection;

namespace HZC_Editor
{
    public partial class AboutWindow : Form
    {
        public AboutWindow(string link = "")
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = $"About {fvi.ProductName}";
            this.nameLabel.Text = fvi.ProductName;
            this.versionLabel.Text = $"Version {fvi.ProductVersion}";
            this.copyrightLabel.Text = fvi.LegalCopyright;
            Icon? appIcon = Icon.ExtractAssociatedIcon(assembly.Location);
            if (appIcon != null)
                this.toolLogoPictureBox.BackgroundImage = appIcon.ToBitmap();

            if (string.IsNullOrEmpty(link))
                this.linkLabel.Visible = false;

            this.linkLabel.Text = link;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(this.linkLabel.Text)
            {
                UseShellExecute = true
            };

            Process.Start(info);
        }
    }
}
