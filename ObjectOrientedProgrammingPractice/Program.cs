namespace ObjectOrientedProgrammingPractice
{
    internal class Program
    {

        public class Student
        {
            private string Name;
            private int Roll;
            private double Bangla;
            private double English;
            private double Math;
            public Student(string name,int roll,double bangla,double english, double math)
            {
                Name = name;
                Roll = roll;
                Bangla = bangla;
                English = english;
                Math = math;
            }
            private double GetAverage()
            {
                return (Bangla + English + Math) / 3.0;
            }

            public void PrintResult()
            {
                Console.WriteLine($"Name: {Name}, Roll: {Roll}");
                Console.WriteLine($"Bangla: {Bangla}, English: {English}, Math: {Math}");
                Console.WriteLine($"Average: {GetAverage():F2}");
            }
        }

        static void Main(string[] args)
        {
            Student rahim = new Student("Rahim", 101, 75, 80, 85);
            Student karim = new Student("Karim", 102, 60, 55, 70);

            rahim.PrintResult();
            Console.WriteLine("--------------------------");
            karim.PrintResult();
        }
       
    }
}

