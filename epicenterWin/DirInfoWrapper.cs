using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    struct DirInfoWrapper
    {
        public DirInfoWrapper(string localRegion = "lt", string configFile = "openalpr.conf", string runtimeDataDirectory = "runtime_data") : this()
        {
            LocalRegion = localRegion;
            ConfigFile = configFile;
            RuntimeDataDirectory = runtimeDataDirectory;
        }

        private static string _assemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public string LocalRegion { get; set; }

        private string _configFile;
        public string ConfigFile
        {
            get { return _configFile; }
            set
            {
                _configFile = Path.Combine(_assemblyDirectory, value);
            }
        }

        private string _runtimeDataDirectory;
        public string RuntimeDataDirectory
        {
            get
            {
                return _runtimeDataDirectory;
            }
            set {
                _runtimeDataDirectory = Path.Combine(_assemblyDirectory, value);
            }
        }

        //private static string _configFile = Path.Combine(AssemblyDirectory, "openalpr.conf");
        //private static string _runtimeDataDirectory = Path.Combine(AssemblyDirectory, "runtime_data");
    }
}
