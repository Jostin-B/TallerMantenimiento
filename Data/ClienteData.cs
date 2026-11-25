using System.Text.Json;
using TallerMantenimiento.Models;

namespace TallerMantenimiento.Data;

public static class ClienteData
{
    private static readonly string carpetaDatos = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "TallerMantenimiento"
    );

    private static readonly string archivoDatos = Path.Combine(
        carpetaDatos,
        "clientes.json"
    );

    public static List<Cliente> Cargar()
    {
        if (!File.Exists(archivoDatos))
        {
            return new List<Cliente>();
        }

        string json = File.ReadAllText(archivoDatos);

        return JsonSerializer.Deserialize<List<Cliente>>(json)
               ?? new List<Cliente>();
    }

    public static void Guardar(List<Cliente> clientes)
    {
        Directory.CreateDirectory(carpetaDatos);

        JsonSerializerOptions opciones = new()
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(clientes, opciones);

        File.WriteAllText(archivoDatos, json);
    }
}
