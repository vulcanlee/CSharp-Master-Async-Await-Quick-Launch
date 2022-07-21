#define 同步方法
//#define 空的非同步方法
//#define 立即返回非同步方法

namespace AA15_在_async_方法內沒有使用_await_效能分析
{
    using System.Diagnostics;

    class Program
    {
#if 同步方法
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                string foo = 同步方法();
            }
            sw.Stop();
            double cost = sw.Elapsed.TotalMilliseconds / 1000.0;
            Console.WriteLine($"呼叫 1000 次 同步方法 的平均花費時間 : {cost} ms");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        // 底下是一個 同步方法
        static string 同步方法()
        {
            return "同步方法";
        }
#elif 空的非同步方法
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                string foo = await 空的非同步方法();
            }
            sw.Stop();
            double cost = sw.Elapsed.TotalMilliseconds / 1000.0;
            Console.WriteLine($"呼叫 1000 次 同步方法 的平均花費時間 : {cost} ms");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        // 底下是一個 非同步方法 ，方法內僅有一個立即返回敘述
        static async Task<string> 空的非同步方法()
        {
            return "同步方法";
        }
#elif 立即返回非同步方法
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                string foo = await 立即返回非同步方法();
            }
            sw.Stop();
            double cost = sw.Elapsed.TotalMilliseconds / 1000.0;
            Console.WriteLine($"呼叫 1000 次 同步方法 的平均花費時間 : {cost} ms");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        // 底下是一個 也是一個非同步方法，不過會先呼叫 await 後，再返回
        static async Task<string> 立即返回非同步方法()
        {
            await Task.Yield();
            return "同步方法";
        }
#endif
    }
}