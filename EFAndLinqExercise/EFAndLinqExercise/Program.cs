using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAndLinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SchoolDBEntities())
            {
                //- Lấy thông tin toàn bộ học sinh và lớp học.

                //var listClass = dbContext.Classes.ToList();

                //Console.WriteLine("/* ------------ CLASSES LIST --------------*/");

                //Console.WriteLine("Class ID" + "\t" + "Class Name");

                //foreach (var item in listClass)
                //{
                //    Console.WriteLine(item.ClassID + "\t\t" + item.ClassName);
                //}
                //Console.WriteLine();

                //var listStudent = dbContext.Students.ToList();
                //Console.WriteLine("/* ------------ STUDENTS LIST ---------------*/");

                //Console.WriteLine("Student ID" + "\t" + "Student Name" + "\t" + "Class ID");

                //foreach (var item in listStudent)
                //{
                //    Console.WriteLine(item.StudentID + "\t\t" + item.StudentName + "\t\t" + item.ClassID);
                //}

                // - Lấy thông tin học sinh có tên là {ten}
                //var nameStudent = dbContext.Students.Where(n => n.StudentName.Contains("Name B"));

                //Console.WriteLine("Student ID" + "\t" + "Student Name" + "\t" + "Class ID");

                //foreach (var item in nameStudent)
                //{
                //    Console.WriteLine(item.StudentID + "\t\t" + item.StudentName + "\t\t" + item.ClassID);
                //}
                //Console.WriteLine();

                // -Lấy toàn bộ thông tin hs khối { khối}
                var allInfoStudentsWithClass = from c in dbContext.Classes
                                               join s in dbContext.Students
                                               on c.ClassID equals s.ClassID
                                               where c.ClassID == 3
                                               select new
                                               {
                                                   ClassID = s.ClassID,
                                                   StudentID = s.StudentID,
                                                   StudentName = s.StudentName
                                               };

                Console.WriteLine("Class ID" + "\t" + "Student ID" + "\t" + "Student Name");

                foreach (var item in allInfoStudentsWithClass)
                {
                    Console.WriteLine(item.ClassID + "\t\t" + item.StudentID + "\t\t" + item.StudentName);
                }










                Console.ReadLine();
            }
        }
    }
}
