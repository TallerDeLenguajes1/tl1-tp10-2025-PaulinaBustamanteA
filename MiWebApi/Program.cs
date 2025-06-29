using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

class DatoGato
{
    public string Fact { get; set; }
}

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        Console.WriteLine("Obteniendo dato curioso sobre gatos...");

        string respuesta = await client.GetStringAsync("https://catfact.ninja/fact");

        // Convertimos el JSON en un objeto
        DatoGato dato = JsonSerializer.Deserialize<DatoGato>(respuesta);

        Console.WriteLine("\n--- DATO SOBRE GATOS ---");
        Console.WriteLine(dato.Fact);

        // Guardamos el dato en un archivo JSON
        File.WriteAllText("datoGato.json", respuesta);

        Console.WriteLine("\nSe guardó el dato en datoGato.json");
    }
}
