using System;
using System.Collections.Generic;
using System.IO;


public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Courses { get; set; } = new List<int>();
}


public class Teacher
{
    public int Id { get; set; }
    public int Experience { get; set; }
    public string Name { get; set; }
    public List<int> Courses { get; set; } = new List<int>();
}


public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Teacher { get; set; }
    public List<int> Students { get; set; } = new List<int>();
}


public abstract class EducationFactory
{
    public abstract Student CreateStudent(int id, string name);
    public abstract Teacher CreateTeacher(int id, int experience, string name);
    public abstract Course CreateCourse(int id, string name, int teacher);
}


public class EducationFactoryImpl : EducationFactory
{
    public override Student CreateStudent(int id, string name)
    {
        return new Student
        {
            Id = id,
            Name = name
        };
    }

    public override Teacher CreateTeacher(int id, int experience, string name)
    {
        return new Teacher
        {
            Id = id,
            Experience = experience,
            Name = name
        };
    }

    public override Course CreateCourse(int id, string name, int teacher)
    {
        return new Course
        {
            Id = id,
            Name = name,
            Teacher = teacher
        };
    }
}

public class Program
{
    public static void Main()
    {
        EducationFactory factory = new EducationFactoryImpl();

        List<Student> ListStud = new List<Student>();
        ListStud.Add(factory.CreateStudent(1, "Alice"));
        ListStud.Add(factory.CreateStudent(2, "Ivan"));

        List<Teacher> ListTeacher = new List<Teacher>();
        ListTeacher.Add(factory.CreateTeacher(1, 5, "Prof. Smith"));
        ListTeacher.Add(factory.CreateTeacher(2, 15, "Prof. Oppenheimer"));

        List<Course> ListCourse = new List<Course>();
        ListCourse.Add(factory.CreateCourse(1, "Math", ListTeacher[0].Id));
        ListCourse.Add(factory.CreateCourse(2, "Physics", ListTeacher[1].Id));

        ListStud[0].Courses.Add(ListCourse[1].Id);
        ListStud[1].Courses.Add(ListCourse[0].Id);
        ListTeacher[0].Courses.Add(ListCourse[0].Id);
        ListTeacher[1].Courses.Add(ListCourse[1].Id);
        ListCourse[0].Students.Add(ListStud[1].Id);
        ListCourse[1].Students.Add(ListStud[0].Id);

        using (StreamWriter writer = new StreamWriter("info.txt", false))
        {
            foreach (var stud in ListStud)
            {
                writer.WriteLineAsync($"Student id = {stud.Id}, Name = {stud.Name}, Courses = {string.Join(", ", stud.Courses)}");
                Console.WriteLine($"Student id = {stud.Id}, Name = {stud.Name}, Courses = {string.Join(", ", stud.Courses)}");
            }
            foreach (var teach in ListTeacher)
            {
                writer.WriteLineAsync($"Teacher id = {teach.Id}, Name = {teach.Name}, Exp = {teach.Experience}, Courses = {string.Join(", ", teach.Courses)}");
                Console.WriteLine($"Teacher id = {teach.Id}, Name = {teach.Name}, Exp = {teach.Experience}, Courses = {string.Join(", ", teach.Courses)}");
            }
            foreach (var course in ListCourse)
            {
                writer.WriteLineAsync($"Course id = {course.Id}, Name = {course.Name}, Teacher id = {course.Teacher}, Students id = {string.Join(", ", course.Students)}");
                Console.WriteLine($"Course id = {course.Id}, Name = {course.Name}, Teacher id = {course.Teacher}, Students id = {string.Join(", ", course.Students)}");
            }
        }
        Console.ReadLine();
    }
}
