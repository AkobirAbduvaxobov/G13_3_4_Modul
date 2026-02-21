namespace LinqPractice;

internal class Program
{
    static void Main(string[] args)
    {

        //Predicate<string> predicate;
        //predicate = Check;


        //Func<int, int, string> add;
        //add = Add1;

        //var res = add.Invoke(5, 8);
        //Console.WriteLine(res);



        //Action<string> printName;
        //printName = Foo1;
        //printName += Foo2;

        //printName.Invoke("Rustam");


        //Func<string, string> func;
        //func = Func1;
        //func += Func2;
        //func += Func3;
        //func += Func4;

        //Console.WriteLine(func.Invoke("Faundation"));


        Predicate<Student> predicate = Foo;

        var students = Student.GetStudents();

        students.Where(predicate.Invoke);

    }

    static bool Foo(Student student)
    {
        return student.Age > 20;
    }

    static string Func1(string s)
    {
        s = s.ToLower();
        return s;
    }

    static string Func2(string s)
    {
        s = s.ToUpper();
        return s;
    }

    static string Func3(string s)
    {
        s = s.Substring(2);
        return s;
    }

    static string Func4(string s)
    {
        s = s.Substring(0, 2);
        return s;
    }


    static bool Check(string s)
    {
        return true;
    }

    static string Add1(int a, int b)
    {
        return (a + b).ToString();
    }

    static void Foo1(string s)
    {
        Console.WriteLine("Foo1 : " + s);
    }
    static void Foo2(string s)
    {
        Console.WriteLine("Foo2 : " + s);
    }

}
