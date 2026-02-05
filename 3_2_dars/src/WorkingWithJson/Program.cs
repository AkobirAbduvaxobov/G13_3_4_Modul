using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorkingWithJson;

internal class Program
{
    static void Main(string[] args)
    {

        // File
        var path = "D:\\Work\\Groups\\G_13\\Moduls\\G13_3_4_Modul\\3_2_dars\\src\\WorkingWithJson\\www.txt";

        //var stream = File.Create(path);
        //stream.Close();



        ////File.Create(path).Close();
        //File.WriteAllText(path, "Salom salom");
        //File.WriteAllText(path, "Salom PDP\n");

        File.AppendAllLines(path, new List<string>() { "OK ok ok", "OK ok" });
        ////File.AppendAllText(path, "OK ok ok");
        //var res = File.ReadAllText(path);


        // FileInfo
        //var path = "D:\\Work\\Groups\\G_13\\Moduls\\G13_3_4_Modul\\3_2_dars\\src\\WorkingWithJson\\Salom.txt";

        //FileInfo fileInfo = new FileInfo(path);
        //fileInfo.Create();

        //Console.WriteLine(fileInfo.FullName);
        //Console.WriteLine(fileInfo.Name);
        //Console.WriteLine(fileInfo.Length);
        //Console.WriteLine(fileInfo.CreationTime);
        //Console.WriteLine(fileInfo.CreationTimeUtc);
        //Console.WriteLine(fileInfo.Directory);
        //Console.WriteLine(fileInfo.DirectoryName);
        //Console.WriteLine(fileInfo.IsReadOnly);
        //Console.WriteLine(fileInfo.LastAccessTime);
        //Console.WriteLine(fileInfo.LastWriteTime);
        //Console.WriteLine(fileInfo.UnixFileMode);
        //Console.WriteLine(fileInfo.Extension);
        //Console.WriteLine(fileInfo.Exists);



    }
}
