using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection.Metadata;

namespace DotNetCoreTraining.Shared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;

        public DapperService(string connectionStr)
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder(connectionStr);
        }

        public List<T> Query<T>(string query, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            List<T> lstBlog = db.Query<T>(query, parameters).ToList();
            return lstBlog;
        }

        public T QueryFirstOrDefault<T>(string query, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            T item = db.Query<T>(query, parameters).FirstOrDefault()!;
            return item;
        }

        public int Execute(string query, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db.Execute(query, parameters);
            return result;
        }
    }
}
