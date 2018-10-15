using System;
using System.Collections.Generic;

using System.IO;
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
                    AlprPlateNet matching = GetMatchingPlate(plate.TopNPlates);
                    if (matching != null)
                    {
                        result.Add(matching.Characters);
                    }
                }
            }
            return result;
        }

        private static AlprPlateNet GetMatchingPlate(List<AlprPlateNet> plates)
        {
            foreach (AlprPlateNet plate in plates)
                if (plate.MatchesTemplate)
                    return plate;

            return null;
        }


    }
}