using DotNetCoreTraining.MvcApp;
using DotNetCoreTraining.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
opt.JsonSerializerOptions.PropertyNamingPolicy = null
);

// Database Context 
builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    //SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder
    //{
    //    DataSource = ".",
    //    InitialCatalog = "TestDb",
    //    IntegratedSecurity = true,
    //    TrustServerCertificate = true,
    //};
    //opt.UseSqlServer(sqlConnection.ConnectionString);

    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped(n => new AdoDotNetService(builder.Configuration.GetConnectionString("DbConnection")!));
builder.Services.AddScoped(n => new DapperService(builder.Configuration.GetConnectionString("DbConnection")!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
