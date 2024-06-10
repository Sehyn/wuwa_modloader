using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace wuwa_modloader
{
    public partial class ModLoader : Form
    {
        private string selectedFolderPath = string.Empty;
        private Dictionary<string, string> modDescriptions;

        public ModLoader()
        {
            InitializeComponent();
            LoadModDescriptions();
            //UpdateInstallButtonState();
        }

        private void LoadModDescriptions()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "modDescriptions.json");
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                modDescriptions = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                modDescriptions = new Dictionary<string, string>();
                MessageBox.Show("Mod descriptions file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderDialog.SelectedPath;
                    string gameExePath = Path.Combine(selectedFolderPath, "Wuthering Waves.exe");
                    if (File.Exists(gameExePath))
                    {
                        selectedPathLabel.Text = "Selected Path: " + selectedFolderPath;
                        LoadAvailableMods();
                        LoadInstalledMods();
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain 'Wuthering Waves.exe'. Please select the correct folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            UpdateInstallButtonState();
        }

        private void LoadAvailableMods()
        {
            availableModsListBox.Items.Clear();

            string modsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "mods");
            if (Directory.Exists(modsDirectory))
            {
                string[] modFiles = Directory.GetFiles(modsDirectory);
                foreach (string modFile in modFiles)
                {
                    availableModsListBox.Items.Add(Path.GetFileName(modFile));
                }
            }
        }

        private void LoadInstalledMods()
        {
            installedModsListBox.Items.Clear();

            string modsDirectory = Path.Combine(selectedFolderPath, "Client", "Content", "Paks", "~mod");
            if (Directory.Exists(modsDirectory))
            {
                string[] modFiles = Directory.GetFiles(modsDirectory);
                foreach (string modFile in modFiles)
                {
                    installedModsListBox.Items.Add(Path.GetFileName(modFile));
                }
            }
        }

        private void InstallModButton_Click(object sender, EventArgs e)
        {
            if (availableModsListBox.SelectedItem != null)
            {
                string selectedMod = availableModsListBox.SelectedItem.ToString();
                string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), "mods", selectedMod);
                string targetDirectory = Path.Combine(selectedFolderPath, "Client", "Content", "Paks", "~mod");

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string targetFile = Path.Combine(targetDirectory, selectedMod);
                File.Copy(sourceFile, targetFile, true);
                LoadInstalledMods();
            }
        }

        private void UninstallModButton_Click(object sender, EventArgs e)
        {
            if (installedModsListBox.SelectedItem != null)
            {
                string selectedMod = installedModsListBox.SelectedItem.ToString();
                string targetDirectory = Path.Combine(selectedFolderPath, "Client", "Content", "Paks", "~mod");
                string targetFile = Path.Combine(targetDirectory, selectedMod);

                if (File.Exists(targetFile))
                {
                    File.Delete(targetFile);
                    LoadInstalledMods();
                }
            }
        }

        private void AvailableModsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableModsListBox.SelectedItem != null)
            {
                string selectedMod = availableModsListBox.SelectedItem.ToString();
                string modDescription = GetModDescription(selectedMod);
                modDescriptionLabel.Text = "Mod Description:\n\n" + modDescription;
            }
        }

        private void InstalledModsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (installedModsListBox.SelectedItem != null)
            {
                string selectedMod = installedModsListBox.SelectedItem.ToString();
                string modDescription = GetModDescription(selectedMod);
                modDescriptionLabel.Text = "Mod Description:\n\n" + modDescription;
            }
        }

        private string GetModDescription(string modFileName)
        {
            if (modDescriptions.ContainsKey(modFileName))
            {
                return modDescriptions[modFileName];
            }
            else
            {
                return "No description available.";
            }
        }

        private void UpdateInstallButtonState()
        {
            string modFolderPath = Path.Combine(selectedFolderPath, "Client", "Content", "Paks", "~mod");

            if (!Directory.Exists(modFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(modFolderPath);
                    installModButton.Enabled = !string.IsNullOrEmpty(selectedFolderPath) && Directory.Exists(modFolderPath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating mod folder: " + ex.Message);
                }
            }

        }


        private void LaunchGameModsButton_Click(object sender, EventArgs e)
        {

            string executableName = "Wuthering Waves.exe";
            string executablePath = Path.Combine(selectedFolderPath, executableName);
            string arguments = "-fileopenlog";

            if (File.Exists(executablePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = executablePath;
                startInfo.Arguments = arguments;

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Executable not found in the selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunchGameWithoutModsButton_Click(object sender, EventArgs e)
        {

            string executableName = "Wuthering Waves.exe";
            string executablePath = Path.Combine(selectedFolderPath, executableName);

            if (File.Exists(executablePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = executablePath;

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Executable not found in the selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}