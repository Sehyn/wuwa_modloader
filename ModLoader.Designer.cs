namespace wuwa_modloader
{
    partial class ModLoader
    {
        private System.ComponentModel.IContainer components = null;

        // Declare UI components
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label selectedPathLabel;
        private System.Windows.Forms.ListBox availableModsListBox;
        private System.Windows.Forms.Label availableModsLabel;
        private System.Windows.Forms.Button installModButton;
        private System.Windows.Forms.ListBox installedModsListBox;
        private System.Windows.Forms.Label installedModsLabel;
        private System.Windows.Forms.Button uninstallModButton;
        private System.Windows.Forms.Label modDescriptionLabel;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            browseButton = new Button();
            selectedPathLabel = new Label();
            availableModsListBox = new ListBox();
            availableModsLabel = new Label();
            installModButton = new Button();
            installedModsListBox = new ListBox();
            installedModsLabel = new Label();
            uninstallModButton = new Button();
            modDescriptionLabel = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            LaunchGameModsButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Location = new Point(6, 45);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(120, 23);
            browseButton.TabIndex = 0;
            browseButton.Text = "Browse for Folder";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += BrowseButton_Click;
            // 
            // selectedPathLabel
            // 
            selectedPathLabel.AutoSize = true;
            selectedPathLabel.Location = new Point(6, 27);
            selectedPathLabel.Name = "selectedPathLabel";
            selectedPathLabel.Size = new Size(84, 15);
            selectedPathLabel.TabIndex = 1;
            selectedPathLabel.Text = "Selected Path: ";
            // 
            // availableModsListBox
            // 
            availableModsListBox.FormattingEnabled = true;
            availableModsListBox.ItemHeight = 15;
            availableModsListBox.Location = new Point(6, 102);
            availableModsListBox.Name = "availableModsListBox";
            availableModsListBox.Size = new Size(240, 94);
            availableModsListBox.TabIndex = 2;
            availableModsListBox.SelectedIndexChanged += AvailableModsListBox_SelectedIndexChanged;
            // 
            // availableModsLabel
            // 
            availableModsLabel.AutoSize = true;
            availableModsLabel.Location = new Point(6, 82);
            availableModsLabel.Name = "availableModsLabel";
            availableModsLabel.Size = new Size(91, 15);
            availableModsLabel.TabIndex = 3;
            availableModsLabel.Text = "Available Mods:";
            // 
            // installModButton
            // 
            installModButton.Location = new Point(6, 202);
            installModButton.Name = "installModButton";
            installModButton.Size = new Size(240, 23);
            installModButton.TabIndex = 4;
            installModButton.Text = "Install Selected Mod";
            installModButton.UseVisualStyleBackColor = true;
            installModButton.Click += InstallModButton_Click;
            // 
            // installedModsListBox
            // 
            installedModsListBox.FormattingEnabled = true;
            installedModsListBox.ItemHeight = 15;
            installedModsListBox.Location = new Point(273, 102);
            installedModsListBox.Name = "installedModsListBox";
            installedModsListBox.Size = new Size(236, 94);
            installedModsListBox.TabIndex = 5;
            installedModsListBox.SelectedIndexChanged += InstalledModsListBox_SelectedIndexChanged;
            // 
            // installedModsLabel
            // 
            installedModsLabel.AutoSize = true;
            installedModsLabel.Location = new Point(273, 82);
            installedModsLabel.Name = "installedModsLabel";
            installedModsLabel.Size = new Size(87, 15);
            installedModsLabel.TabIndex = 6;
            installedModsLabel.Text = "Installed Mods:";
            // 
            // uninstallModButton
            // 
            uninstallModButton.Location = new Point(273, 202);
            uninstallModButton.Name = "uninstallModButton";
            uninstallModButton.Size = new Size(236, 23);
            uninstallModButton.TabIndex = 7;
            uninstallModButton.Text = "Uninstall Selected Mod";
            uninstallModButton.UseVisualStyleBackColor = true;
            uninstallModButton.Click += UninstallModButton_Click;
            // 
            // modDescriptionLabel
            // 
            modDescriptionLabel.AutoSize = true;
            modDescriptionLabel.Location = new Point(6, 19);
            modDescriptionLabel.Name = "modDescriptionLabel";
            modDescriptionLabel.Size = new Size(0, 15);
            modDescriptionLabel.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(modDescriptionLabel);
            groupBox1.Location = new Point(6, 246);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(503, 123);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 409);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 10;
            label1.Text = "GitHub: Sehyn";
            // 
            // LaunchGameModsButton
            // 
            LaunchGameModsButton.Location = new Point(6, 383);
            LaunchGameModsButton.Name = "LaunchGameModsButton";
            LaunchGameModsButton.Size = new Size(503, 23);
            LaunchGameModsButton.TabIndex = 11;
            LaunchGameModsButton.Text = "Launch game with mods";
            LaunchGameModsButton.UseVisualStyleBackColor = true;
            LaunchGameModsButton.Click += LaunchGameModsButton_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(515, 433);
            Controls.Add(LaunchGameModsButton);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(browseButton);
            Controls.Add(selectedPathLabel);
            Controls.Add(availableModsListBox);
            Controls.Add(availableModsLabel);
            Controls.Add(installModButton);
            Controls.Add(installedModsListBox);
            Controls.Add(installedModsLabel);
            Controls.Add(uninstallModButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wuthering Waves Mod Loader [v1.0]";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox groupBox1;
        private Label label1;
        private Button LaunchGameModsButton;
    }
}
