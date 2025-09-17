using System;

namespace CliApp.UI.Utilities;

public static class Input
{
    public static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write(label);
            var s = Console.ReadLine();
            if (int.TryParse(s, out var v)) return v;
            Console.WriteLine("Please enter a valid integer.");
        }
    }

    public static string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write(label);
            var s = (Console.ReadLine() ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(s)) return s;
            Console.WriteLine("This field is required.");
        }
    }
}
