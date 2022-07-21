namespace AA16_非同步_Task_在執行中_不一定會用到執行緒的範例
{
    internal class Program
    {
        static string endPoint =
                 "https://backendhol.azurewebsites.net/api/DoAsyncWork/";
        static async Task Main(string[] args)
        {
            // 宣告一個集合物件，儲存這五個非同步工作物件
            List<Task<string>> allTasks = new();
            for (int i = 0; i < 5; i++)
            {
                var client = new HttpClient();
                var newEndPoint = $"{endPoint}/{5000 + i * 300}";
                // 取得使用 HttpClient 呼叫遠端 Web API 的非同步工作物件
                // 這裡的工作物件屬於 I/O Bound 密集的非同步工作
                var task = client.GetStringAsync(newEndPoint);
                var continueTask = task.ContinueWith(t =>
                {
                    // 在這裡設定中斷點，觀察 [執行緒] / [工作] 視窗內容
                    // 觀察是否有使用到執行緒
                    var checkBreakPoint = 100;
                });
                allTasks.Add(task);
            }

            // 主執行緒強制休息一秒鐘，讓非同步工作已經順利開始執行了
            await Task.Delay(1000);
            // 在這裡設定中斷點，觀察 [執行緒] / [工作] 視窗內容
            // 觀察是否有使用到執行緒
            var checkBreakPoint = 100;
            Thread.Sleep(10000);
        }
    }
}