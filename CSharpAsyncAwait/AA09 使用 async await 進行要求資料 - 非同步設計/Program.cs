namespace AA09_使用_async_await_進行要求資料___非同步設計
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Program
    {
        static string baseURI =
        "https://backendhol.azurewebsites.net/api/performance";
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string endPoint = $"{baseURI}/add/1/3/3000";
            var sum = await client.GetStringAsync(endPoint);
            Console.WriteLine($"兩數相加={sum}");
            endPoint = $"{baseURI}/Checksum/{sum}/5000";
            var checksum = await client.GetStringAsync(endPoint);
            Console.WriteLine($"檢查碼={checksum}");
        }
    }
}
