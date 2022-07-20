namespace AA12_探究編譯器對程式碼做了哪些改變與產生甚麼程式碼
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string answer = await MyMethodAsync(123);
            Console.WriteLine(answer);
        }
        static async Task<string> MyMethodAsync(int myInt)
        {
            string myString = "Begin";
            string result = await new HttpClient().GetStringAsync(
              "https://lobworkshop.azurewebsites.net/api/" +
              "RemoteSource/Add/8/9/2");
            myString = "Complete" + myInt + " " + result;
            return myString;
        }
    }
}