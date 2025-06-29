using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Tarea
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        Console.WriteLine("Obteniendo tareas...");

        string respuesta = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/");

        // Convertimos el JSON en una lista de objetos Tarea
        List<Tarea> listaTareas = JsonSerializer.Deserialize<List<Tarea>>(respuesta);

        // Mostramos las tareas pendientes
        Console.WriteLine("\n--- TAREAS PENDIENTES ---");
        foreach (Tarea t in listaTareas)
        {
            if (t.Completed == false)
            {
                Console.WriteLine(t.Title);
            }
        }

        // Mostramos las tareas completadas
        Console.WriteLine("\n--- TAREAS COMPLETADAS ---");
        foreach (Tarea t in listaTareas)
        {
            if (t.Completed == true)
            {
                Console.WriteLine(t.Title);
            }
        }

        // Guardamos todas las tareas en un archivo
        string textoJson = JsonSerializer.Serialize(listaTareas, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("tareas.json", textoJson);

        Console.WriteLine("\nLas tareas se guardaron en el archivo tareas.json");
    }
}
