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
 * FirstName
 * LastName     (can be null)
 * Missing
 * YML
 * */
    static class SqliteDataAccess<T> where T : DbEntity
    {
        private static IDbConnection _sqliteConnect = new SQLiteConnection(LoadConnectionString());

        readonly private static Type _typeParameter = typeof(T);
        readonly private static string _tableName = _typeParameter.Name;
        readonly private static PropertyInfo[] _propertyInfo = _typeParameter.GetProperties();


        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private static List<string> GetPropertyNames<A>(bool exclude) where A : Attribute
        {
            // returns List of property names which either have or DO NOT have attribute of type A, based on bool exclude
            // exclude = true -> returns all property names BUT ones who don't have attribute of type A
            List<string> names = new List<string>();
            foreach (PropertyInfo property in _propertyInfo)
            {
                bool excludeFinal = Attribute.IsDefined(property, typeof(A));
                excludeFinal = exclude ? !excludeFinal : excludeFinal;
                if (excludeFinal)
                {
                    names.Add(property.Name);
                }
            }
            return names;
        }

        private static string BuildPropertyQueryString(bool atSign)
        {
            List<string> propertyNames = GetPropertyNames<UnecessaryColumnAttribute>(true);
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
            try
            {
                string tmpQuery = BuildPropertyQueryString(false);
                string finalQuery = $"INSERT INTO {_tableName} (" + tmpQuery + ") values (";
                tmpQuery = BuildPropertyQueryString(true);
                finalQuery += tmpQuery + ")";
                System.Diagnostics.Debug.WriteLine("finalQuery: " + finalQuery);
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
                return _sqliteConnect.Query<T>($"SELECT * FROM {_tableName}", new DynamicParameters());             // not sure if typeof(T) would just work
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in ReadPeople");
                return null;
            }
        }

        public static void UpdatePerson(T entity)
        {
            try
            {
                string finalQuery = $"UPDATE {_tableName} SET ";
                foreach (string name in GetPropertyNames<UnecessaryColumnAttribute>(true))
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

        public static T ReadByCompositeKey(T entity)
        {
            try
            {
                string finalQuery = $"SELECT * FROM {_tableName} WHERE ";
                foreach (string name in GetPropertyNames<CompositeKeyAttribute>(false))
                {
                    finalQuery += name + " = @" + name + " AND ";
                }
                finalQuery = finalQuery.Substring(0, finalQuery.Length - " AND ".Length);
                System.Diagnostics.Debug.WriteLine(finalQuery);
                return _sqliteConnect.Query<T>(finalQuery, entity).First();
            }
            catch (Exception)        // InvalidOperationException for null
            {
                System.Diagnostics.Debug.WriteLine("Exception caught in ReadByCompositeKey");
                return null;
            }
        }

    }
}