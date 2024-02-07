using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            DataTable dt = new DataTable();
            string query = "select * from Tbl_Blog";

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"Title : {dr["BlogTitle"]}");
                Console.WriteLine($"Author : {dr["BlogAuthor"]}");
                Console.WriteLine($"Content : {dr["BlogContent"]}");
            }
        }

        public void Edit(int id)
        {
            DataTable dt = new DataTable();
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found!");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine($"Title : {dr["BlogTitle"]}");
            Console.WriteLine($"Author : {dr["BlogAuthor"]}");
            Console.WriteLine($"Content : {dr["BlogContent"]}");
        }

        public void Create(string title, string author, string content)
        {

        }

        public void Update(int id, string title, string author, string content)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
