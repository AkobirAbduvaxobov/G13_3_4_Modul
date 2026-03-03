using _3_9_Collections.HMWRK;
using System.Collections;

namespace _3_9_Collections;

public class Program
{
    static void Main(string[] args)
    {
        // LinkedList

        LinkedList<int> list = new LinkedList<int>(); 

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(2);
        list.AddLast(4);

        list.RemoveLast();
        list.Remove(2);

        foreach (int i in list)
        {
            Console.WriteLine(i);
        }
        







        // 11. ArrayList ichidagi barcha sonlar yig‘indisini hisoblang.
        //ArrayList arrayList = new ArrayList();

        //arrayList.Add(6);
        //arrayList.Add("salom");
        //arrayList.Add(5);
        //arrayList.Add(new Book() { });
        //arrayList.Add(3);

        //var summa = 0;
        //foreach (var item in arrayList)
        //{
        //    if (item is int)
        //    {
        //        summa += (int)item;
        //    }
        //}

        //Console.WriteLine(summa);


        //MyList<Car> myList = new MyList<Car>();
        //MyList<Book> myList = new MyList<Book>();
        //MyList<int> myList = new MyList<int>();



        //    IMyStack<string> myStack = new MyStack<string>();
        //Stack<string> myStack = new Stack<string>();
        //Stack values = new Stack();
        //values.Push("salom");
        //values.Push(655);

        //    myStack.Push("Akobir");
        //    myStack.Push("Bekzod");
        //    myStack.Push("Bunyod");
        //    myStack.Push("Erkinbek");

        //    Console.WriteLine(myStack.Peek());
        //    Console.WriteLine(myStack.Peek());
        //    Console.WriteLine(myStack.Pop());
        //    Console.WriteLine(myStack.Peek());

    }
}
