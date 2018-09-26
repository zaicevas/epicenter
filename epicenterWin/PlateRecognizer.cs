using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// openalpr
using System.Drawing;
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
            //resetControls();
            //var region = rbUSA.Checked ? "us" : "eu";
            String region = "eu";
            String config_file = Path.Combine(AssemblyDirectory, "openalpr.conf");
            String runtime_data_dir = Path.Combine(AssemblyDirectory, "runtime_data");
            //Form1.popMessage(runtime_data_dir);
            using (var alpr = new AlprNet(region, config_file, runtime_data_dir))
            {
                var platesList = new List<String>();

                if (!alpr.IsLoaded())
                {
                    platesList.Add("Error starting OpenALPR");
                    //lbxPlates.Items.Add("Error initializing OpenALPR");
                    return;
                }
                //picOriginal.ImageLocation = fileName;
                //picOriginal.Load();

                var results = alpr.Recognize(fileName);

                //var images = new List<Image>(results.results.Count());
                var i = 1;
                foreach (var result in results.Plates)
                {
                    /*
                    List<Point> points = new List<Point>();
                    foreach (Coordinate c in result.coordinates)
                        points.Add(new Point(c.x, c.y));

                    var rect = boundingRectangle(points);
                    var img = Image.FromFile(fileName);
                    var cropped = cropImage(img, rect);
                    images.Add(cropped); */


                    platesList.Add("\t\t-- Plate #" + i++ + " --");
                    //lbxPlates.Items.Add("\t\t-- Plate #" + i++ + " --");
                    foreach (var plate in result.TopNPlates)
                    {
                        /*
                        lbxPlates.Items.Add(string.Format(@"{0} {1}% {2}",
                                                          plate.plate.PadRight(12),
                                                          plate.confidence.ToString("N1").PadLeft(8),
                                                          plate.matches_template.ToString().PadLeft(8))); */
                        platesList.Add(string.Format(@"{0} {1}% {2}",
                                                          plate.Characters.PadRight(12),
                                                          plate.OverallConfidence.ToString("N1").PadLeft(8),
                                                          plate.MatchesTemplate.ToString().PadLeft(8)));
                    }
                }
                /*
                if (images.Any())
                {
                    picLicensePlate.Image = combineImages(images);
                } */

                string path = @"C:\Users\ferN\plate_testing\output.txt";
                using (var tw = new StreamWriter(path, true))
                {
                    foreach (String s in platesList)
                    {
                        tw.WriteLine(s);
                    }
                }
            }
        }
    }
}
