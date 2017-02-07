using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TWebAPI.Models;
using System.Web.Script.Serialization;

namespace Harness
{
    class Program
    {
        static void Main()
        {
            try
            {
                RunAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1961/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/pets");
                if (response.IsSuccessStatusCode)
                {
                    Pets[] pets = await response.Content.ReadAsAsync<Pets[]>();
                    foreach (Pets pet in pets)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", pet.ID, pet.Name, pet.Birthday.ToString());
                    }
                    response = await client.GetAsync("api/pets/{D1CDA7F6-7539-46B1-A4C5-F593CA8D2D8F}");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<Pets>();
                    }
                }
                else
                {
                    Console.WriteLine("Not successful: {0}, {1}", response.RequestMessage.RequestUri, response.ReasonPhrase);
                }
                // HTTP POST
                Pets cat = new Pets() { ID = Guid.NewGuid(), Name = "Oliver", Birthday = new DateTime(2008, 4, 15) };
                var json = new JavaScriptSerializer().Serialize(cat);
                response = await client.PostAsJsonAsync("api/pets", json);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post succeeded");
                }
                else
                {
                    Console.WriteLine("Post failed");
                }

                response = await client.GetAsync("api/weather");
                if (response.IsSuccessStatusCode)
                {
                    WeatherSample sample = await response.Content.ReadAsAsync<WeatherSample>();
                    if (sample is WeatherSample)
                    {
                        Console.WriteLine("Get WeatherSample succeeded");
                    }
                }

            }
        }
    }
}
