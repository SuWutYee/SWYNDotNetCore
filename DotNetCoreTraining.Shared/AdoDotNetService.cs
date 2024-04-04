using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace DotNetCoreTraining.Shared
{
    public class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public AdoDotNetService(string connectionStr)
        {
            this.sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStr);
        }

        public List<T> Query<T>(string query, List<SqlParameter>? parameters = null)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters is not null)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();

            var json = JsonConvert.SerializeObject(dt);
            var lst = JsonConvert.DeserializeObject<List<T>>(json)!;
            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, List<SqlParameter>? parameters = null)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters is not null)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();

            var json = JsonConvert.SerializeObject(dt);
            var item = JsonConvert.DeserializeObject<T>(json)!;
            return item;
        }

        public int Execute(string query,List<SqlParameter>? parameters = null)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if(parameters is not null)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}