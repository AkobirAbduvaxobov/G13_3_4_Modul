using System.Collections;

namespace _3_8_Generics;

internal class Program
{
    static void Main(string[] args)
    {
        //var box = new Box();
        //box.Value = 45;
        //box.Value = "salom";
       
        //var box = new MyBox<int>();
        //box.Value = 45;
        //Console.WriteLine(box.GetValue());

        //var box2 = new MyBox<string>();
        //box2.Value = "salom";
        //Console.WriteLine(box2.GetValue());

        //Box box = new Box();
        //Console.WriteLine(box.GetRes(5));
        //Console.WriteLine(box.GetRes("salom"));
        //Console.WriteLine(box.GetRes('e'));


        MyList<int> myList = new MyList<int>();

        myList.Add(43);
        myList.Add(45);
        myList.Add(11);

        Console.WriteLine(myList.Count);
        Console.WriteLine(myList.Capacity);



    }
}


public class Box
{
    public object Value { get; set; }

    public T GetRes<T>(T t)
    {
        if (t is int intValue)
        {
            intValue += 10;
            t = (T)(object)intValue;
        }

        else if(t is string s)
        {
            s += "10";
            t = (T)(object)s;
        }

        return t;
    }
}

public class MyBox<T>
{
    public MyBox()
    {
        
    }

    public T Value { get; set; }

    public T GetValue()
    {
        if (Value is int intValue)
        {
            intValue += 10;
            Value = (T)(object)intValue; 
        }

        return Value;   
    }
}
