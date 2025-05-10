using System;

namespace AssignmentDemo
{
    // ---------------------- Q1 ----------------------
    enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    // ---------------------- Q3 ----------------------
    enum Season { Spring, Summer, Autumn, Winter }

    // ---------------------- Q4 ----------------------
    [Flags]
    enum Permissions { None = 0, Read = 1, Write = 2, Delete = 4, Execute = 8 }

    // ---------------------- Q5 ----------------------
    enum Colors { Red, Green, Blue }

    // ---------------------- Q2, Q7 & Q8 Struct Person ----------------------
    struct Person
    {
        public string Name;
        public int Age;
    }

    // ---------------------- Q6 Struct Point ----------------------
    struct Point
    {
        public double X;
        public double Y;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n========== Question 1 ==========");
            PrintWeekDays();

            Console.WriteLine("\n========== Question 2 ==========");
            ShowPeople();

            Console.WriteLine("\n========== Question 3 ==========");
            ShowSeasonMonths();

            Console.WriteLine("\n========== Question 4 ==========");
            ManagePermissions();

            Console.WriteLine("\n========== Question 5 ==========");
            CheckColor();

            Console.WriteLine("\n========== Question 6 ==========");
            CalculateDistance();

            Console.WriteLine("\n========== Question 7 & 8 ==========");
            FindOldestPerson();
        }

        #region Q1
        static void PrintWeekDays()
        {
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
        }
        #endregion

        #region Q2
        static void ShowPeople()
        {
            Person[] people = new Person[3]
            {
                new Person { Name = "Ali", Age = 24 },
                new Person { Name = "Mona", Age = 29 },
                new Person { Name = "Omar", Age = 21 }
            };

            foreach (var p in people)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }
        }
        #endregion

        #region Q3
        static void ShowSeasonMonths()
        {
            Console.Write("Enter a season (Spring, Summer, Autumn, Winter): ");
            string input = Console.ReadLine();

            if (Enum.TryParse<Season>(input, true, out Season selected))
            {
                switch (selected)
                {
                    case Season.Spring:
                        Console.WriteLine("March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        #endregion

        #region Q4
        static void ManagePermissions()
        {
            Permissions userPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine($"Initial: {userPermissions}");

            // Add Delete
            userPermissions |= Permissions.Delete;
            Console.WriteLine($"After Add Delete: {userPermissions}");

            // Remove Write
            userPermissions &= ~Permissions.Write;
            Console.WriteLine($"After Remove Write: {userPermissions}");

            // Check Execute
            bool hasExecute = (userPermissions & Permissions.Execute) == Permissions.Execute;
            Console.WriteLine($"Has Execute: {hasExecute}");
        }
        #endregion

        #region Q5
        static void CheckColor()
        {
            Console.Write("Enter a color (Red, Green, Blue): ");
            string input = Console.ReadLine();

            if (Enum.TryParse<Colors>(input, true, out Colors color))
            {
                Console.WriteLine($"{color} is a primary color.");
            }
            else
            {
                Console.WriteLine($"{input} is not a primary color.");
            }
        }
        #endregion

        #region Q6 
        static void CalculateDistance()
        {
            Point p1, p2;

            Console.Write("Enter X for Point 1: ");
            p1.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y for Point 1: ");
            p1.Y = double.Parse(Console.ReadLine());

            Console.Write("Enter X for Point 2: ");
            p2.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y for Point 2: ");
            p2.Y = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"Distance: {distance:F2}");
        }
        #endregion

        #region Q7&Q8 
        static void FindOldestPerson()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                persons[i].Name = Console.ReadLine();
                Console.Write($"Enter age of person {i + 1}: ");
                persons[i].Age = int.Parse(Console.ReadLine());
            }

            Person oldest = persons[0];
            foreach (var p in persons)
            {
                if (p.Age > oldest.Age)
                    oldest = p;
            }

            Console.WriteLine($"Oldest Person: {oldest.Name}, Age: {oldest.Age}");
        } 
        #endregion
    }
}
