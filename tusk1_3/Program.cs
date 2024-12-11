using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace task1_3
{
    public class Report
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {

            writer.WriteStringValue(value.ToString("dd MMMM yyyy"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var report = new Report
            {
                Title = "Annual Performance Report",
                Date = DateTime.Now, 
                Author = "Anatoly Batycovich Vakula"
            };

            var options = new JsonSerializerOptions
            {
                Converters = { new CustomDateTimeConverter() },
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(report, options);

            File.WriteAllText("report.json", json);
            Console.WriteLine("JSON записано у файл report.json");

            string loadedJson = File.ReadAllText("report.json");
            var deserializedReport = JsonSerializer.Deserialize<Report>(loadedJson, options);

            Console.WriteLine("\nДесеріалізований об'єкт:");
            Console.WriteLine($"Title: {deserializedReport.Title}");
            Console.WriteLine($"Date: {deserializedReport.Date}");
            Console.WriteLine($"Author: {deserializedReport.Author}");

            Console.ReadLine();
        }
    }
}
