// See https://aka.ms/new-console-template for more information
using DotNetCoreTraining.ConsoleApp.AdoDotNetExamples;

Console.WriteLine("Hello, World!");

#region Ado Dot Net Example 

AdoDotNetExample ado = new AdoDotNetExample();
ado.Read();
ado.Edit(3);
ado.Create("testTitle", "testAuthor", "testContent");
ado.Update(2, "testTitle1", "testAuthor1", "testContent1");
ado.Delete(3);

#endregion
