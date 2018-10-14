using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;                 // ConfigurationManager
using System.Data;                          // IDbConnection
using System.Data.SQLite;
using Dapper;

namespace epicenterWin
{
    /*
 * Table 'Person' has 5 columns:
 * ID
 * FaceID       matches training data labels
 * FirstName
 * LastName     (can be null)
 * Lost
 * */
    static class SqliteDataAccess
    {
        private static IDbConnection _sqliteConnect = new SQLiteConnection(LoadConnectionString());         // dapper the object mapper

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void CreatePerson(Person person)
        {
            try
            {
                int LostInt = person.Lost ? 1 : 0;
                _sqliteConnect.Execute($"INSERT INTO Person (FirstName, LastName, FaceID, Lost) values (@FirstName, @LastName, @FaceID, {LostInt}", person);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in CreatePerson");
            }
        }

        public static IEnumerable<Person> ReadPeople()
        {
            try
            {
                return _sqliteConnect.Query<Person>("SELECT * FROM Person", new DynamicParameters());
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in ReadPeople");
                return null;
            }
        }

        public static void UpdatePerson(Person person)
        {
            try
            {
                int LostInt = person.Lost ? 1 : 0;
                _sqliteConnect.Execute($@"UPDATE Person SET FirstName = @FirstName, LastName = @LastName, FaceID = @FaceID, Lost = {LostInt}) 
                    WHERE ID = @ID", person);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in UpdatePerson");
            }
        }

        public static void DeletePerson(Person person)
        {
            try
            {
                _sqliteConnect.Execute("DELETE FROM Person WHERE ID = @ID", person);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeletePerson");
            }
        }

        public static void DeleteAllPersons()
        {
            // Use it with great care :)
            try
            {
                _sqliteConnect.Execute("DELETE FROM Person");
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
            }
        }

    }
}
