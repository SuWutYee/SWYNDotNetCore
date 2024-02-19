// See https://aka.ms/new-console-template for more information
using DotNetCoreTraining.ConsoleApp.AdoDotNetExamples;
using DotNetCoreTraining.ConsoleApp.DapperExamples;
using DotNetCoreTraining.ConsoleApp.EfCoreExamples;
using DotNetCoreTraining.ConsoleApp.HttpClientExamples;

Console.WriteLine("Hello, World!");

#region Ado Dot Net Example 

//AdoDotNetExample ado = new AdoDotNetExample();
//ado.Read();
//ado.Edit(3);
//ado.Create("testTitle", "testAuthor", "testContent");
//ado.Update(6, "testTitle2", "testAuthor2", "testContent2");
//ado.Delete(4);

#endregion

#region Dapper Example

//DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Edit(1);
//dapper.Create("testTitle1", "testAuthor1", "testContent1");
//dapper.Update(1, "testTitle2", "testAuthor2", "testContent2");
//dapper.Delete(2);

#endregion

#region Ef Core Examples

//EfCoreExample dbo = new EfCoreExample();
//dbo.Read();
//dbo.Edit(1);
//dbo.Create("testTitle3", "testAuthor3", "testContent3");
//dbo.Update(5, "testTitle5", "testAuthor5", "testContent5");
//dbo.Delete(7);

#endregion

#region HttpClient Examples

HttpClientExample httpClient = new HttpClientExample();
httpClient.Run();

#endregion