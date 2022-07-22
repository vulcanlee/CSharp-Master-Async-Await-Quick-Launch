namespace AA19_程式突然當掉_卻不知道問題在哪
{







    internal class Program
    {
        static async Task Main(string[] args)
        {
            await MethodAsync();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        static async Task MethodAsync()
        {
            await MethodTaskAsync();
            throw new NotImplementedException("喔喔，系統內部發生問題");
        }

        static Task MethodTaskAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                throw new NotImplementedException("強制拋出例外異常");
            });
        }
    }
}