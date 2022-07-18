namespace AA01_體驗_非同步工作_與_非同步方法_的不同
{
    internal class Program
    {
        // 這個 Main 方法原先回傳值宣告為 void
        // 因為在其 Main 方法內有用到 await 運算子
        // 所以，在 Main 方法前面要將 void 改成 async Task
        // 這樣才不會造成在 Main 方法內遇到 await 的時候
        // 造成這個處理程序立即結束的窘境
        static async Task Main(string[] args)
        {
            // 呼叫 同步 方法
            MySyncMethod();

            // 呼叫 TAP 方法
            await GetMyTapAsync();

            // 呼叫 async 非同步方法
            await GetMyAsyncMethodAsync();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        #region 同步、非同步工作、非同步方法
        // 這是一般的同步方法
        public static void MySyncMethod()
        {
            Console.WriteLine("正在執行同步方法");
            // 模擬這個方法要工作一段時間
            Thread.Sleep(1000);
        }

        // 這是一個 asynchronous task 非同步工作
        public static Task GetMyTapAsync()
        {
            Console.WriteLine("正在執行非同步工作");
            return Task.Run(MySyncMethod);
        }

        // 這是一個 async methods 非同步方法
        // 因為這裡用到了 async await
        public static async Task GetMyAsyncMethodAsync()
        {
            Console.WriteLine("正在執行非同步方法");
            await Task.Run(MySyncMethod); return;
        }
        #endregion
    }
}