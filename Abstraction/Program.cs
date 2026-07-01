namespace Abstraction
{
    internal class Program
    {
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


        static void Main(string[] args)
        {
            // Person p = new Person("Rahim", 101);  // ❌ Error! Person is abstract

            Student rahim = new Student("Rahim", 101, 85);
            Teacher karim = new Teacher("Karim", 201, "Mathematics");

            rahim.PrintInfo();    // Output: Name: Rahim, ID: 101, Marks: 85
            karim.PrintInfo();    // Output: Name: Karim, ID: 201, Subject: Mathematics
        }
    }
}
