using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherForecastClient
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = "https://localhost:5001/WeatherForecast"; // Change port if needed
            using var client = new HttpClient();

            Console.WriteLine("Fetching weather forecast...");
            var forecasts = await client.GetFromJsonAsync<WeatherForecast[]>(baseUrl);
            if (forecasts != null)
            {
                foreach (var forecast in forecasts)
                {
                    Console.WriteLine($"{forecast.Date}: {forecast.TemperatureC}C / {forecast.TemperatureF}F - {forecast.Summary}");
                }
            }
            else
            {
                Console.WriteLine("No data received.");
            }

            Console.WriteLine("Enter a string to reverse:");
            var inputString = Console.ReadLine();
            var stringResponse = await client.PostAsJsonAsync(baseUrl + "/ReverseString", inputString);
            var reversedString = await stringResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Reversed string: {reversedString}");

            Console.WriteLine("Enter an integer to reverse:");
            var inputInt = int.Parse(Console.ReadLine() ?? "0");
            var intResponse = await client.PostAsJsonAsync(baseUrl + "/ReverseInt", inputInt);
            var reversedInt = await intResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"Reversed integer: {reversedInt}");
        }
    }
}
