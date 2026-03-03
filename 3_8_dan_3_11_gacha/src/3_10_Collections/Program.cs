using System.Collections;
using System.Collections.Generic;

namespace _3_10_Collections;

internal class Program
{
    static void Main(string[] args)
    {




        //Dictionary<int, Dictionary<string, string>> keyValuePairs = new Dictionary<int, Dictionary<string, string>>();

        // HashTable

        //Hashtable hashtable = new Hashtable();
        //hashtable.Add(4, "salom");
        //hashtable.Add("privet", "salom");
        //hashtable.Add("privet", new Hashtable());


        //Book book1 = new Book() { Name = "Foundation", AuthorName = "Isaac Asimov" };
        //Book book2 = new Book() { Name = "Foundation and Empire", AuthorName = "Bunyod" };
        //Book book3 = new Book() { Name = "Second Foundation", AuthorName = "Bekzod" };
        //Book book4 = new Book() { Name = "Foundation", AuthorName = "Izzatullo" };
        //Book book5 = new Book() { Name = "Foundation", AuthorName = "Izzatullo" };

        //Dictionary<Book, string> keyValuePairs = new Dictionary<Book, string>();

        //keyValuePairs.Add(book1, book1.AuthorName);
        //keyValuePairs.Add(book2, book2.AuthorName);
        //keyValuePairs.Add(book3, book3.AuthorName);
        //keyValuePairs.Add(book4, book4.AuthorName);
        //keyValuePairs.Add(book5, book4.AuthorName);
        ////keyValuePairs.Add(book4, book4.AuthorName);
        //Console.WriteLine(keyValuePairs.Count());


        // Dictionary & HashTable

        //Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

        //keyValuePairs.Add(4, "salom");
        //keyValuePairs.Add(8, "salom");
        //keyValuePairs.Add(9, "hello");
        //keyValuePairs.Add(2, "salom");
        //keyValuePairs.Add(0, "privet");

        //keyValuePairs.Remove(2);
        //Console.WriteLine(keyValuePairs.GetValueOrDefault(18));
        //Console.WriteLine(keyValuePairs[18]);

        //Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        //keyValuePairs.Add(1, 2);

        //Console.WriteLine(keyValuePairs.GetValueOrDefault(4));



        //string s = string.Empty;

        //while(true)
        //{
        //    s = Console.ReadLine();
        //    Console.WriteLine(s.GetHashCode());
        //}



        //int a = 5;
        //Console.WriteLine(a.GetHashCode());
        //Console.WriteLine(a.GetHashCode());


        //HashSet<string> sets = new HashSet<string>();

        //Console.WriteLine(sets.GetHashCode());

        //sets.Add("salom");
        //sets.Add("Hello");
        //sets.Add("salom");



        //Console.WriteLine(sets.Count());





        //2.Stack yordamida matnni teskari qilib chiqaruvchi 
        //    dastur yozing.

        //string s = "Foundation g13";

        //Stack<char> chars = new Stack<char>();
        //foreach(var ch in s)
        //{
        //    chars.Push(ch);
        //}
        //var res = string.Empty;
        //while(chars.Count() != 0)
        //{
        //    res += chars.Pop();
        //}
        //Console.WriteLine(res);

        //var queues = new Queue<string>();
        //queues.Enqueue("salom");
        //queues.Enqueue("2");
        //queues.Enqueue("davay");
        //queues.Enqueue("Hi");
        //queues.Enqueue("Hey");
        //string res = string.Empty;
        //Console.WriteLine(queues.Peek());
        //Console.WriteLine(queues.Dequeue());
        //Console.WriteLine(queues.Dequeue());
        //Console.WriteLine(queues.Dequeue());
        //Console.WriteLine(queues.Dequeue());
        //Console.WriteLine(queues.Dequeue());
        //Console.WriteLine(queues.TryDequeue(out res));
        //Console.WriteLine(res);


        //var strings = new Stack<string>();
        //strings.Push("salom");
        //strings.Push("Hello");
        //strings.Push("Privet");

        //Console.WriteLine(strings.Pop());
        //Console.WriteLine(strings.Pop());
        //Console.WriteLine(strings.Pop());
        //Console.WriteLine(strings.Pop());



    }
}
