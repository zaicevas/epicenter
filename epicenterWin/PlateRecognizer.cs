﻿using System;
using System.Collections.Generic;

// openalpr
using System.IO;
using System.Reflection;

using openalprnet;

namespace epicenterWin
{
    struct PlateRecognizer
    {
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

        public static List<string> processImageFile(string fileName)                            // empty
        {
            var region = "eu";                                                              // could be us
            var configFile = Path.Combine(AssemblyDirectory, "openalpr.conf");
            var runtimeDataDirectory = Path.Combine(AssemblyDirectory, "runtime_data");

            List<string> resultas = new List<string>();

            using (var alpr = new AlprNet(region, configFile, runtimeDataDirectory))
            {
                var platesList = new List<string>();

                if (!alpr.IsLoaded())
                {
                    platesList.Add("Error starting OpenALPR");
                    return resultas;
                }
                alpr.DefaultRegion = "lt";                                                  // match @@@### pattern
                var results = alpr.Recognize(fileName);

                foreach (var result in results.Plates)                                      // for every plate
                {
                    //platesList.Add("\t\t-- Plate #" + i++ + " --");
                    //foreach (var plate in result.TopNPlates)
                    //{
                    //    platesList.Add(string.Format(@"{0} {1}% {2}",
                    //                                      plate.Characters.PadRight(12),
                    //                                      plate.OverallConfidence.ToString("N1").PadLeft(8),
                    //                                      plate.MatchesTemplate.ToString().PadLeft(8)));
                    //}
                    var index = GetBestPlateIndex(result.TopNPlates);
                    Console.WriteLine("OPA1");
                    if (index != -1)
                    {
                        resultas.Add(result.TopNPlates[index].Characters);
                        Console.WriteLine("OPA");
                    }
                }

                //var path = @"C:\Users\ferN\plate_testing\output.txt";
                //using (var tw = new StreamWriter(path, true))
                //{
                //    foreach (var s in platesList)
                //    {
                //        tw.WriteLine(s);
                //    }
                //}
            }
            return resultas;
        }

        private static int GetBestPlateIndex(List<AlprPlateNet> plates)         // returns -1 if there's no match for region pattern
        {
            for (var i=0; i<plates.Count; i++)
            {
                if (plates[i].MatchesTemplate)
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
