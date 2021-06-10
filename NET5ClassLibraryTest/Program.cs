using System;
using NET5ClassLibraryInterface;

namespace NET5ClassLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Class1.GetInt());
            Console.ReadKey();
            Console.WriteLine(Class1.GetDouble());
            Console.ReadKey();
            Console.WriteLine("Test is OK!");
        }
    }
}
