// See https://aka.ms/new-console-template for more information
using RestWoodPellets.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();

GetAsync(client).Wait();
PostAsync(client).Wait();
GetAsync(client).Wait();

static async Task GetAsync (HttpClient myHttpClient)
{

    HttpResponseMessage Response = await myHttpClient.GetAsync("http://localhost:5287/api/WoodPallets1");
    
    Response.EnsureSuccessStatusCode();

    var jasonResponse = await Response.Content.ReadAsStringAsync();
    Console.WriteLine($"{jasonResponse}\n");


}

static async Task PostAsync (HttpClient myHttpClient)
{
    WoodPallet wp = new WoodPallet() { Id = 6, Brand = "B6", Price = 400, Quality = 5 };
    using JsonContent content = JsonContent.Create(wp);
    HttpResponseMessage Response = await myHttpClient.PostAsync("http://localhost:5287/api/WoodPallets1", content);
}



