namespace _4_1_Exception;

public class Program
{
    static void Main(string[] args)
    {

        try
        {
            int age = 17;
            if(age < 18)
            {
                throw new AgeException("Yosh 18 dan kichik bo'lishi mumkin emas!");
            }
        }
        catch (AgeException ex)
        {
            Console.WriteLine("Hatolik");
        }


        //while (true)
        //{
        //    Do1();

        //    Console.Write("Son kiriting : ");

        //    int res;


        //    try
        //    {
        //        int num = int.Parse(Console.ReadLine());
        //        //res = 25 / num;
        //        //Console.WriteLine("Res : " + res);
        //        throw new StackOverflowException("Stack to'ldi");
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        Console.WriteLine("Cannot divide by zero!");
        //        Console.WriteLine(ex.Message);
        //        res = 0;
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine("Format xato!");
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Xatolik yuz berdi!");
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Bu har doim ishlaydi!");
        //    }

        //}
    }

    static void Do1()
    {
        try
        {
            Do2();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static void Do2()
    {
        Do3();
    }
    static void Do3()
    {
        Do4();
    }

    static void Do4()
    {
        int a = 0;
        Console.WriteLine(45 / a);
    }


}
