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
 * Table 'Person' has 6 columns:
 * ID
 * FaceID       matches training data labels
 * FirstName
 * LastName     (can be null)
 * Missing
 * YML
 * */
    static class SqliteDataAccess<T> where T : DbEntity
    {
        private static IDbConnection _sqliteConnect = new SQLiteConnection(LoadConnectionString());         // dapper the object mapper

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void CreateRow(T entity)
        {
            string tableName = entity.GetType().Name;
            bool person = entity is Person;
            try
            {
                int MissingInt = entity.Missing ? 1 : 0;
                string queryString = $"INSERT INTO {tableName} (FirstName, LastName, Missing, ";
                queryString += person ? $"FaceID) values (@FirstName, @LastName, {MissingInt}, @FaceID)" : $"NumberPlate) values (@FirstName, @LastName, {MissingInt}, @NumberPlate";
                System.Diagnostics.Debug.WriteLine(queryString);
                _sqliteConnect.Execute(queryString, entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in CreatePerson");
            }
        }

        public static IEnumerable<T> ReadRows()
        {
            try
            {
                return _sqliteConnect.Query<T>($"SELECT * FROM {typeof(T).GetType().Name}", new DynamicParameters());             // not sure if typeof(T) would just work
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in ReadPeople");
                return null;
            }
        }

        public static void UpdatePerson(T entity)
        {
            string tableName = entity.GetType().Name;
            bool person = entity is Person;
            try
            {
                int MissingInt = entity.Missing ? 1 : 0;
                string queryString = $"UPDATE {tableName} SET FirstName = @FirstName, LastName = @LastName, MissingInt = {MissingInt}, ";
                queryString += person ? "FaceID = @FaceID " : "NumberPlate = @NumberPlate ";
                queryString += "WHERE ID = @ID";
                _sqliteConnect.Execute(queryString, entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in UpdatePerson");
            }
        }

        public static void DeleteRow(T entity)
        {
            string tableName = entity.GetType().Name;
            try
            {
                _sqliteConnect.Execute($"DELETE FROM {tableName} WHERE ID = @ID", entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeletePerson");
            }
        }

        public static void DeleteAllRows()
        {
            // Use it with great care :)
            string tableName = typeof(T).GetType().Name;
            try
            {
                _sqliteConnect.Execute($"DELETE FROM {tableName}");
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
            }
        }

    }
}
