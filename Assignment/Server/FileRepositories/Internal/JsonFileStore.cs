using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileRepositories.Internal;

public class JsonFileStore<T> where T : class
{
    private readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };
    public string path { get; }

    public JsonFileStore(string path)
    {
        var baseDirectory = AppContext.BaseDirectory;
        var dataDirectory = System.IO.Path.Combine(baseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        this.path = System.IO.Path.Combine(dataDirectory, path);
        if (!File.Exists(this.path))
        {
            File.WriteAllText(this.path, "[]");
        }
    }

    public async Task<List<T>> LoadAsync()
    {
        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
    }

    public async Task SaveAsync(List<T> list)
    {
        var json = JsonSerializer.Serialize(list, _options);
        await File.WriteAllTextAsync(path, json);
    }
    
}
