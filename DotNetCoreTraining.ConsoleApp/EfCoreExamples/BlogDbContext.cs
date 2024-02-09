using DotNetCoreTraining.ConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.EfCoreExamples
{
    public class BlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnection.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
