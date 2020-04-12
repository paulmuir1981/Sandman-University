using System;
using System.Linq;

namespace SandmanUniversity.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(SchoolContext context)
        {
            // Look for any students.
            if (!context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                    new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                    new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                    new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                    new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                    new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                    new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                    new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
                };

                var instructors = new Instructor[]
                {
                    new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                        HireDate = DateTime.Parse("1995-03-11") },
                    new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                        HireDate = DateTime.Parse("2002-07-06") },
                    new Instructor { FirstName = "Roger",   LastName = "Harui",
                        HireDate = DateTime.Parse("1998-07-01") },
                    new Instructor { FirstName = "Candace", LastName = "Kapoor",
                        HireDate = DateTime.Parse("2001-01-15") },
                    new Instructor { FirstName = "Roger",   LastName = "Zheng",
                        HireDate = DateTime.Parse("2004-02-12") }
                };

                var departments = new Department[]
                {
                    new Department { Name = "English",     Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        Administrator  = instructors[0] },
                    new Department { Name = "Mathematics", Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        Administrator  = instructors[1] },
                    new Department { Name = "Engineering", Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        Administrator  = instructors[2] },
                    new Department { Name = "Economics",   Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                       Administrator  = instructors[3] }
                };

                var courses = new Course[]
                {
                    new Course{Id=1050,Title="Chemistry",Credits=3, Department = departments[2]},
                    new Course{Id=4022,Title="Microeconomics",Credits=3, Department = departments[3]},
                    new Course{Id=4041,Title="Macroeconomics",Credits=3, Department = departments[3]},
                    new Course{Id=1045,Title="Calculus",Credits=4, Department = departments[1]},
                    new Course{Id=3141,Title="Trigonometry",Credits=4, Department = departments[1]},
                    new Course{Id=2021,Title="Composition",Credits=3, Department = departments[0]},
                    new Course{Id=2042,Title="Literature",Credits=4, Department = departments[0]}
                };

                var officeAssignments = new OfficeAssignment[]
                {
                    new OfficeAssignment {
                        Instructor = instructors[1],
                        Location = "Smith 17" },
                    new OfficeAssignment {
                        Instructor = instructors[2],
                        Location = "Gowan 27" },
                    new OfficeAssignment {
                        Instructor = instructors[3],
                        Location = "Thompson 304" },
                };

                context.OfficeAssignments.AddRange(officeAssignments);

                var courseAssignments = new CourseAssignment[]
                {
                    new CourseAssignment {
                        Course = courses[0],
                        Instructor = instructors[3] },
                    new CourseAssignment {
                        Course = courses[0],
                        Instructor = instructors[2] },
                    new CourseAssignment {
                        Course = courses[1],
                        Instructor = instructors[4] },
                    new CourseAssignment {
                        Course = courses[2],
                        Instructor = instructors[4] },
                    new CourseAssignment {
                        Course = courses[3],
                        Instructor = instructors[1] },
                    new CourseAssignment {
                        Course = courses[4],
                        Instructor = instructors[2] },
                    new CourseAssignment {
                        Course = courses[5],
                        Instructor = instructors[0] },
                    new CourseAssignment {
                        Course = courses[6],
                        Instructor = instructors[0] },
                };

                context.CourseAssignments.AddRange(courseAssignments);

                var enrollments = new Enrollment[]
                {
                    new Enrollment{Student = students[0],Course = courses[0],Grade=Grade.A},
                    new Enrollment{Student = students[0],Course = courses[1],Grade=Grade.C},
                    new Enrollment{Student = students[0],Course = courses[2],Grade=Grade.B},
                    new Enrollment{Student = students[1],Course = courses[3],Grade=Grade.B},
                    new Enrollment{Student = students[1],Course = courses[4],Grade=Grade.F},
                    new Enrollment{Student = students[1],Course = courses[5],Grade=Grade.F},
                    new Enrollment{Student = students[2],Course = courses[0]},
                    new Enrollment{Student = students[3],Course = courses[0]},
                    new Enrollment{Student = students[3],Course = courses[1],Grade=Grade.F},
                    new Enrollment{Student = students[4],Course = courses[2],Grade=Grade.C},
                    new Enrollment{Student = students[5],Course = courses[3]},
                    new Enrollment{Student = students[6],Course = courses[4],Grade=Grade.A},
                };
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}