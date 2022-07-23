using System.Diagnostics;

namespace AA27_壓測後端同步與非同步API
{
    internal class Program
    {
        static string APIEndPoint = "https://businessblazor.azurewebsites.net/api/RemoteService/Add/8/9/10000";
        //static string APIEndPoint = "https://businessblazor.azurewebsites.net/api/RemoteService/AddAsync/8/9/10000";
        static int 最多同時呼叫API數量 = 1;

        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            #region 大量呼叫 Web API
            List<Task<string>> tasks = new List<Task<string>>();

            for (int i = 0; i < 最多同時呼叫API數量; i++)
            {
                int idx = i;
                HttpClient client = new HttpClient();
                Task<string> task = client.GetStringAsync(APIEndPoint);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
            foreach (var item in tasks) { Console.WriteLine(item.Result); }
            #endregion

            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}