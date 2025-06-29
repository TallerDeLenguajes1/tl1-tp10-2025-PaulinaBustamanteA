using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

class Address
{
    public string Street { get; set; }
    public string Suite { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
}

class Usuario
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
}

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        Console.WriteLine("Obteniendo lista de usuarios...");

        string respuesta = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

        // Convertimos el JSON en una lista de usuarios
        List<Usuario> listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(respuesta);

        Console.WriteLine("\n--- Primeros 5 usuarios ---");

        for (int i = 0; i < 5; i++)
        {
            var usuario = listaUsuarios[i];

            // Verificamos que la dirección no sea nula
            if (usuario.Address != null)
            {
                Console.WriteLine($"Nombre: {usuario.Name}");
                Console.WriteLine($"Email : {usuario.Email}");
                Console.WriteLine($"Dirección: {usuario.Address.Street}, {usuario.Address.City}");
            }
            else
            {
                Console.WriteLine($"Nombre: {usuario.Name}");
                Console.WriteLine($"Email : {usuario.Email}");
                Console.WriteLine("Dirección: No disponible.");
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}
