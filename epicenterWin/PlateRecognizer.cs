using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Reflection;

using openalprnet;

namespace epicenterWin
{
    struct PlateRecognizer
    {
        private static string _localRegion = "lt";
        private static string _configFile = Path.Combine(AssemblyDirectory, "openalpr.conf");
        private static string _runtimeDataDirectory = Path.Combine(AssemblyDirectory, "runtime_data");
        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static List<string> ProcessImageFile(string fileName)
        {
            List<string> result = new List<string>();

            using (AlprNet alpr = new AlprNet("eu", _configFile, _runtimeDataDirectory))
            {

                if (!alpr.IsLoaded())
                    return result;

                alpr.DefaultRegion = _localRegion;

                AlprResultsNet results = alpr.Recognize(fileName);

                foreach (AlprPlateResultNet plate in results.Plates)
                {
                    AlprPlateNet matching = plate.TopNPlates.First(p => p.MatchesTemplate);
                    if (matching != null)
                        result.Add(matching.Characters);
                }
            }
            return result;
        }
    }
}