using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace fetchDotnet;

class Program
{
    static async Task Main(string[] args)
    {
        var program = new Program();
        await program.GetData();
    }

    public async Task GetData(){
        var client = new HttpClient();

        try{
            var response = await client.GetAsync("https://www.localhost:8080/api/");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(content);

            foreach(var item in data){
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        catch(HttpRequestException e){
            Console.WriteLine($"\nException Caught!");
            Console.WriteLine($"Message {0}", e.Message);
        }
    }
}