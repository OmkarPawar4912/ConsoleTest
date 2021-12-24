using System.Collections.Generic;
using System;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        public static List<Course> courses = new()
        {
            new Course { CID = 101, CourseName = "ASP.NET" },
            new Course { CID = 102, CourseName = ".NET" },
            new Course { CID = 103, CourseName = "C#" },
            new Course { CID = 104, CourseName = "PHP" },
            new Course { CID = 105, CourseName = "JAVA" }
        };
        public static List<Teacher> teachers = new()
        {
            new Teacher { TID = 201, Name = "Teacher1" },
            new Teacher { TID = 202, Name = "Teacher2" },
            new Teacher { TID = 203, Name = "Teacher3" }
        };
        public static List<Student> students = new()
        {
            new Student { ID = 1, StudentName = "StudentName1", TeacherID = 202, CourseID = 103 },
            new Student { ID = 2, StudentName = "StudentName2", TeacherID = 202, CourseID = 103 },
            new Student { ID = 3, StudentName = "StudentName3", TeacherID = 201, CourseID = 102 },
            new Student { ID = 4, StudentName = "StudentName4", TeacherID = 202, CourseID = 101 },
            new Student { ID = 5, StudentName = "StudentName5", TeacherID = 201, CourseID = 103 },
            new Student { ID = 6, StudentName = "StudentName6", TeacherID = 203, CourseID = 105 },
            new Student { ID = 6, StudentName = "StudentName6", TeacherID = 203, CourseID = 105 },
        };

        public static string[] arr1 = { "a", "b", "c", "d" };

        public static string[] arr2 = { "c", "d", "e", "f" };
        static void Main(string[] args)
        {
            //All Get Collections Show
            Show();

            //Where
            Console.WriteLine();
            QWhere();

            //Select
            Console.WriteLine();
            QSelect();

            //OrderBy and ThenBy
            Console.WriteLine();
            QOrderBy();

            //OrderByDescending
            Console.WriteLine();
            QOrderByDescending();

            //All and any
            Console.WriteLine();
            QAllAny();

            //First and Single //orDefault
            Console.WriteLine();
            QFirstDefault();

            //Concat
            Console.WriteLine();
            QConcat();

            Console.ReadLine();
        }
        //All Get Collections
        public static void Show()
        {
            Console.WriteLine("********************************************** Courses List **********************************************");

            foreach (var c in courses)
            {
                Console.WriteLine("CourseID : " + c.CID + " \t Course Name : " + c.CourseName);
            }

            Console.WriteLine("********************************************** Teachers List **********************************************");

            foreach (var t in teachers)
            {
                Console.WriteLine("TeacherID : " + t.TID + " \t TeacherName : " + t.Name);
            }

            Console.WriteLine("********************************************** Students List **********************************************");

            foreach (var s in students)
            {
                Console.WriteLine("StudentID : " + s.ID + " \t StudentName : " + s.StudentName + " \t TeacherID : " + s.TeacherID + " \t CourseID : " + s.CourseID);
            }
        }

        //Where
        public static void QWhere()
        {
            List<Course> whereCourses = courses.Where(c => c.CID > 103).ToList();

            Console.WriteLine("******************************************* Courses List ( Where Syntax )*******************************************");

            int i = 1;
            foreach (var wc in whereCourses)
            {
                Console.WriteLine(i + ") CourseID : " + wc.CID + " \t Course Name : " + wc.CourseName);
                i++;
            }

            var wCourses = (from w in courses
                            where w.CID > 103
                            select w).ToList();

            Console.WriteLine("******************************************* Courses List ( Where query )*******************************************");
            i = 1;
            foreach (var w in wCourses)
            {
                Console.WriteLine(i + ") CourseID : " + w.CID + " \t Course Name : " + w.CourseName);
                i++;
            }
        }

        //Select
        public static void QSelect()
        {
            List<Student> selectStudent = students.ToList();

            Console.WriteLine("******************************************* Student List ( Select Syntax )*******************************************");

            int i = 1;

            foreach (var ss in selectStudent)
            {
                Console.WriteLine(i + ") StudentID : " + ss.ID + " \t Student Name : " + ss.StudentName);
                i++;
            }

            var wCourses = (from sss in students
                            select sss).ToList();

            Console.WriteLine("******************************************* Student List ( Select query )*******************************************");
            i = 1;
            foreach (var sss in wCourses)
            {
                Console.WriteLine(i + ") Student ID : " + sss.ID + " \t Student Name : " + sss.StudentName);
                i++;
            }
        }

        //OrderBy and ThenBy
        public static void QOrderBy()
        {
            var std = students.OrderBy(o => o.CourseID);
            Console.WriteLine("******************************************* Student List ( OrderBy Syntax )*******************************************");
            int i = 1;
            foreach (var ss in std)
            {
                Console.WriteLine(i + ") Courses ID : " + ss.CourseID + " \t TeacherID : " + ss.TeacherID + " \t Student Name : " + ss.StudentName);
                i++;
            }

            var os = (from ostuds in students
                      orderby ostuds.CourseID
                      select ostuds).ToList();

            Console.WriteLine("******************************************* Student List ( OrderBy query )*******************************************");
            i = 1;
            foreach (var sss in os)
            {
                Console.WriteLine(i + ") Courses ID : " + sss.CourseID + " \t TeacherID : " + sss.TeacherID + " \t Student Name : " + sss.StudentName);
                i++;
            }

            var std1 = students.OrderBy(o => o.CourseID).ThenBy(o => o.TeacherID);
            Console.WriteLine("******************************************* Student List ( ThenBy Syntax )*******************************************");
            i = 1;
            foreach (var ss in std1)
            {
                Console.WriteLine(i + ") Courses ID : " + ss.CourseID + " \t TeacherID : " + ss.TeacherID + " \t Student Name : " + ss.StudentName);
                i++;
            }

            var os1 = (from ostuds in students
                       orderby ostuds.CourseID, ostuds.TeacherID
                       select ostuds).ToList();

            Console.WriteLine("******************************************* Student List ( ThenBy query )*******************************************");
            i = 1;
            foreach (var sss in os1)
            {
                Console.WriteLine(i + ") Courses ID : " + sss.CourseID + " \t TeacherID : " + sss.TeacherID + " \t Student Name : " + sss.StudentName);
                i++;
            }
        }

        //OrderByDescending
        public static void QOrderByDescending()
        {
            var std = students.OrderByDescending(o => o.CourseID);
            Console.WriteLine("******************************************* Student List ( OrderByDescending Syntax )*******************************************");

            int i = 1;
            foreach (var ss in std)
            {
                Console.WriteLine(i + ") Courses ID : " + ss.CourseID + " \t TeacherID : " + ss.TeacherID + " \t Student Name : " + ss.StudentName);
                i++;
            }

            var os = (from ostuds in students
                      orderby ostuds.CourseID descending
                      select ostuds).ToList();

            Console.WriteLine("******************************************* Student List ( OrderByDescending query )*******************************************");
            i = 1;
            foreach (var sss in os)
            {
                Console.WriteLine(i + ") Courses ID : " + sss.CourseID + " \t TeacherID : " + sss.TeacherID + " \t Student Name : " + sss.StudentName);
                i++;
            }

            var std1 = students.OrderByDescending(o => o.CourseID).ThenBy(o => o.TeacherID);
            Console.WriteLine("******************************************* Student List ( OrderByDescending ThenBy Syntax )*******************************************");
            i = 1;
            foreach (var ss in std1)
            {
                Console.WriteLine(i + ") Courses ID : " + ss.CourseID + " \t TeacherID : " + ss.TeacherID + " \t Student Name : " + ss.StudentName);
                i++;
            }

            var os1 = (from ostuds in students
                       orderby ostuds.CourseID descending, ostuds.TeacherID
                       select ostuds).ToList();

            Console.WriteLine("******************************************* Student List (OrderByDescending ThenBy query )*******************************************");
            i = 1;
            foreach (var sss in os1)
            {
                Console.WriteLine(i + ") Courses ID : " + sss.CourseID + " \t TeacherID : " + sss.TeacherID + " \t Student Name : " + sss.StudentName);
                i++;
            }
        }

        //All and Any and Contain
        public static void QAllAny()
        {
            bool stud1 = students.All(s => s.StudentName.Contains("StudentName6"));
            Console.WriteLine("All (StudentName6) : {0}", stud1);

            bool stud2 = students.All(s => s.StudentName.Contains("StudentName"));
            Console.WriteLine("All (StudentName) : {0}", stud2);

            bool stud3 = students.Any(s => s.StudentName.Contains("StudentName6"));
            Console.WriteLine("Any (StudentName6) : {0}", stud3);

            bool stud4 = students.Any(s => s.StudentName.Contains("StudentName"));
            Console.WriteLine("Any (StudentName) : {0}", stud4);

            List<Student> stud5 = students.Where(i => i.StudentName.Contains("StudentName6")).ToList();
            Console.WriteLine("\n Contains (StudentName6): ");
            foreach (var s in stud5)
            {
                Console.WriteLine("StudentID : " + s.ID + " \t StudentName : " + s.StudentName + " \t TeacherID : " + s.TeacherID + " \t CourseID : " + s.CourseID);
            }
        }

        //FirstDefault
        public static void QFirstDefault()
        {
            var s = students.First(f => f.StudentName.Equals("StudentName6"));
            Console.WriteLine("Matching Records (First) : Student ID : {0} | Student Name : {1} | Teacher ID : {2} | Course ID : {3}", s.ID, s.StudentName, s.TeacherID, s.CourseID);

            var ss = students.FirstOrDefault(f => f.ID.Equals(12));
            if (ss != null)
                Console.WriteLine("Matching Records (FirstDefalut) : Student ID : {0} | Student Name : {1} | Teacher ID : {2} | Course ID : {3}", ss.ID, ss.StudentName, ss.TeacherID, ss.CourseID);

            var s1 = students.Single(f => f.StudentName.Equals("StudentName5"));
            Console.WriteLine("Matching Records (Single) : Student ID : {0} | Student Name : {1} | Teacher ID : {2} | Course ID : {3}", s.ID, s.StudentName, s.TeacherID, s.CourseID);

            var s2 = students.SingleOrDefault(f => f.ID.Equals(12));
            if (ss != null)
                Console.WriteLine("Matching Records (SingleDefalut) : Student ID : {0} | Student Name : {1} | Teacher ID : {2} | Course ID : {3}", ss.ID, ss.StudentName, ss.TeacherID, ss.CourseID);
        }

        //Concat
        public static void QConcat()
        {
            var result = arr1.Concat(arr2);
            foreach (var item in result)
            {
                Console.Write("| {0} ", item);
            }
        }
    }
}