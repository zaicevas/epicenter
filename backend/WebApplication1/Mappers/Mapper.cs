using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Dapper;
using System.Reflection;
using System.Data;
using System.Data.SQLite;
using WebApplication1.Infrastructure.Attributes.Database;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Mappers
{
    public class Mapper<T> : IDisposable where T : Model
    {
        private readonly static string _connectionString = AppSettings.Configuration.ConnectionString;
        private Lazy<IDbConnection> _sqliteConnect = new Lazy<IDbConnection>(() => new SQLiteConnection(_connectionString));
        private IDbConnection SqliteConnect
        {
            get { return _sqliteConnect.Value; }
        }

        readonly private static Type _typeParameter = typeof(T);
        readonly private static string _tableName = _typeParameter.Name;
        readonly private static PropertyInfo[] _propertyInfo = _typeParameter.GetProperties();

        private List<string> GetPropertyNames<A> (bool exclude) where A : Attribute
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

        private string BuildPropertyQueryString(bool atSign)
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

        public void CreateRow(T entity)
        {
            try
            {
                string tmpQuery = BuildPropertyQueryString(false);
                string finalQuery = $"INSERT INTO {_tableName} (" + tmpQuery + ") values (";
                tmpQuery = BuildPropertyQueryString(true);
                finalQuery += tmpQuery + ")";
                System.Diagnostics.Debug.WriteLine("finalQuery: " + finalQuery);
                SqliteConnect.Execute(finalQuery, entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in CreatePerson");
            }
        }

        public IEnumerable<T> ReadRows()
        {
            try
            {
                return SqliteConnect.Query<T>($"SELECT * FROM {_tableName}", new DynamicParameters());
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in ReadPeople");
                return null;
            }
        }

        public void Update(T entity)
        {
            try
            {
                string finalQuery = $"UPDATE {_tableName} SET ";
                foreach (string name in GetPropertyNames<NonDatabaseAttribute>(true))
                {
                    finalQuery += name + " = @" + name + ", ";
                }
                finalQuery = finalQuery.Substring(0, finalQuery.Length - 2);
                string idProperty = GetPropertyNames<IDAttribute>(false).First();
                finalQuery += $" WHERE {idProperty} = @{idProperty}";
                SqliteConnect.Execute(finalQuery, entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in UpdatePerson");
            }
        }

        public void DeleteRow(T entity)
        {
            try
            {
                string idProperty = GetPropertyNames<IDAttribute>(false).First();
                SqliteConnect.Execute($"DELETE FROM {_tableName} WHERE {idProperty} = @{idProperty}", entity);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeletePerson");
            }
        }

        public void DeleteAllRows()
        {
            try
            {
                SqliteConnect.Execute($"DELETE FROM {_tableName}");
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
            }
        }

        public T ReadByID(int id)
        {
            string finalQuery = $"SELECT * FROM {_tableName} WHERE ";
            string idProperty = GetPropertyNames<IDAttribute>(false).First();
            finalQuery += $"{idProperty} = {id}";
            try
            {
                var list = SqliteConnect.Query<T>(finalQuery, new DynamicParameters());
                if (list.Count() > 0)
                    return list.First();
                return default(T);
            }
            catch (SQLiteException)
            {
                System.Diagnostics.Debug.WriteLine("SQLiteException caught in DeleteAllPerson");
                return default(T);
            }
        }

        public T ReadByKey<K>(T entity) where K : Attribute
        {
            // Use this for complex keys, for example when you want to get row by Composite key
            // This method looks for properties with attribute K and matches them with database entities
            try
            {
                string finalQuery = $"SELECT * FROM {_tableName} WHERE ";
                foreach (string name in GetPropertyNames<K>(false))
                {
                    finalQuery += name + " = @" + name + " AND ";
                }
                finalQuery = finalQuery.Substring(0, finalQuery.Length - " AND ".Length);

                System.Diagnostics.Debug.WriteLine(finalQuery);
                var list = SqliteConnect.Query<T>(finalQuery, entity);
                if (list.Count() > 0)
                    return list.First();
                return default(T);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Exception caught in ReadByKey");
                return default(T);
            }
        }

        public void Dispose(){
            SqliteConnect.Dispose();
        }
    }
}
