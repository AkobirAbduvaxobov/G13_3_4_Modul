namespace _4_5_DessignPatter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = Book.GetInstance();
            Book book2 = Book.GetInstance();
            Book book3 = Book.GetInstance();

            book1.BookId = Guid.NewGuid();

            Console.WriteLine(book1.BookId);
            Console.WriteLine(book2.BookId);
            Console.WriteLine(book3.BookId);


        }
    }
}
