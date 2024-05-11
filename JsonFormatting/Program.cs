using JsonFormattingAssignment;
using System;
using System.Collections.Generic;

namespace JsonTest
{
    public class Course
    {
        public string Title { get; set; }
        public Instructor Teacher { get; set; }
        public List<Topic> Topics { get; set; }
        public double Fees { get; set; }
        public List<AdmissionTest> Tests { get; set; }
    }

    public class AdmissionTest
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double TestFees { get; set; }
    }

    public class Topic
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
    }

    public class Session
    {
        public int DurationInHour { get; set; }
        public string LearningObjective { get; set; }
    }

    public class Instructor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address PresentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Phone
    {
        public string Number { get; set; }
        public string Extension { get; set; }
        public string CountryCode { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course
            {
                Title = "Advanced dotNet Course",
                Teacher = new Instructor
                {
                    Name = "Mahmudul Hasan",
                    Email = "mahmudul920@gmail.com",
                    PresentAddress = new Address { Street = "Shantidara", City = "Feni", Country = "Bangladesh" },
                    PermanentAddress = new Address { Street = "Shantidara", City = "Feni", Country = "Bangladesh" },
                    PhoneNumbers = new List<Phone>
                    {
                        new Phone { Number = "01963423770", Extension = "0", CountryCode = "+88" }
                    }
                },
                Topics = new List<Topic>
                {
                    new Topic
                    {
                        Title = "Introduction to C#",
                        Description = "A beginner's of C#",
                        Sessions = new List<Session>
                        {
                            new Session { DurationInHour = 1, LearningObjective = "Learn basic syntax" },
                            new Session { DurationInHour = 2, LearningObjective = "Learn OOP principles" }
                        }
                    },
                    new Topic
                    {
                        Title = "Advanced Features od dotnet",
                        Description = "Explore advanced features of C# & dotNet",
                        Sessions = new List<Session>
                        {
                            new Session { DurationInHour = 1, LearningObjective = "Learn about LINQ" },
                            new Session { DurationInHour = 1, LearningObjective = "Learn about async and await" }
                        }
                    }
                },
                Fees = 30000.00,
                Tests = new List<AdmissionTest>
                {
                    new AdmissionTest
                    {
                        StartDateTime = new DateTime(2024, 5, 10, 9, 0, 0),
                        EndDateTime = new DateTime(2024, 5, 11, 11, 0, 0),
                        TestFees = 1000.00
                    }
                }
            };

            string json = JsonFormatter.Convert(course);
            Console.WriteLine(json);
        }
    }
}
