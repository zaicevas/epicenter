using System;
using System.Collections.Generic;

// openalpr
using System.IO;
using System.Reflection;

using openalprnet;

namespace epicenterWin
{
    class PlateRecognizer
    {
        interface INumeric
        {
            int GetValue();
        }

        class ImNumeric : INumeric
        {
            public ImNumeric(int a)
            {

            }
            public int GetValue()
            {
                return 5;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public void processImageFile(string fileName)
        {
            var region = "eu";                                                       // could be us
            var configFile = Path.Combine(AssemblyDirectory, "openalpr.conf");
            var runtimeDataDirectory = Path.Combine(AssemblyDirectory, "runtime_data");

            using (var alpr = new AlprNet(region, configFile, runtimeDataDirectory))
            {
                var platesList = new List<string>();

                if (!alpr.IsLoaded())
                {
                    platesList.Add("Error starting OpenALPR");
                    return;
                }
                alpr.DefaultRegion = "lt";                                              // match @@@### pattern
                var results = alpr.Recognize(fileName);

                var i = 1;
                foreach (var result in results.Plates)
                {
                    platesList.Add("\t\t-- Plate #" + i++ + " --");
                    foreach (var plate in result.TopNPlates)
                    {
                        platesList.Add(string.Format(@"{0} {1}% {2}",
                                                          plate.Characters.PadRight(12),
                                                          plate.OverallConfidence.ToString("N1").PadLeft(8),
                                                          plate.MatchesTemplate.ToString().PadLeft(8)));
                    }
                }

                var path = @"C:\Users\ferN\plate_testing\output.txt";
                using (var tw = new StreamWriter(path, true))
                {
                    foreach (var s in platesList)
                    {
                        tw.WriteLine(s);
                    }
                }
            }
        }
    }
}
