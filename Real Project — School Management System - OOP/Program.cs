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




        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
