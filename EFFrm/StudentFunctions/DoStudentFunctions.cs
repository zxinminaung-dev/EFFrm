using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFFrm.StudentFunctions
{
    //same assembly
    internal static class DoStudentFunctions
    {
        private static DatabaseContext _context;
        public static void AddStudent(DatabaseContext context)
        {
          _context = context;
            Console.WriteLine("Adding Student");

            //student instance
            Student student = new Student();    

            Console.WriteLine("Enter Student Name");
            string name = Console.ReadLine();
            student.name = name;

            Console.WriteLine("Enter Department Id");
            string tempDeptId = Console.ReadLine();
            int deptId = Convert.ToInt32(tempDeptId);
            student.departmentId= deptId;

            //using (DatabaseContext context = new DatabaseContext())
            //{
            _context.Student.Add(student);
            _context.Entry(student).State = EntityState.Added;
            _context.SaveChanges();
                int id = (int)student.GetType().GetProperty("id").GetValue(student);
                Console.WriteLine($"Inserted Id = {id}");
            //}

        }
        public static void GetStudentList()
        {
            using(var context = new DatabaseContext())
            {
                List<Student> students = context.Student.Include(s => s.Department).ToList();
                foreach(var student in students)
                {
                    Console.WriteLine($"Student Id = {student.id}");
                    Console.WriteLine(student.name);
                    Console.WriteLine(student.Department.name);
                }
            }
        }
        public static void GetStudenById()
        {
            Console.WriteLine("Enter student id");
            string tempId = Console.ReadLine();
            //int id = Convert.ToInt32(tempId);
            using (var context = new DatabaseContext())
            {
                Student student = context.Student.Include(s => s.Department).Where(x=>x.id==Convert.ToInt32(tempId)).FirstOrDefault();
                Console.WriteLine(student.name);
                Console.WriteLine(student.Department.name);                
            }
        }
        public static void UpdateStudent()
        {
            Console.WriteLine("Updating Student");            

            using (var context = new DatabaseContext())
            {
                //student instance
                Console.WriteLine("Enter Student Id");
                string tempId = Console.ReadLine();
                int id = Convert.ToInt32(tempId);
                Student student = context.Student.Where(x => x.id == id).Include(s=>s.Department).FirstOrDefault();

                Console.WriteLine("Old Student Name : "+ student.name);
                Console.WriteLine("Enter New Student Name");
                string name = Console.ReadLine();
                student.name = name;

                Console.WriteLine("Old Department Id : " + student.Department.id);
                Console.WriteLine("Old Department Name : "+ student.Department.name);
                Console.WriteLine("Enter New Department Id");
                string tempDeptId = Console.ReadLine();
                int deptId = Convert.ToInt32(tempDeptId);
                student.departmentId = deptId;
                context.Student.Add(student);
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
                int updatedId =(int)student.GetType().GetProperty("id").GetValue(student);
                Console.WriteLine($"updated id = {updatedId}");
            }
        }
        public static void DeleteStudent()
        {
            Console.WriteLine("Enter Student Id");
            string tempId = Console.ReadLine() ;
            int id = Convert.ToInt32(tempId);
            using(var context = new DatabaseContext())
            {
                Student student = context.Student.Where(x => x.id == id).FirstOrDefault();
                context.Student.Remove(student);
                context.Entry(student).State = EntityState.Deleted;
                context.SaveChanges();
                int deletedId = (int)student.GetType().GetProperty("id").GetValue(student);
                Console.WriteLine($"Deleted Record Id = {id}");
            }
        }
        public static void GetStudentListWithTake()
        {
            Console.WriteLine("Enter record you want to take");
            string tempTake= Console.ReadLine();
            int take = Convert.ToInt32(tempTake);
            using (var context = new DatabaseContext())
            {
                int count = 0 ;
                List<Student> students = context.Student.Include(s => s.Department).Take(take).ToList();
                foreach (var student in students)
                {
                    count++;
                    Console.WriteLine($"Student {count}");
                    Console.WriteLine(student.name);
                    Console.WriteLine(student.Department.name);
                }
            }
        }
        public static void GetStudentListWithSkip()
        {
            Console.WriteLine("Enter record you want to skip");
            string tempSkip = Console.ReadLine();
            int skip = Convert.ToInt32(tempSkip);
            using (var context = new DatabaseContext())
            {
                int count = 0;
                List<Student> students = context.Student.Include(s => s.Department).Skip(skip).ToList();
                foreach (var student in students)
                {
                    count++;
                    Console.WriteLine($"Student {count}");
                    Console.WriteLine(student.name);
                    Console.WriteLine(student.Department.name);
                }
            }
        }

        internal static void GetStudentListWithTakeAndSkip()
        {
            Console.WriteLine("Enter record you want to take");
            string tempTake = Console.ReadLine();

            Console.WriteLine("Enter record you want to skip");
            string tempSkip= Console.ReadLine();    

            int take = Convert.ToInt32(tempTake);
            int skip = Convert.ToInt32(tempSkip);

            using(var context = new DatabaseContext())
            {
                List<Student> studentList = context.Student.Take(take).Skip(skip).ToList();
                //studentList = studentList.Take(take).ToList();
                //studentList= studentList.Skip(skip).ToList();   
                int count = 0;
              
                foreach (var student in studentList)
                {
                    count++;
                    Console.WriteLine($"Student {count}");
                    Console.WriteLine(student.name);
                    //Console.WriteLine(student.Department.name);
                }
            }
        }
    }
}
