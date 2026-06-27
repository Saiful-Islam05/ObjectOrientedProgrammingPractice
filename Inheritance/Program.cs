using System.Xml.Linq;
namespace Inheritance
{
    internal class Program
    {

        public class Person
        {
            public string Name;
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

        public class Student : Person
        {
            public double Marks;

            public Student(string name, int id, double marks)
                : base(name, id)
            {
                this.Marks = marks;
            }

            public string GetGrade()
            {
                if (Marks >= 80) return "A+";
                else if (Marks >= 60) return "A";
                else if (Marks >= 40) return "B";
                else return "F";
            }
        }

        public class Teacher : Person
        {
            public string Subject;

            public Teacher(string name, int id, string subject)
                : base(name, id)
            {
                this.Subject = subject;
            }

            public string GetTitle()
            {
                return $"{Name} Sir ({Subject})";
            }
        }



        static void Main(string[] args)
        {
            Student student = new Student("Saiful", 101, 85);
            Teacher teacher = new Teacher("Dipu", 201, "Computer Science");

            student.PrintInfo();
            Console.WriteLine(student.Marks);
            Console.WriteLine(student.GetGrade());


            Console.WriteLine("------------------");



            teacher.PrintInfo();
            Console.WriteLine(teacher.Subject);
            Console.WriteLine(teacher.GetTitle());




        }
    }
}

