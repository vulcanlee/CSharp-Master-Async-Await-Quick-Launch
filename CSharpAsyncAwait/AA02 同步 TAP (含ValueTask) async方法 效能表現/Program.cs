using System.Diagnostics;

namespace AA02_同步_TAP__含ValueTask__async方法_效能表現
{
    /// <summary>
    /// 透過執行效能的角度來觀看，同步方法 、 TAP 方法 (也包含 ValueTask) 、 
    /// async 方法 ，這三者間的執行效能的差異
    /// 
    /// 請試著將同步方法 (GetMySyncAsync()) 內的註解解除，說明執行結果
    /// </summary>
    public class Program
    {
        static async Task Main(string[] args)
        {
            const int ITERS = 10_000_000;
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (true)
            {
                stopwatch.Restart();
                for (int i = 0; i < ITERS; i++) GetMySyncAsync();
                var SyncMethodTime = stopwatch.Elapsed;

                stopwatch.Restart();
                for (int i = 0; i < ITERS; i++) GetMyTapAsync();
                var TapMethodTime = stopwatch.Elapsed;

                stopwatch.Restart();
                for (int i = 0; i < ITERS; i++) GetMyAsyncMethodAsync();
                var AsyncMethodTime = stopwatch.Elapsed;

                stopwatch.Restart();
                for (int i = 0; i < ITERS; i++) GetMyValueTaskAsync();
                var TapMethodValueTaskTime = stopwatch.Elapsed;

                Console.WriteLine($"Sync Method           : {SyncMethodTime}");
                Console.WriteLine($"TAP Method            : {TapMethodTime}");
                Console.WriteLine($"TAP Value Task Method : {TapMethodValueTaskTime}");
                Console.WriteLine($"Async Method            {AsyncMethodTime}");
                Console.WriteLine($"Sync           vs Async -- {AsyncMethodTime.TotalSeconds / SyncMethodTime.TotalSeconds:F1}x --");
                Console.WriteLine($"TAP            vs Async -- {AsyncMethodTime.TotalSeconds / TapMethodTime.TotalSeconds:F1}x --");
                Console.WriteLine($"TAP Value Task vs Async -- {AsyncMethodTime.TotalSeconds / TapMethodValueTaskTime.TotalSeconds:F1}x --");
                Console.ReadLine();
            }
        }

        // 同步方法
        public static void GetMySyncAsync()
        {
            // 若解除底下這一行，看看 同步 sync 方法 與 非同步 async 方法 執行後有何不同呢？
            // for (int i = 0; i < 18; i++) { }
            return;
        }

        // 非同步工作 / TAP 方法
        public static Task GetMyTapAsync()
        {
            return Task.FromResult(0);
        }

        // 非同步工作 / TAP 方法 (採用 ValueTask)
        public static ValueTask<int> GetMyValueTaskAsync()
        {
            return ValueTask.FromResult(0);
        }

        // 非同步方法
        public static async Task GetMyAsyncMethodAsync()
        {
            return;
        }
    }
}