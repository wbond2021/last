using System;
using System.Collections.Generic;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public List<Meeting> Meetings { get; set; }
}

public class PrimarySupervisor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Meeting> Meetings { get; set; }
}

public class Meeting
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Purpose { get; set; }
}

public class Program
{
    public static List<Student> Students { get; set; } = new List<Student>();
    public static List<PrimarySupervisor> PrimarySupervisors { get; set; } = new List<PrimarySupervisor>();
    public static List<Meeting> Meetings { get; set; } = new List<Meeting>();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Report Feeling/Progress");
            Console.WriteLine("2. Review Student Status");
            Console.WriteLine("3. Book Meeting");
            Console.WriteLine("4. View Student Status and Interactions");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReportFeelingProgress();
                    break;
                case "2":
                    ReviewStudentStatus();
                    break;
                case "3":
                    BookMeeting();
                    break;
                case "4":
                    ViewStudentStatusAndInteractions();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void ReportFeelingProgress()
    {
        Console.Clear();
        Console.WriteLine("Report Feeling/Progress");

        Console.Write("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            Student student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter Status/Feeling: ");
                string status = Console.ReadLine();
                student.Status = status;

                Console.WriteLine("Feeling/Progress reported successfully. Press Enter to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student not found. Press Enter to continue.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Press Enter to continue.");
            Console.ReadLine();
        }
    }

    public static void ReviewStudentStatus()
    {
        Console.Clear();
        Console.WriteLine("Review Student Status");

        foreach (var student in Students)
        {
            Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}, Status: {student.Status}");
        }

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }


    public static void BookMeeting()
    {
        Console.Clear();
        Console.WriteLine("Book Meeting");

        Console.Write("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            Student student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter Supervisor ID: ");
                if (int.TryParse(Console.ReadLine(), out int supervisorId))
                {
                    PrimarySupervisor supervisor = PrimarySupervisors.FirstOrDefault(ps => ps.Id == supervisorId);
                    if (supervisor != null)
                    {
                        Console.Write("Enter Meeting Date (yyyy-MM-dd): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                        {
                            Console.Write("Enter Meeting Purpose: ");
                            string purpose = Console.ReadLine();

                            var meeting = new Meeting
                            {
                                Id = Meetings.Count + 1,
                                Date = date,
                                Purpose = purpose,
                            };

                            student.Meetings.Add(meeting);
                            supervisor.Meetings.Add(meeting);

                            Console.WriteLine("Meeting booked successfully. Press Enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Press Enter to continue.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Supervisor not found. Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Supervisor ID. Press Enter to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Student not found. Press Enter to continue.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Student ID. Press Enter to continue.");
            Console.ReadLine();
        }
    }


    public static void ViewStudentStatusAndInteractions()
    {
        Console.Clear();
        Console.WriteLine("View Student Status and Interactions");

        Console.Write("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            Student student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                Console.WriteLine($"Status: {student.Status}");

                Console.WriteLine("Meeting interactions with Primary Supervisor:");

                foreach (var meeting in student.Meetings)
                {
                    Console.WriteLine($"Meeting ID: {meeting.Id}, Date: {meeting.Date:yyyy-MM-dd}, Purpose: {meeting.Purpose}");
                }

                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student not found. Press Enter to continue.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Student ID. Press Enter to continue.");
            Console.ReadLine();
        }
    }

}
