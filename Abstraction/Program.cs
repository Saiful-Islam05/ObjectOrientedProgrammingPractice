namespace Abstraction
{
    internal class Program
    {
        /*
        public abstract class Person
        {
            public string Name;
            public int Id;

            public Person(string name, int id)
            {
                this.Name = name;
                this.Id = id;
            }

            public abstract void PrintInfo();    // কোনো body নেই — child-কে দিতে হবে
        }




        public class Student : Person
        {
            public double Marks;

            public Student(string name, int id, double marks)
                : base(name, id)
            {
                this.Marks = marks;
            }

            public override void PrintInfo()    // abstract method override করতেই হবে
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}, Marks: {Marks}");
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

            public override void PrintInfo()
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}, Subject: {Subject}");
            }
        }
        */





        public interface IPerson
        {
            void PrintInfo();
        }

        public interface IExportable
        {
            void ExportToFile(string filename);
        }

        public class Student : IPerson, IExportable
        {
            public string Name;
            public int Id;
            public double Marks;

            public Student(string name, int id, double marks)
            {
                this.Name = name;
                this.Id = id;
                this.Marks = marks;
            }

            public void PrintInfo()    // IPerson-এর contract পূরণ For Student
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}, Marks: {Marks}");
            }

            public void ExportToFile(string filename)    // IExportable-এর contract
            {
                Console.WriteLine($"Exporting {Name}'s data to {filename}...");
            }
        }

        public class Teacher : IPerson
        {
            public string Name;
            public int Id;
            public string Subject;

            public Teacher(string name, int id, string subject)
            {
                this.Name = name;
                this.Id = id;
                this.Subject = subject;
            }

            public void PrintInfo()    // IPerson-এর contract পূরণ for Teacher
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}, Subject: {Subject}");
            }
        }


        static void Main(string[] args)
        {
            // Person p = new Person("Rahim", 101);  // ❌ Error! Person is abstract
            /*
            Student rahim = new Student("Rahim", 101, 85);
            Teacher karim = new Teacher("Karim", 201, "Mathematics");

            rahim.PrintInfo();    // Output: Name: Rahim, ID: 101, Marks: 85
            karim.PrintInfo();    // Output: Name: Karim, ID: 201, Subject: Mathematics
            */





            Student student = new Student("Saiful Islam", 101, 85);
            Teacher teacher = new Teacher("Jasim Sir", 201, "Mathematics");

            student.PrintInfo();    // Output: Name: Saiful Islam, ID: 101, Marks: 85
            teacher.PrintInfo();    // Output: Name: Jasim Sir, ID: 201, Subject: Mathematics
            student.ExportToFile("student_data.txt");    // Output: Exporting Saiful Islam's data to student_data.txt...
        }
    }
}
