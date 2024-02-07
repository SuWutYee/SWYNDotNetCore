// See https://aka.ms/new-console-template for more information
using DotNetCoreTraining.ConsoleApp.AdoDotNetExamples;

Console.WriteLine("Hello, World!");

#region Ado Dot Net Example 

AdoDotNetExample ado = new AdoDotNetExample();
//ado.Read();
//ado.Edit(3);
ado.Create("testTitle", "testAuthor", "testContent");
ado.Update(6, "testTitle2", "testAuthor2", "testContent2");
ado.Delete(4);

#endregion

#region Dapper Example

#endregion