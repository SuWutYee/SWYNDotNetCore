using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace DotNetCoreTraining.Shared
{
    public class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public AdoDotNetService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            this.sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        public List<T> Read<T>(string query)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();

            var json = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<List<T>>(json)!;

        }
    }
}