namespace AA20_為何會拋出不同例外異常
{
    // 範例碼使用說明
    // 這裡將會有兩種例外異常的檢測程式碼 ，分別為
    // #region 使用 await 運算子 時候，拋出例外異常 ... #endregion
    // 與
    // #region 使用 Wait() 方法 時候，拋出例外異常 ... #endregion
    // 想要檢測哪種情境，就將那段 #region ... #endregion 內的程式碼解除註解即可來執行
    internal class Program
    {
        #region 使用 await 運算子 時候，拋出例外異常
        static async Task Main(string[] args)
        {
            try
            {
                await MethodAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
            Console.WriteLine("Press any...");
            Console.ReadKey();
        }
        static async Task MethodAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                throw new ArgumentNullException("引數空值");
            });
        }
        #endregion

        #region 使用 Wait() 方法 時候，拋出例外異常
        static async Task Main(string[] args)
        {
            try
            {
                MethodAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
            Console.WriteLine("Press any...");
            Console.ReadKey();
        }
        static async Task MethodAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                throw new ArgumentNullException("引數空值");
            });
        }
        #endregion
    }
}