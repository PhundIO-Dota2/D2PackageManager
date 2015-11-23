using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace D2PackageManager {
    public partial class D2PackageManagerMainForm : Form {
        string CurrentAddonContentFolder;
        string CurrentAddonGameFolder;

        string CurrentAddonName = "";

        public static string AddonContentFolder;
        public static string AddonGameFolder;

        public D2PackageManagerMainForm() {
            InitializeComponent();
        }

        private void UpdateSelectedAddon(object sender, EventArgs e) {
            if (addonsListBox.SelectedIndex >= 0) {
                UpdateSelectedAddon((string)addonsListBox.Items[addonsListBox.SelectedIndex]);
            }
        }

        bool isUpdatingSelectedAddon = false;

        private void UpdateSelectedAddon(string AddonName) {
            isUpdatingSelectedAddon = true;
            labelSelectedAddonName.Text = AddonName;

            CurrentAddonContentFolder = AddonContentFolder + "\\" + AddonName;
            CurrentAddonGameFolder = AddonGameFolder + "\\" + AddonName;
            CurrentAddonName = AddonName;

            addonsListBox.SelectedIndex = addonsListBox.Items.IndexOf(AddonName);

            listBoxCurrentAddonLibraries.Items.Clear();

            var manager_info_file_path = CurrentAddonGameFolder + "/d2packagemanager_info.txt";

            IEnumerable<string> lines = new string[0];

            if (File.Exists(manager_info_file_path)) {
                lines = File.ReadLines(manager_info_file_path);
            }

            foreach (var library in Libraries.D2Libraries) {
                if(library.ModType != ModType.Base) {
                    listBoxCurrentAddonLibraries.Items.Add(library.Name, lines.Contains("lib:" + library.FullyQualifiedName));
                }
            }

            isUpdatingSelectedAddon = false;
        }

        private void OnLoad(object sender, EventArgs e) {
            ReloadAddons();
        }

        private void ReloadAddons() {
            var addon_paths = Directory.GetDirectories(D2PackageManagerMainForm.AddonGameFolder).ToList<string>();
            for (int i = 0; i < addon_paths.Count; i++) {
                string addon_path = addon_paths[i];
                if (addon_path.EndsWith("\\addon_template") ||
                    addon_path.EndsWith("\\adventure_example") ||
                    addon_path.EndsWith("\\hero_demo") ||
                    addon_path.EndsWith("\\holdout_example") ||
                    addon_path.EndsWith("\\lua_ability_example") ||
                    addon_path.EndsWith("\\overthrow") ||
                    addon_path.EndsWith("\\rpg_example") ||
                    addon_path.EndsWith("\\rpg_test") ||
                    addon_path.EndsWith("\\tutorial_assist_game") ||
                    addon_path.EndsWith("\\tutorial_basics") ||
                    addon_path.EndsWith("\\ui_example") ||
                    addon_path.EndsWith("\\ui_test") ||
                    addon_path.EndsWith("\\vpks") ||
                    addon_path.EndsWith("\\workshop_testbed")) {
                    addon_paths.RemoveAt(i);
                    i--;
                }
            }
            addonsListBox.Items.Clear();
            for (int i = 0; i < addon_paths.Count; i++) {
                var addon_path = addon_paths[i];
                addonsListBox.Items.Add(addon_path.Replace(AddonGameFolder + "\\", ""));
            }
            if (addon_paths.Count > 0) {
                UpdateSelectedAddon((string)addonsListBox.Items[0]);
            }
        }

        private void NewAddonClick(object sender, EventArgs e) {
            string branch = "source2";
            string user = "bmddota";
            string library = "barebones";

            string new_addon_name = "test_addon_420";

            new WebClient().DownloadFile("https://github.com/" + user + "/" + library + "/archive/" + branch + ".zip", "basemod.zip");
            ZipFile.ExtractToDirectory("basemod.zip", "basemod");
            string root_folder = "basemod/" + library + "-" + branch;

            IOHelper.Copyfolder(root_folder + "/content/dota_addons/" + library, AddonContentFolder + "/" + new_addon_name);
            IOHelper.Copyfolder(root_folder + "/game/dota_addons/" + library, AddonGameFolder + "/" + new_addon_name);

            Directory.Delete("basemod", true);
            File.Delete("basemod.zip");

            File.WriteAllText(AddonGameFolder + "/" + new_addon_name + "/d2packagemanager_info.txt", "base:bmddota/barebones,source2");

            //Libraries.D2Libraries[1].ApplyToAddon(new_addon_name);
            //Libraries.D2Libraries[2].ApplyToAddon(new_addon_name);

            ReloadAddons();

            UpdateSelectedAddon(new_addon_name);
        }

        private void deleteAddonButton_Click(object sender, EventArgs e) {
            var confirmResult = MessageBox.Show("Are you sure to delete this addon ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) {
                Directory.Delete(CurrentAddonContentFolder, true);
                Directory.Delete(CurrentAddonGameFolder, true);
                ReloadAddons();
            }
        }

        private void listBoxCurrentAddonLibraries_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (isUpdatingSelectedAddon) {
                return;
            }
            string library_name = (string)listBoxCurrentAddonLibraries.Items[e.Index];
            if (e.CurrentValue == CheckState.Checked) {
                e.NewValue = CheckState.Checked;
            } else {
                foreach (var library in Libraries.D2Libraries) {
                    if (library.Name == library_name) {
                        library.ApplyToAddon(CurrentAddonName);
                        return;
                    }
                }
            }
        }
    }
}
