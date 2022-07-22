namespace AA23_程式不會打死結卡住___Console
{
    internal class Program
    {
        static string baseURI =
            "https://backendhol.azurewebsites.net/api/performance";
        static void Main(string[] args)
        {
            var sumTask = SumAsync(168, 89);
            var result = sumTask.Result;
            Console.WriteLine(result);
        }
        static async Task<string> SumAsync(int a, int b)
        {
            var client = new HttpClient();
            var endPoint = $"{baseURI}/add/{a}/{b}/2";
            var task = client.GetStringAsync(endPoint);
            var result = await task;
            return result;
        }
    }
}