using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Futarok;
using System.Net.Http;

namespace Futarok
{
    internal class Program
    {
        static Futar futar = null;
        static async Task Main(string[] args)
        {
            int fazon = 0;
            string fnev = "fnev";
            string ftel = "ftel";
            await futarokNyilvantartasa(fazon, fnev, ftel);
            Console.WriteLine($"{futar.Fazon.ToString().Length}. Futár azonosítója: {fazon} + Futár telefonszáma: {ftel} + Futár neve: {fnev}");
            Console.ReadLine();
        }

        private static async Task<List<Futar>> futarokNyilvantartasa(int fazon, string fnev, string ftel)
        {
            List<Futar> futar = new List<Futar>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost/Futarok/index.php?futarok/ + {fazon} + {fnev} + {ftel}");
            var response = await client.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                futar = Futar.FromJson(jsonString).ToList();
            }
            return futar;


        }
    }
}
