namespace AA03_APM___使用_WebRequest_類別要求資料___同步設計
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    public class Program
    {
        static string baseURI =
        "https://backendhol.azurewebsites.net/api/performance";
        static void Main(string[] args)
        {
            #region 呼叫 Web API 來計算兩個整數的相加結果
            // 建立呼叫 Web API 的服務端點 URL
            // 使用同步 Action 呼叫，要將兩個整數相加，休息三秒後回傳結果
            string endPoint = $"{baseURI}/add/1/3/3000";
            // 建立使用 APM 模式的 HTTP 呼叫物件 HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            // 取得 HTTP 回應 Response
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            // 取得 HTTP 回應的串流 Stream 內容
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            // 讀取串流內容
            var sum = readStream.ReadToEnd();
            Console.WriteLine($"兩數相加={sum}"); 
            #endregion

            #region 呼叫 Web API 來產生 MD5 檢查碼的範例
            // 這裡的程式碼將會接續上面取得的整數相加結果，繼續往下運算
            endPoint = $"{baseURI}/Checksum/{sum}/5000";
            request = (HttpWebRequest)WebRequest.Create(endPoint);
            webResponse = (HttpWebResponse)request.GetResponse();
            responseStream = webResponse.GetResponseStream();
            readStream = new StreamReader(responseStream, Encoding.UTF8);
            var checksum = readStream.ReadToEnd();
            Console.WriteLine($"檢查碼={checksum}");
            #endregion

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}