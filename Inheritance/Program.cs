namespace Inheritance
{
    internal class Program
    {
        public class Student : Person
        {
            public double Marks;
            public string GetGrade()
            {
                if (Marks >= 80) return "A+";
                else if (Marks >= 60) return "A";
                else if (Marks >= 40) return "B";
                else return "F";
            }

        }

        public class Teacher
        {
            public string? Name;
            public int Id;
            public string? Subject;

            public void PrintInfo()
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}");
            }

            public string GetTitle()
            {
                return $"{Name} Sir ({Subject})";
            }
        }

        public class Person
        {
            public string? Name;
            public int Id;

            public Person(string name, int id)
            {
                this.Name = name;
                this.Id = id;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}");
            }
        }

        static void Main(string[] args)
        {
            Student rahim = new Student("Rahim", 101);
            rahim.Marks = 85;

            Console.WriteLine(rahim.Name);        // Output: Rahim — Person থেকে
            Console.WriteLine(rahim.Id);          // Output: 101 — Person থেকে
            Console.WriteLine(rahim.Marks);       // Output: 85 — Student-এর নিজের
            Console.WriteLine(rahim.GetGrade());  // Output: A+ — Student-এর নিজের
            rahim.PrintInfo();                    // Output: Name: Rahim, ID: 101 — Person থেকে

        }
    }
}
