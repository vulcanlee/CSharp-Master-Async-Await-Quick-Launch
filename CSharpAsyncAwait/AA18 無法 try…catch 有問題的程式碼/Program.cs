namespace AA18_無法_try_catch_有問題的程式碼
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MethodAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        static async void MethodAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                throw new ArgumentNullException("引數空值例外異常產生了");
            });
        }
    }
}