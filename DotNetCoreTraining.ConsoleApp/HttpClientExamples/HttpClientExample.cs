using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async void Run()
        {
            await Read();
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7029/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseStr);
            }
        }
    }
}
