using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _3_7_dars;

internal class Program
{
    static void Main(string[] args)
    {
        // => 

        //Action<int, int> act1 = (int a, int b) => Console.WriteLine($"+ : {a + b}");
        //act1 += (int a, int b) => Console.WriteLine($"* : {a * b}");
        //act1 += (int a, int b) => Console.WriteLine($"- : {a - b}");
        //act1 += (int a, int b) => Console.WriteLine($"/ : {a / b}");

        //act1.Invoke(8, 2);


        //var func = (int a, int b) =>
        //{
        //    a = 2 * a;
        //    b = 2 * b;
        //    return (a + b).ToString();
        //};


        //var f1 = (string name) => $"Hello {name}";
        //var f2 = (string name) =>
        //{
        //    return $"Hello {name}";
        //};

        //string res = func.Invoke(5, 6);

        //var action = (int a, int b) =>
        //{
        //    a = 2 * a;
        //    b = 2 * b;
        //    Console.WriteLine(a+b);
        //};



        var ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        Func<int, bool> predicate = n => n % 2 == 0;

        var sonlar = ints.Where(n => n % 2 == 0).ToList(); 

        foreach(var s in sonlar)
        {
            Console.WriteLine(s);
        }

    }
}
