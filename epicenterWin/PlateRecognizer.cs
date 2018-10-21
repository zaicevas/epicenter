using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Reflection;

using openalprnet;

namespace epicenterWin
{
    public class PlateRecognizer
    {
        private DirInfoWrapper _directoryInfo = new DirInfoWrapper(localRegion: "lt", configFile: "openalpr.conf", runtimeDataDirectory: "runtime_data");

        public List<string> ProcessImageFile(string fileName)
        {
            List<string> result = new List<string>();

            using (AlprNet alpr = new AlprNet("eu", _directoryInfo.ConfigFile, _directoryInfo.RuntimeDataDirectory))
            {

                if (!alpr.IsLoaded())
                    return result;

                alpr.DefaultRegion = _directoryInfo.LocalRegion;

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