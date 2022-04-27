using Lab2Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Linq
{
    public static class DbHandler
    {
        public static string GetTeacherByCourseName(string search)
        {
            using SchoolContext context = new SchoolContext();

            Console.Clear();
            return context.Courses
                .Where(c => c.Name.Contains(search))
                .Select(c => c.Teacher.Name)
                .FirstOrDefault();
        }
        public static List<object> GetEveryStudentAndTeacher()
        {
            using SchoolContext context = new();
            List<object> allStudentsTeachers = new();
            foreach (var item in context.Classes.Include(c => c.Students).Include("Courses.Teacher"))
            {
                var classTeachers = new
                {
                    className = item.Name,
                    studentNames = item.Students.Select(s => s.Name).ToList(),
                    teacherNames = item.Courses.Select(c => c.Teacher.Name).ToList()
                };
                
                allStudentsTeachers.Add(classTeachers);
            }
            return allStudentsTeachers;
        }

        public static object GetStudentsByCourseName(string search)
        {
            using SchoolContext context = new SchoolContext();
            List<string> studentNames = new();
            List<string> teacherNames = new();

            var course = context.Courses
                .Where(c => c.Name.Contains(search))
                .FirstOrDefault();
            var students = context.Classes
                .Include(c => c.Students)
                .Where(c => c.Courses
                .Contains(course))
                .Select(c => c.Students);
            var teachers = context.Teachers
               .Where(t => t.Courses
               .Contains(course));
            
            foreach (var item in students)
                foreach(var student in item)
                    studentNames.Add(student.Name);
            foreach (Teacher teacher in teachers)
                teacherNames.Add(teacher.Name);

            return new
            {
                courseName = course.Name,
                studentNames = studentNames,
                teacherNames = teacherNames
            };
        }

        public static bool ChangeCourseName(string search)
        {
            using SchoolContext context = new SchoolContext();

            var course = context.Courses
                .Where(c => c.Name
                .Contains(search))
                .FirstOrDefault();
            Console.WriteLine($"Current name: {course.Name}");
            Console.WriteLine("Enter new name:");
            var newcourseName = Console.ReadLine();
            course.Name = newcourseName;
            context.SaveChanges();
            return true;
        }
        public static bool ChangeTeacherForCourse(string search)
        {
            using SchoolContext context = new SchoolContext();

            Console.Clear();
            var course = context.Courses
                .Include(c => c.Teacher)
                .Where(c => c.Name
                .Contains(search))
                .FirstOrDefault();

            var teachers = context.Teachers
                .Where(t => t.Id != course.Teacher.Id)
                .ToList();

            Console.WriteLine(course.Name);
            Console.WriteLine($"Current teacher: {course.Teacher.Name}");
            Console.WriteLine("Choose new teacher by id:");

            foreach (var teacher in teachers)
                Console.WriteLine($"{teacher.Id}. {teacher.Name}");

            int inputId = Int32.Parse(Console.ReadLine());

            course.Teacher = context.Teachers
                                    .Where(t => t.Id.Equals(inputId))
                                    .FirstOrDefault();
            context.SaveChanges();

            return true;
        }

    }
}
