using _3_11_dars.NodePractice;

namespace _3_11_dars;

public class Program
{
    static void Main(string[] args)
    {
        //Dog dog = new Dog();
        //dog.Name = "Rex";
        //dog.Age = 3;

        Node node = NodeService.CreateNode(4);
        var res = GetLengthOfNode(node);
        Console.WriteLine(res);


    }

    static int GetLengthOfNode(Node node)
    {
        var counter = 0;
        while(true)
        {
            if(node != null)
            {
                ++counter;
            }
            if(node.Next == null)
            {
                break;
            }
            node = node.Next;
        }

        return counter;
    }
}
