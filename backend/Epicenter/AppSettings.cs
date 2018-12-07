namespace Epicenter
{
    public class AppSettings
    {
        public static AppSettings Configuration;

        public string ConnectionString { get; set; }
        public string PlateAPIEndpoint { get; set; }
        public string PlatePattern { get; set; }
        public string GroupID { get; set; }
        public string AlprKey { get; set; }
        public string FaceKey { get; set; }
        public string FaceAPIEndpoint { get; set; }
        public string MainLogFileName { get; set; }

        public AppSettings()
        {
            Configuration = this;
        }
    }
}
