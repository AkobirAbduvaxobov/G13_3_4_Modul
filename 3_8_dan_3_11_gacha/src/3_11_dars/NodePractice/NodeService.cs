namespace _3_11_dars.NodePractice;

public class NodeService
{
    public static Node CreateNode(int length)
    {
        Random random = new Random();
        Node headNode = new Node(11);
        Node currentNode = headNode;

        for(int i = 1; i < length; i++)
        {
            Node newNode = new Node(11 + i);
            currentNode.Next = newNode;
            currentNode = currentNode.Next;
        }

        return headNode;
    }
}
