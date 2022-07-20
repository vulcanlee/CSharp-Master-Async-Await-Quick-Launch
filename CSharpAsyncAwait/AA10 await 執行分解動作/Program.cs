namespace AA10_await_執行分解動作
{
    internal class Program
    {
        // 因為這個方法內有使用 await 運算子，所以，在方法前面要加入 async 修飾詞
        // 而因為這個是 .NET 程式進入點，因此，回傳型別必須要為 Task
        static async Task Main(string[] args)
        {
            int foo;
            foo = 168;
            // 呼叫一個非同步方法，會取得一個 Task<int> 型別回傳值物件
            Task<int> myTask = MyMethod();

            // 透過這個工作物件可以查看非同步工作是否完成與進行封鎖式等待結果
            // 這裡將不是採用封鎖式等待的方式來等待工作完成
            int bar = await myTask;
            foo = foo + bar;
        }
        static Task<int> MyMethod()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 99;
            });
        }
    }
}