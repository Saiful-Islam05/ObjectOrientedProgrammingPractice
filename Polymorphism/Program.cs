namespace Polymorphism
{
    internal class Program
    {
        /*
        public class Animal
        {
            public string Name;

            public Animal(string name)
            {
                this.Name = name;
            }

            public virtual void MakeSound()    // virtual যোগ হয়েছে
            {
                Console.WriteLine($"{Name} is making a sound");
            }
        }

        public class Cat : Animal
        {
            public Cat(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Meow!");
            }
        }

        public class Dog : Animal
        {
            public Dog(string name) : base(name) { }
            
            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Bhow Bhow!");
            }
            
        }
        */













        public class Person
        {
            public string Name;
            public int Id;

            public Person(string name, int id)
            {
                this.Name = name;
                this.Id = id;
            }

            public virtual void PrintInfo()    // virtual যোগ করলাম
            {
                Console.WriteLine($"Name: {Name}, ID: {Id}");
            }

            public void PrintInfo(bool showDetailed)
            {
                if (showDetailed)
                    Console.WriteLine($"[DETAILED] Name: {Name}, ID: {Id}, Type: Person");
                else
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

            public override void PrintInfo()      // Override use here
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
            /*
            Cat mimi = new Cat("Mimi");
            Dog tommy = new Dog("Tommy");

            mimi.MakeSound();    // Output: Mimi is making a sound
            tommy.MakeSound();   // Output: Tommy is making a sound
            */





            /*
            Student rahim = new Student("Rahim", 101, 85);
            Teacher karim = new Teacher("Karim", 201, "Mathematics");

            rahim.PrintInfo();    // Output: Name: Rahim, ID: 101, Marks: 85
            rahim.PrintInfo(false);
            */










            Person[] people = new Person[]
            {
                new Student("Rahim",101,85),
                new Teacher("Karim",201,"Mathmatics"),
                new Student("Fatima",102,92)
            };

            foreach (Person p in people)
            {
                p.PrintInfo();
                Console.WriteLine("-----------");
            }


            // Compile-Time Polymorphism — overloading
            Person rahim = new Person("Rahim", 101);
            rahim.PrintInfo();  // parameter ছাড়া version
            rahim.PrintInfo(true);  // parameter সহ version — detailed
        }
    }
}
