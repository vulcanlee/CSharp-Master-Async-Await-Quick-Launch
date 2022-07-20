namespace AA06_EAP___使用_WebClient_類別要求資料___非同步設計
{
    using System;
    using System.Net;

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
            WebClient client = new WebClient();
            // 綁定等下非同步作業完成後(也許是成功、失敗或者是取消)要觸發的委派事件處理常式
            client.DownloadStringCompleted += OnGetSumCompleted;
            // 啟動兩個整數相加的非同步呼叫
            client.DownloadStringAsync(new Uri(endPoint));

            // 由於採用 非同步呼叫，因此，在此執行緒下，可以繼續執行其他程式碼
            // ...

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        // 兩數相加非同步作業的事件處理常式
        private static void OnGetSumCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // 讀取非同步作業的執行結果
            var sum = e.Result;
            Console.WriteLine($"兩數相加={sum}");

            // 在此 callback 內，繼續準備進行下一個非同步作業
            string endPoint = $"{baseURI}/Checksum/{sum}/5000";
            WebClient client = new WebClient();
            client.DownloadStringCompleted += OnGetChecksumCompleted;
            // 啟動另外一個非同步作業
            client.DownloadStringAsync(new Uri(endPoint));
        }

        // 計算 MD5 檢查碼的非同步作業的事件處理常式
        static void OnGetChecksumCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var checksum = e.Result;
            Console.WriteLine($"檢查碼={checksum}");
        }
    }
}