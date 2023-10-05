using System;
using Case_Study_1; 
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Case_Study_2
{
    public class Enroll
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int courseId, string courseName)
        {
            CourseId = courseId;
            CourseName = courseName;
        }
    }

    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();
        //private Student[] students = new Student[0];
        //private Course[] courses = new Course[0];
        //private Enroll[] enrollments = new Enroll[0];

        public void Introduce(Course course)
        {
            courses.Add(course);
        }

        public void Register(Student student)
        {
            students.Add(student);
                  }

        public Student[] ListOfStudents()
        {
            return students.ToArray();
        }

        public Course[] ListOfCourses()
        {
            return courses.ToArray();
        }

        public void Enroll(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now; // Assuming enrollment date is the current date
            enrollments.Add(new Enroll(student, course, enrollmentDate));
        }

        public Enroll[] ListOfEnrollments()
        {
            return enrollments.ToArray();
        }

    }

    public class App
    {
        static void Main(string[] args)
        {
            AppEngine appEngine = new AppEngine();

            Console.WriteLine("Welcome to the Course Enrollment System!");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Introduce Course");
                Console.WriteLine("2. Register Student");
                Console.WriteLine("3. Enroll Student in Course");
                Console.WriteLine("4. List Students");
                Console.WriteLine("5. List Courses");
                Console.WriteLine("6. List Enrollments");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice (1-7): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Course ID: ");
                            int courseId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course Name: ");
                            string courseName = Console.ReadLine();
                            appEngine.Introduce(new Course(courseId, courseName));
                            Console.WriteLine("Course introduced successfully.");
                            break;
                        
                      
                        case 2:
                            Console.WriteLine("\nChoose a scenario for student registration:");
                            Console.WriteLine("1. Scenario 1 (CaseStudy1)");
                            Console.WriteLine("2. Scenario 2 (CaseStudy1)");
                            Console.Write("Enter your choice (1-2): ");
                            //int scenarioChoice = int.Parse(Console.ReadLine());
                            if (int.TryParse(Console.ReadLine(), out int scenarioChoice))
                            {

                                if (scenarioChoice == 1 || scenarioChoice == 2)
                                {
                                    // Register the student using Scenario 1 or 2 from CaseStudy1
                                    if (scenarioChoice == 1)
                                    {
                                        Case_Study_1.App.Scenario1();
                                        Console.WriteLine("Student registered successfully using Scenario 1.");
                                    }
                                    else if (scenarioChoice == 2)
                                    {
                                        Case_Study_1.App.Scenario2();
                                        Console.WriteLine("Student registered successfully using Scenario 2.");
                                    }
                                }


                                else
                                {
                                    Console.WriteLine("Please select a valid scenario (1-2).");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, Please enter a numeric choice ");
                            }
                            break;



                        case 3:
                            Console.Write("Enter Student ID: ");
                            int enrollStudentId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course ID: ");
                            int enrollCourseId = int.Parse(Console.ReadLine());
                            Student enrollStudent = appEngine.ListOfStudents()
                                .FirstOrDefault(s => s.Id == enrollStudentId);
                            Course enrollCourse = appEngine.ListOfCourses()
                                .FirstOrDefault(c => c.CourseId == enrollCourseId);
                            if (enrollStudent != null && enrollCourse != null)
                            {
                                appEngine.Enroll(enrollStudent, enrollCourse);
                                Console.WriteLine("Student enrolled in the course successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student or course not found. Please register them first.");
                            }
                            break;


                        case 4:
                          
                            Console.WriteLine("\nList of Students:");
                            foreach (var student in Case_Study_1.App.students)
                            {
                                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                            }
                            break;

                        case 5:
                            Console.WriteLine("\nList of Courses:");
                            foreach (var course in appEngine.ListOfCourses())
                            {
                                Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("\nList of Enrollments:");
                            foreach (var enrollment in appEngine.ListOfEnrollments())
                            {
                                Console.WriteLine($"Student ID: {enrollment.Student.Id}, Course ID: {enrollment.Course.CourseId}, Enrollment Date: {enrollment.EnrollmentDate}");
                            }
                            break;

                        case 7:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric choice.");
                }
            }
           
        }
    }
}
