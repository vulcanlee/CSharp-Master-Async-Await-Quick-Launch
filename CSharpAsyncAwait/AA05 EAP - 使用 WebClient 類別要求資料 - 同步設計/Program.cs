namespace AA05_EAP___使用_WebClient_類別要求資料___同步設計
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
            // 採用同步方式，封鎖等待執行結果
            var sum = client.DownloadString(endPoint);
            Console.WriteLine($"兩數相加={sum}");
            // 建立計算 MD5 檢查碼的服務端點 URL
            endPoint = $"{baseURI}/Checksum/{sum}/5000";
            // 採用同步方式，封鎖等待執行結果
            var checksum = client.DownloadString(endPoint);
            Console.WriteLine($"檢查碼={checksum}");
        }
    }
}