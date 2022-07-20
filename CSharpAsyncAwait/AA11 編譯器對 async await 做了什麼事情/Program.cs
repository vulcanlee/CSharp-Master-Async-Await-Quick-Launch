namespace AA11_編譯器對_async_await_做了什麼事情
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 採用封鎖等待來取得非同步方法的執行結果
            // 非同步方法要能夠完成執行並回傳結果，該執行緒才會繼續往下執行
            int length = MethodAsync("https://docs.microsoft.com/")
                .Result;
            System.Console.WriteLine(length);
        }

        // 這是一個有回傳值為 Task<int> 的非同步方法
        static async Task<int> MethodAsync(string baseAddress)
        {
            string url = $"{baseAddress}/zh-tw/dotnet/csharp/";
            HttpClient client = new HttpClient();
            BeforeAwait();
            // 使用 await 運算子來進行非封鎖等待執行結果
            string result = await client.GetStringAsync(url);
            AfterAwait();
            return result.Length;
        }

        private static void AfterAwait()
        {
        }

        private static void BeforeAwait()
        {
        }
    }
}