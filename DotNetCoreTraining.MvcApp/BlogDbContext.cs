using DotNetCoreTraining.MvcApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTraining.MvcApp
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder
        //    {
        //        DataSource = ".",
        //        InitialCatalog = "TestDb",
        //        IntegratedSecurity = true,
        //        TrustServerCertificate = true,
        //    };
        //    optionsBuilder.UseSqlServer(sqlConnection.ConnectionString);
        //}

        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<ChartModel> Charts { get; set; }
        public DbSet<PyramidModel> Pyramids { get; set; }
    }
}
