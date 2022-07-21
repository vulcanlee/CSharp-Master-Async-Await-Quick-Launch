namespace AA13_反組譯_查看_迭代器_Iterator_實作作法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int number in SomeNumbers())
            {
                Console.Write(number.ToString() + " ");
            }
            // Output: 3 5 8
            Console.ReadKey();
        }
        public static System.Collections.IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }
    }
}