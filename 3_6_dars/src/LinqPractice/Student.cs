namespace LinqPractice;

public class Student
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Grade { get; set; }
    public decimal Scholarship { get; set; }
    public byte Age { get; set; }

    public static List<Student> GetStudents()
    {
        var random = new Random();

        var firstNames = new[]
        {
            "Ali", "Bekzod", "Sardor", "Jasur", "Aziz",
            "Dilshod", "Nodir", "Jamshid", "Akmal", "Farrux",
            "Madina", "Malika", "Zarina", "Nigora", "Laylo",
            "Sevara", "Sabina", "Dildora", "Shahnoza", "Gulnoza"
        };

        var lastNames = new[]
        {
            "Karimov", "Aliyev", "Tursunov", "Rakhimov", "Ismoilov",
            "Abdullayev", "Qodirov", "Yusupov", "Ergashev", "Rustamov"
        };

        var grades = new[] { "1", "2", "3", "4" };

        var students = new List<Student>();

        for (int i = 0; i < 20; i++)
        {
            var student = new Student
            {
                StudentId = Guid.NewGuid(),

                FirstName = firstNames[random.Next(firstNames.Length)],

                LastName = lastNames[random.Next(lastNames.Length)],

                Grade = grades[random.Next(grades.Length)],

                Age = (byte)random.Next(16, 26), // 16–25 years

                Scholarship = random.Next(0, 3) * 500_000 // 0–2,500,000 (UZS-like)
            };

            students.Add(student);
        }

        return students;
    }
}
