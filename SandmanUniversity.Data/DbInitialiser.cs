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

                var courses = new Course[]
                {
                    new Course{Id=1050,Title="Chemistry",Credits=3},
                    new Course{Id=4022,Title="Microeconomics",Credits=3},
                    new Course{Id=4041,Title="Macroeconomics",Credits=3},
                    new Course{Id=1045,Title="Calculus",Credits=4},
                    new Course{Id=3141,Title="Trigonometry",Credits=4},
                    new Course{Id=2021,Title="Composition",Credits=3},
                    new Course{Id=2042,Title="Literature",Credits=4}
                };

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