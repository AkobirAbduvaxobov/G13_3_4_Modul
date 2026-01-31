using System.Collections;

namespace _3._1_dars;

internal class Program
{
    static void Main(string[] args)
    {
        MyList myList = new MyList(3);
        myList.Add(77);
        myList.Add(71);
        myList.Add(73);
        Console.WriteLine(myList.Capacity);
        myList.Remove(71);
        myList.Add(11);
        Console.WriteLine(myList.Capacity);
        myList.DisplayElements();




        //MyList myList = new MyList(2);
        //Console.WriteLine(myList.Capacity);
        //myList.Add(45);
        //myList.Add(88);
        //Console.WriteLine(myList.Capacity);
        //myList.Add(44);
        //Console.WriteLine(myList.Capacity);
        //Console.WriteLine(myList.GetById(0));
        //Console.WriteLine(myList.GetById(1));
        //Console.WriteLine(myList.GetById(2));

    }
}