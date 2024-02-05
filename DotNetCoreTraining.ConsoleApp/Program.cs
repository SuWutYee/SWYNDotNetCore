// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

DataTable dt = new DataTable();
string query = "select * from Tbl_Blog";

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "TestDb";
sqlConnectionStringBuilder.IntegratedSecurity = true;
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
sqlConnection.Open();
SqlCommand cmd = new SqlCommand(query,sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
adapter.Fill(dt);
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"Title : {dr["BlogTitle"]} >>> Author : {dr["BlogAuthor"]} >>> Content : {dr["BlogContent"]}" );
}
sqlConnection.Close();

