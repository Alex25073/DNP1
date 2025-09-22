
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Exercise01;

public class Program
{
    public static void Main(string[] args)
    {
        string[] hobbies = new string[] { "Reading", "Traveling", "Cooking" };
        Person person = new Person("John", "Doe", 30, 5.9, false, 'M', hobbies);
        string[] hobbies2 = new string[] { "Painting", "Cycling" };
        Person person1 = new Person("Jane", "Smith", 28, 5.5, true, 'F', hobbies2);
        string[] hobbies3 = new string[] { "Gaming", "Hiking", "Swimming" };
        Person person2 = new Person("Alice", "Johnson", 35, 5.7, true, 'F', hobbies3);

        List<Person> people = new() { person, person1, person2 };

        string jsonString = JsonSerializer.Serialize(people);
        Console.WriteLine(jsonString);
        
        string FormatedjsonString = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(FormatedjsonString);
    }
}