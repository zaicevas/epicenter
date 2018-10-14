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
        private static IDbConnection _sqliteConnect = new SQLiteConnection(LoadConnectionString());

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void CreatePerson(Person person)
        {
            try
            {
                _sqliteConnect.Execute("INSERT INTO Person (FirstName, LastName, FaceID, Lost) values (@FirstName, @LastName, @FaceID, @Lost)", person);
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

        public static void UpdatePerson(Person current, Person updated)
        {
            if (current.ID != updated.ID)
            {
                System.Diagnostics.Debug.WriteLine(@"Wrong SqliteDataAccess.UpdatePerson(Person current, Person updated) query, 
                    current.ID has tomatch updated.ID");
                return;
            }
            try
            {
                _sqliteConnect.Execute(@"UPDATE Person SET FirstName = @FirstName, LastName = @LastName, FaceID = @FaceID, Lost = @Lost) 
                    WHERE ID = @ID", updated);
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

        public static void DeleteAllPerson()
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

/* Examples:
            IEnumerable<Person> allPeople = SqliteDataAccess.ReadPeople();
            foreach(Person i in allPeople)
            {
                ;
            }

    Adding to databse:
                Person Tomas = new Person()
            {
                ID = 2,
                FirstName = "Tomas",
                LastName = "Tomaitis2",
                FaceID = 1,
                Lost = 0
            };

            SqliteDataAccess.CreatePerson(Tomas);

    */
