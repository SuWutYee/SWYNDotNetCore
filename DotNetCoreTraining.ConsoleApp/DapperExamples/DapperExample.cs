using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetCoreTraining.ConsoleApp.Models;
using System.Runtime.CompilerServices;

namespace DotNetCoreTraining.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            IntegratedSecurity = true
        };

        public void Read()
        {
            string query = "select * from Tbl_Blog";

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lstBlog = db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lstBlog)
            {
                Console.WriteLine($"Title : {item.BlogTitle}");
                Console.WriteLine($"Author : {item.BlogAuthor}");
                Console.WriteLine($"Content : {item.BlogContent}");
            }
        }

        public void Edit(int id)
        {
            DataTable dt = new DataTable();
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault();

            if (item == null)
            {
                Console.WriteLine("No data found!");
                return;
            }

            Console.WriteLine($"Title : {item.BlogTitle}");
            Console.WriteLine($"Author : {item.BlogAuthor}");
            Console.WriteLine($"Content : {item.BlogContent}");
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                               ([BlogTitle]
                               ,[BlogAuthor]
                               ,[BlogContent])
                         VALUES
                               (@BlogTitle
                               ,@BlogAuthor
                               ,@BlogContent)";

            BlogModel blogModel = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blogModel);

            var message = result == 0 ? "Create Fail!" : "Create Success.";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE [BlogId] = @BlogId";

            BlogModel blogModel = new BlogModel
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blogModel);

            var message = result == 0 ? "Edit Fail!" : "Edit Success.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE [BlogId] = @BlogId";

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, new { BlogId = id });

            var message = result == 0 ? "Delete Fail!" : "Delete Success.";
            Console.WriteLine(message);
        }
    }
}
