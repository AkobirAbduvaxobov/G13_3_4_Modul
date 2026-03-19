using System.Reflection.Metadata.Ecma335;

namespace _4_5_DessignPatter;

public class Book
{
    public Guid BookId { get; set; }
    public string Name { get; set; }
    private static Object Lock = new();

    private static Book Instance = null;
    private Book()
    {
        
    }

    public static Book GetInstance()
    {
        lock(Lock)
        {
            if (Instance == null)
            {
                Instance = new Book();
            }
        }

        return Instance;
    }
}
