namespace AA04_APM___使用_WebRequest_類別要求資料___非同步設計
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
            // 建立呼叫 Web API 的服務端點 URL
            // 使用同步 Action 呼叫，要將兩個整數相加，休息三秒後回傳結果
            string endPoint = $"{baseURI}/add/1/3/3000";
            // 建立使用 APM 模式的 HTTP 呼叫物件 HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            // 使用 APM 模式，配合 callback 來啟動非同步呼叫，進而取得 HTTP 回應 Response
            IAsyncResult asyncResult =
                    (IAsyncResult)request.BeginGetResponse(RespSumCallback, request);

            Console.WriteLine($"因為進行非同步呼叫，此時，主執行緒可以繼續同時執行其他作業的程式碼");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        static void RespSumCallback(IAsyncResult asynchronousResult)
        {
            // 取得使用者定義的物件，這個物件符合或包含非同步作業的相關資訊
            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            // 取得此次非同步計算的結果
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
            // 取得 資料流程 stream 物件
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var sum = readStream.ReadToEnd();
            Console.WriteLine($"兩數相加={sum}");
            string endPoint = $"{baseURI}/Checksum/{sum}/5000";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            IAsyncResult asyncResult =
                    (IAsyncResult)request.BeginGetResponse(RespMD5Callback, request);
            return;
        }
        static void RespMD5Callback(IAsyncResult asynchronousResult)
        {
            // 取得使用者定義的物件，這個物件符合或包含非同步作業的相關資訊
            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            // 取得此次非同步計算的結果
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
            // 取得 資料流程 stream 物件
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var checksum = readStream.ReadToEnd();
            Console.WriteLine($"檢查碼={checksum}");
            return;
        }
    }
}