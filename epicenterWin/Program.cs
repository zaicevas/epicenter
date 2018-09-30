using System;

namespace epicenterWin
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var db = new PlateDatabase();
            foreach (var plate in db)
            {
                Console.WriteLine(plate);
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
