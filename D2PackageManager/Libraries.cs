using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace D2PackageManager {
    public enum ModType {
        Base,
        Library,
        LuaScripts,
    }
    public enum RemapKey {
        VScripts,
        PanoramaContent,
        Particles,
        Maps,
        Abilities,
    }
    public class D2Library {
        public string Author = "";
        public string Name = "";
        public string Branch = "";

        public bool Standard = false;
        public Dictionary<RemapKey, string> Remaps = new Dictionary<RemapKey, string>();

        public ModType ModType;

        public void ApplyToAddon(string AddonName) {
            if(Directory.Exists("library")) Directory.Delete("library", true);
            if(File.Exists("library.zip")) File.Delete("library.zip");
            new WebClient().DownloadFile("https://github.com/" + Author + "/" + Name + "/archive/" + Branch + ".zip", "library.zip");
            ZipFile.ExtractToDirectory("library.zip", "library");

            var root_dir = "library/" + Name + "-" + Branch + "/";
            var target_root_dir_game = D2PackageManagerMainForm.AddonGameFolder + "/" + AddonName;
            var target_root_dir_content = D2PackageManagerMainForm.AddonContentFolder + "/" + AddonName;

            foreach(var remap in Remaps) {
                if (remap.Key == RemapKey.VScripts) {
                    IOHelper.Copyfolder(root_dir + remap.Value, target_root_dir_game + "/scripts/vscripts/");
                }
                if (remap.Key == RemapKey.PanoramaContent) {
                    IOHelper.Copyfolder(root_dir + remap.Value, target_root_dir_content + "/panorama/");
                }
                if (remap.Key == RemapKey.Maps) {
                    IOHelper.Copyfolder(root_dir + remap.Value, target_root_dir_content + "/maps/");
                }
                if (remap.Key == RemapKey.Particles) {
                    IOHelper.Copyfolder(root_dir + remap.Value, target_root_dir_content + "/particles/");
                }
                if (remap.Key == RemapKey.Abilities) {
                    IOHelper.Copyfolder(root_dir + remap.Value, target_root_dir_game + "/scripts/npc/abilities");
                }
            }

            if (ModType == ModType.LuaScripts) {
                foreach(var path in Directory.GetFiles(root_dir, "*.lua")) {
                    var file_target_path = target_root_dir_game + "/scripts/vscripts/libraries/" + Name + "/" + path.Replace(root_dir, "");
                    Directory.CreateDirectory(Path.GetDirectoryName(file_target_path));
                    File.Copy(path, file_target_path, true);
                }
            }

            Directory.Delete("library", true);
            File.Delete("library.zip");

            Injector.Inject(target_root_dir_game + "/scripts/vscripts/internal/d2packagemanager.lua", this);

            if (!File.Exists(target_root_dir_game + "/d2packagemanager_info.txt")) {
                File.Create(target_root_dir_game + "/d2packagemanager_info.txt").Close();
                File.WriteAllText(target_root_dir_game + "/d2packagemanager_info.txt", "base:" + Libraries.D2Libraries[0].FullyQualifiedName);
            }
            File.WriteAllText(
                target_root_dir_game + "/d2packagemanager_info.txt", 

                File.ReadAllText(target_root_dir_game + "/d2packagemanager_info.txt") +
                "\nlib:" + FullyQualifiedName
            );
        }

        public string FullyQualifiedName {
            get {
                return Author + "/" + Name + "," + Branch;
            }
        }
    }
    public static class Libraries {
        public static List<D2Library> D2Libraries = new List<D2Library>();
        public static void ReloadLibraries() {
            string keypath = @"Software\Valve\Steam";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keypath);
            string registeredFilePath = key.GetValue("SteamPath").ToString();

            D2PackageManagerMainForm.AddonContentFolder = registeredFilePath + "\\steamapps\\common\\dota 2 beta\\content\\dota_addons";
            D2PackageManagerMainForm.AddonGameFolder = registeredFilePath + "\\steamapps\\common\\dota 2 beta\\game\\dota_addons";

            var libraries = File.ReadAllLines("LibraryLocationsIndex.txt");
            for (int i = 0; i < libraries.Length; i++) {
                var library_text = libraries[i];
                var library = new D2Library();
                D2Libraries.Add(library);

                library.Author = library_text.Split(',')[0].Split('/')[0];
                library.Name = library_text.Split(',')[0].Split('/')[1];
                library.Branch = library_text.Split(',')[1].Split(':')[0];

                var library_info = library_text.Split('[', ']')[1];
                var library_info_split = library_info.Split(',');
                for (int j = 0; j < library_info_split.Length; j++) {
                    var library_info_key = library_info_split[j].Split(':')[0];
                    var library_info_value = library_info_split[j].Split(':')[1];
                    if (library_info_key.StartsWith("remap_")) {
                        var remap_variable_name = library_info_key.Replace("remap_", "");
                        var remap_variable = (RemapKey)System.Enum.Parse(typeof(RemapKey), remap_variable_name);
                        library.Remaps.Add(remap_variable, library_info_value);
                    }
                    if (library_info_key == "modtype" && library_info_value == "library") {
                        library.ModType = ModType.Library;
                    }
                    if (library_info_key == "modtype" && library_info_value == "lua_scripts") {
                        library.ModType = ModType.LuaScripts;
                    }
                }
            }
        }
    }
}
