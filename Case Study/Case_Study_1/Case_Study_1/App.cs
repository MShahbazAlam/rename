﻿using System;

namespace Case_Study_1
{
   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }

    class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
        }
    }

   public class App
    {
        static void Main(string[] args)
        {
            // Scenario1();
            //Scenario2();
            Console.WriteLine("Welcome to Case Study 1!");

            while (true)
            {
                Console.WriteLine("\nChoose a scenario:");
                Console.WriteLine("1. Scenario 1");
                Console.WriteLine("2. Scenario 2");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Scenario1();
                            break;
                        case 2:
                            Scenario2();
                            break;
                        case 3:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid scenario (1-3).");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric choice.");
                }
            }
            Console.ReadLine();
        }

        public static void Scenario1()
        {
            Console.WriteLine("Scenario 1:");

            Console.Write("Enter the number of students: ");
            int numStudents = int.Parse(Console.ReadLine());

            Student[] students = new Student[numStudents];
            Info info = new Info();

            for (int i = 0; i < numStudents; i++)
            {
                Console.Write($"Enter Student {i + 1} ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter Student {i + 1} Name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter Student {i + 1} Date of Birth (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("\nStudent Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }

        public static void Scenario2()
        {
            Console.WriteLine("\nScenario 2:");
            Console.Write("Enter the number of students: ");
            int numStudents = int.Parse(Console.ReadLine());

            Student[] students = new Student[numStudents];
            Info info = new Info();

            for (int i = 0; i < numStudents; i++)
            {
                Console.Write($"Enter Student {i + 1} ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter Student {i + 1} Name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter Student {i + 1} Date of Birth (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("\nStudent Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }
    }
}