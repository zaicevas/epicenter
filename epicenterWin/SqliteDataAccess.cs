using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;                 // ConfigurationManager
using System.Data;                          // IDbConnection
using System.Data.SQLite;
using Dapper;
using System.Reflection;

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

        private static Type _typeParameter = typeof(T);
        private static string _tableName = _typeParameter.Name;
        private static PropertyInfo[] _propertyInfo = _typeParameter.GetProperties();

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private static List<string> GetPropertyNames()
        {
            List<string> names = new List<string>();
            foreach (PropertyInfo property in _propertyInfo)
            {
                if (property.Name != "ID")
                {
                    names.Add(property.Name);
                }
            }
            return names;
        }

        private static string BuildPropertyQueryString(bool atSign)         
        {
            List<string> propertyNames = GetPropertyNames();
            string endQuery = "";
            foreach (string name in propertyNames)
            {
                endQuery += (atSign ? "@" : "") + name + ", ";
            }
            endQuery = endQuery.Substring(0, endQuery.Length - 2);      // remove ", " after last property name
            return endQuery;
        }

        public static void CreateRow(T entity)
        {
            bool person = entity is Person;
            try
            {
                string tmpQuery = BuildPropertyQueryString(false);
                string finalQuery = $"INSERT INTO {_tableName} (" + tmpQuery + ") values (";
                tmpQuery = BuildPropertyQueryString(true);
                finalQuery += tmpQuery;
                _sqliteConnect.Execute(finalQuery, entity);
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
            bool person = entity is Person;
            try
            {
                string tmpQuery = BuildPropertyQueryString(false);
                string finalQuery = $"UPDATE {_tableName} SET ";
                foreach(string name in GetPropertyNames())
                {
                    finalQuery += name + " = @" + name + ", ";
                }
                finalQuery = finalQuery.Substring(0, finalQuery.Length - 2);
                finalQuery += " WHERE ID = @ID";
                _sqliteConnect.Execute(finalQuery, entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in UpdatePerson");
            }
        }

        public static void DeleteRow(T entity)
        {
            try
            {
                _sqliteConnect.Execute($"DELETE FROM {_tableName} WHERE ID = @ID", entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeletePerson");
            }
        }

        public static void DeleteAllRows()
        {
            // Use it with great care :)
            try
            {
                _sqliteConnect.Execute($"DELETE FROM {_tableName}");
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
            }
        }

    }
}
