namespace AA14_async_方法內有多個_await_練習
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string localString = "區域變數";
            int localInt = 0;
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => Thread.Sleep(1000));
            localString += localInt + 1;
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => Thread.Sleep(500));
            localString += localInt + 2;
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}