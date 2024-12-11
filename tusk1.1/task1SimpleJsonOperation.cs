using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Threme1
{

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Subjects { get; set; }
    }

    class task1SimpleJsonOperation
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
        {
            new Student { Name = "Антон", Age = 20, Subjects = new List<string> { "Математика", "Фізика" } },
            new Student { Name = "Богомдан", Age = 22, Subjects = new List<string> { "Біологія", "Хімія" } }
        };

            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("students.json", json);
            Console.WriteLine("Список студентів збережено у файл students.json");

            string loadedJson = File.ReadAllText("students.json");
            var deserializedStudents = JsonSerializer.Deserialize<List<Student>>(loadedJson);

            Console.WriteLine("\nСписок студентів після десеріалізації:");
            foreach (var student in deserializedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Subjects: {string.Join(", ", student.Subjects)}");
            }

            deserializedStudents.Add(new Student { Name = "Сергіївна", Age = 19, Subjects = new List<string> { "Комрютерна логіка", "Елемента база" } });

            deserializedStudents[0].Age = 21;


            string updatedJson = JsonSerializer.Serialize(deserializedStudents, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("students_updated.json", updatedJson);
            Console.WriteLine("\nОновлений список студентів збережено у файл students_updated.json");


            string reloadedJson = File.ReadAllText("students_updated.json");
            var updatedStudents = JsonSerializer.Deserialize<List<Student>>(reloadedJson);

            Console.WriteLine("\nОновлений список студентів:");
            foreach (var student in updatedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Subjects: {string.Join(", ", student.Subjects)}");
            }

            Console.ReadLine();
        }
    }
}