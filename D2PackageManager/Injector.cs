using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2PackageManager {
    static class Injector {
        public static void Inject(string addon_target, D2Library library) {
            var lines = File.ReadAllLines("LibraryInjections.txt");
            var list_lines = lines.ToList();
            list_lines.Add("");
            lines = list_lines.ToArray<string>();

            var start_line = -1;
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i].StartsWith(library.FullyQualifiedName + ":")) {
                    start_line = i;
                    break;
                }
            }
            if (start_line >= 0) {
                var end_line = -1;
                for (int i = start_line; i < lines.Length; i++) {
                    var trimmed_line = lines[i].Trim().Replace("\n", "").Replace("\t", "").Replace("\r", "");
                    if (trimmed_line.Length == 0) {
                        end_line = i;
                        break;
                    }
                }
                File.AppendAllText(addon_target, "-- INJECTED CODE FROM \"" + library.FullyQualifiedName + "\"\n");
                File.AppendAllLines(addon_target, lines.SubArray<string>(start_line + 1, end_line - start_line - 1));
                File.AppendAllText(addon_target, "-- ENDINJECTION");
            }
        }
    }
}
