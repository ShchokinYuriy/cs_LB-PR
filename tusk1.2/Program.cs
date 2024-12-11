using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace task1._2
{
    public class Conference
    {
        public string ConferenceName { get; set; }
        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public string Title { get; set; }
        public DateTime Start { get; set; } 
        public int Duration { get; set; }   
        public Speaker Speaker { get; set; }
    }

    public class Speaker
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
    }

    
    public class EventConverter : JsonConverter<Event>
    {
        public override Event Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var json = JsonDocument.ParseValue(ref reader);
            var root = json.RootElement;

            return new Event
            {
                Title = root.GetProperty("Title").GetString(),
                Start = DateTime.Parse(root.GetProperty("StartTime").GetString()),
                Duration = root.GetProperty("DurationInMinutes").GetInt32() * 60, 
                Speaker = JsonSerializer.Deserialize<Speaker>(root.GetProperty("Speaker").GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
        {
            throw new NotImplementedException(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new EventConverter() },
                PropertyNameCaseInsensitive = true
            };

            string json = File.ReadAllText("C:/Users/Yura/Desktop/Task1/task1.2/conference.json");

            var conference = JsonSerializer.Deserialize<Conference>(json, options);

            Console.WriteLine($"Conference Name: {conference.ConferenceName}\n");
            foreach (var e in conference.Events)
            {
                Console.WriteLine($"Title: {e.Title}");
                Console.WriteLine($"Start: {e.Start}");
                Console.WriteLine($"Duration: {e.Duration} seconds");
                Console.WriteLine($"Speaker: {e.Speaker.Name} ({e.Speaker.ExperienceYears} years experience)\n");
            }

            Console.ReadLine();
        }
    }
}
