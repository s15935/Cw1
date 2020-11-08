using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var sync = await client.GetAsync(args[0]);

            if (!sync.IsSuccessStatusCode)
            {
                Console.WriteLine("Błąd połączenia");
                return;
            }

            var strings = await sync.Content.ReadAsStringAsync();

            client.Dispose();
            sync.Dispose();

            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

            var matches = regex.Matches(strings);

            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }


        }
    }
}
