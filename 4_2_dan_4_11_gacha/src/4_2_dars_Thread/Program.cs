namespace _4_2_dars_Thread;

internal class Program
{
    static object locker = new object();    
    static string path = "D:\\Work\\Groups\\G_13\\Moduls\\G13_3_4_Modul\\4_2_dan_4_11_gacha\\src\\4_2_dars_Thread\\g13\\";
    static void Main(string[] args)
    {
        var num = -45854;
        Console.WriteLine(num.GetLength());

        //var helper = new Helper<int>(); 
        //helper.Value = 10;

        //var helper2 = new Helper<string>();
        //helper2.Value = "Hello";



        //for (int i = 10; i <= 19; i++)
        //{
        //    Thread thread = new Thread(Display);
        //    thread.Start(i);
        //}
    }
    static void Display(object num)
    {
        
        int number = (int)num;
        for (int i = 0; i < number; i++)
        {
            lock(locker)
            {
                string newPath = Path.Combine(path, $"{i}_{number}");
                Directory.CreateDirectory(newPath);
            }

        }
    }
}
