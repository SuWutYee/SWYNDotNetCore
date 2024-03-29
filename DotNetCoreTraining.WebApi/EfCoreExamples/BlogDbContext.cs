﻿using DotNetCoreTraining.WebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTraining.WebApi.EfCoreExamples
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
