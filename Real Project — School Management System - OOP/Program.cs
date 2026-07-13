using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace Real_Project___School_Management_System___OOP
{
    internal class Program
    {
        public interface INotifiable
        {
            void SendNotification(string message);
        }

        public abstract class Person
        {
            private string name;
            private int id;

           public string Name
            {
                get { return name; }

                set
                {
                    if(string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Name can't be Empty");
                        return;
                    }
                    name = value;
                }
            }

            public int Id
            {
                get { return id; }
                set
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("ID must be a positive integer.");
                        return;
                    }
                    id = value;
                }
            }

            public Person(string name, int id)
            {
                this.name = name;
                this.id = id;
            }

            public abstract void PrintInfo();

            public void SayHello()
            {
                Console.WriteLine($"Hello, my name is {name} and my ID is {id}.");
            }

        }

        public class Student: Person, INotifiable
        {
            private double marks;

            public double Marks
            {
                get { return marks; }
                set
                {
                    if (value < 0 || value > 100)
                    {
                        Console.WriteLine("Marks must be between 0 and 100.");
                        return;
                    }
                    marks = value;
                }
            }

            public string ParentPhone { get; set; }

            public Student(string name, int id, double marks, string parentPhone) : base(name, id)
            {
                this.marks = marks;
                this.ParentPhone = parentPhone;
            }

            public override void PrintInfo()
            {
                Console.WriteLine($"  [Student] Name: {Name}, ID: {Id}, Marks: {Marks}, Grade: {GetGrade()}");
            }

            public string GetGrade()
            {
                if (marks >= 90)
                    return "A+";
                else if (marks >= 80)
                    return "A";
                else if (marks >= 70)
                    return "B";
                else if (marks >= 60)
                    return "C";
                else
                    return "F";
            }

            public void SendNotification(string message)
            {
                Console.WriteLine($"Sending notification to parent at {ParentPhone}: {message}");
            }
        }

        public class Teacher: Person, INotifiable
        {
            public string Subject { get; set; }
            public string Email { get; set; }

            public Teacher(string name, int id, string subject, string email) : base(name, id)
            {
                this.Subject = subject;
                this.Email = email;
            }

            public override void PrintInfo()
            {
                Console.WriteLine($"  [Teacher] Name: {Name}, ID: {Id}, Subject: {Subject}, Email: {Email}");
            }

            public void SendNotification(string message)
            {
                Console.WriteLine($"Sending notification to teacher at {Email}: {message}");
            }
        }

        public class School
        {
            public string SchoolName;
            private List<Person> people = new List<Person>();

            public School(string schoolName)
            {
                this.SchoolName = schoolName;
            }
            
            public void AddPerson(Person p)
            {
                people.Add(p);
                Console.WriteLine($"✅ '{p.Name}' added to {SchoolName}!");
            }


            public void ShowAll()
            {
                Console.WriteLine($"\n--- {SchoolName} — Everyone Information ---");
                if (people.Count == 0)
                {
                    Console.WriteLine("  Empty?! Add a Student or Teacher first.");
                    return;
                }
                foreach (Person p in people)
                {
                    p.PrintInfo();    // ← Polymorphism! Student/Teacher নিজের version চালায়
                }
                Console.WriteLine($"--- Total: {people.Count} person ---");
            }


            public Person SearchById(int id)
            {
                foreach (Person p in people)
                {
                    if (p.Id == id) return p;
                }
                return null;
            }

            public void NotifyAll(string message)
            {
                Console.WriteLine($"\n📢 Sending notification to everyone...");
                foreach (Person p in people)
                {
                    if (p is INotifiable notifiable)    // ← Interface check!
                    {
                        notifiable.SendNotification(message);
                    }
                }
                Console.WriteLine("📢 Done!");
            }

        }



        static void Main(string[] args)
        {
            School school = new School("Dhaka Model School");
            bool running = true;

            Console.WriteLine("🏫 Welcome to School Management System!\n");

            while(running)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Show All");
                Console.WriteLine("4. Search by ID");
                Console.WriteLine("5. Notify All");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1-6): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(school);
                        break;
                    case "2":
                        AddTeacher(school);
                        break;
                    case "3":
                        school.ShowAll();
                        break;
                    case "4":
                        SearchPerson(school);
                        break;
                    case "5":
                        Console.WriteLine("Message: ");
                        string message = Console.ReadLine();
                        school.NotifyAll(message);
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 6.");
                        break;
                }
            }
        }

        static void AddStudent(School school)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Marks: ");
            double marks = double.Parse(Console.ReadLine());

            Console.Write("Enter Parent Phone: ");
            string parentPhone = Console.ReadLine();

            Student student = new Student(name, id, marks, parentPhone);
            school.AddPerson(student);
        }

        static void AddTeacher(School school)
        {
            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject: ");
            string subject = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Teacher teacher = new Teacher(name, id, subject, email);
            school.AddPerson(teacher);
        }

        static void SearchPerson(School school)
        {
            Console.Write("Enter ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Person person = school.SearchById(id);

            if (person != null)
            {
                Console.WriteLine("Person found:");
                person.PrintInfo();  // ← Polymorphism! Student/Teacher নিজের version চালায়
                person.SayHello(); // ← Inheritance! Person class থেকে method
            }
            else
            {
                Console.WriteLine($"No person found with ID {id}.");
            }
        }
    }
}
