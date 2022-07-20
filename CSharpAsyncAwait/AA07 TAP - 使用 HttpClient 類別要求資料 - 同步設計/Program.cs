namespace AA07_TAP___使用_HttpClient_類別要求資料___同步設計
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
            // 啟動兩個整數相加的同步呼叫，並直接取得執行結果內容
            var sum = client.GetStringAsync(endPoint).Result;
            Console.WriteLine($"兩數相加={sum}");
            endPoint = $"{baseURI}/Checksum/{sum}/5000";
            // 啟動計算 MD5 檢查碼的同步呼叫，，並直接取得執行結果內容
            var checksum = client.GetStringAsync(endPoint).Result;
            Console.WriteLine($"檢查碼={checksum}");
        }
    }
}