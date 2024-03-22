//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Threading.Tasks;

//string apiKey = "2b86b02a22740697bf800f17cc3e0c8a";
//string city = "Kazan";
//string countryCode = "RU";

//string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city},{countryCode}&appid={apiKey}&units=metric";

//using (HttpClient client = new HttpClient())
//{
//    try
//    {
//        HttpResponseMessage response = await client.GetAsync(apiUrl);
//        response.EnsureSuccessStatusCode();

//        string responseBody = await response.Content.ReadAsStringAsync();
//        Console.WriteLine(responseBody);
//        dynamic weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

//        string descrip = weatherData.Description;
//        double temp = weatherData.main.temp;
//        double feelsLike = weatherData.main.feels_like;

//        Console.WriteLine($"Сегодня погода в {city}:");
//        Console.WriteLine($"Описание {descrip}");
//        Console.WriteLine($"За окном {temp}");
//        Console.WriteLine($"Ощущается как {feelsLike}");
//    }
//    catch (HttpRequestException e)
//    {
//        Console.WriteLine($"Ошибка ппри отправке запроса: {e.Message}");
//    }
//}
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("https://catfact.ninja/fact");

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                var meow = Newtonsoft.Json.JsonConvert.DeserializeObject<CatMeow>(content);

                Console.WriteLine($"Fact: {meow.fact}"); //чета мы хз как на русский переводить
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка ппри отправке запроса: {e.Message}");
            }
        }
    }
}

public class CatMeow
{
    public string fact { get; set; }
}
