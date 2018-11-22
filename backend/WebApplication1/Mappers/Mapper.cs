using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Dapper;
using System.Reflection;
using System.Data;
using System.Data.SQLite;
using WebApplication1.Attributes.Database;
using System.Data.SqlClient;

namespace WebApplication1.Mappers
{
    public class Mapper<T>
    {
        private static string _connectionString = AppSettings.Configuration.ConnectionString;
        private static SQLiteConnectionStringBuilder _sqlConnection = new SQLiteConnectionStringBuilder(_connectionString);

        private static IDbConnection _sqliteConnect = new SQLiteConnection(_connectionString);

        readonly private static Type _typeParameter = typeof(T);
        readonly private static string _tableName = _typeParameter.Name;
        readonly private static PropertyInfo[] _propertyInfo = _typeParameter.GetProperties();

        class Person
        {
            public int ID { get; set; }
            public string FirstName { get; set; } = "AHAHATOMAS";
            public string LastName { get; set; } = "Netomas";
            public int Reason { get; set; } = 0;
        }

        public Mapper()
        {
            //string connectionStringas = _connectionString;
            _sqliteConnect.Open();
            string query = "SELECT * FROM Person";
            List<Person> all =_sqliteConnect.Query<Person>("SELECT * FROM Person", new DynamicParameters()).ToList<Person>();
            if (_sqliteConnect.State == ConnectionState.Open)
                System.Diagnostics.Debug.WriteLine("YE");
        }

        private static List<string> GetPropertyNames<A>(bool exclude) where A : Attribute
        {
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
            List<string> propertyNames = GetPropertyNames<NonDatabaseAttribute>(true);
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
                return _sqliteConnect.Query<T>($"SELECT * FROM {_tableName}", new DynamicParameters());
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
                foreach (string name in GetPropertyNames<NonDatabaseAttribute>(true))
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
            try
            {
                _sqliteConnect.Execute($"DELETE FROM {_tableName}");
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
            }
        }

        public static T ReadByKey<K>(T entity) where K : Attribute
        {
            try
            {
                string finalQuery = $"SELECT * FROM {_tableName} WHERE ";
                foreach (string name in GetPropertyNames<K>(false))
                {
                    finalQuery += name + " = @" + name + " AND ";
                }
                finalQuery = finalQuery.Substring(0, finalQuery.Length - " AND ".Length);

                System.Diagnostics.Debug.WriteLine(finalQuery);
                return _sqliteConnect.Query<T>(finalQuery, entity).First();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Exception caught in ReadByKey");
                return default(T);
            }
        }


    }
}
