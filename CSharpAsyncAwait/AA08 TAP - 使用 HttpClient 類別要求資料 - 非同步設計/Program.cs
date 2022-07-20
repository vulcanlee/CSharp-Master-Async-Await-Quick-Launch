namespace AA08_TAP___使用_HttpClient_類別要求資料___非同步設計
{
    using System;
    using System.Net.Http;

    public class Program
    {
        static string baseURI =
        "https://backendhol.azurewebsites.net/api/performance";
        static void Main(string[] args)
        {
            // 建立呼叫 Web API 的服務端點 URL
            // 使用同步 Action 呼叫，要將兩個整數相加，休息三秒後回傳結果
            string endPoint = $"{baseURI}/add/1/3/3000";
            // 建立使用 WebClient 物件，以便等下取得 HTTP 回應
            HttpClient client = new HttpClient();
            // 使用 TPL 來啟動非同步作業，並且取得此非同步作業的 Task 物件
            var taskSum = client.GetStringAsync(endPoint);
            // 宣告當此非同步作業完成後(也許是成功、失敗或者是取消)，繼續這裡委派方法
            taskSum.ContinueWith(OnSumContinue);

            // 由於採用 非同步呼叫，因此，在此執行緒下，可以繼續執行其他程式碼
            // ...

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        // 兩數相加非同步作業的事件處理常式
        private static void OnSumContinue(System.Threading.Tasks.Task<string> task)
        {
            // 讀取非同步作業的執行結果
            var sum = task.Result;
            Console.WriteLine($"兩數相加={sum}");
            string endPoint = $"{baseURI}/Checksum/{sum}/5000";
            HttpClient client = new HttpClient();
            // 啟動另外一個非同步 TPL 作業
            var taskchecksum = client.GetStringAsync(endPoint);
            // 宣告當此非同步作業完成後(也許是成功、失敗或者是取消)，繼續這裡委派方法
            taskchecksum.ContinueWith(OnChecksumContinue);
        }

        // 計算 MD5 檢查碼的非同步作業的事件處理常式
        private static void OnChecksumContinue(System.Threading.Tasks.Task<string> task)
        {
            // 讀取非同步作業的執行結果
            var checksum = task.Result;
            Console.WriteLine($"檢查碼={checksum}");
        }
    }
}