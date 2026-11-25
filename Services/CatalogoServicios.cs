namespace TallerMantenimiento.Services;

public static class CatalogoServicios
{
    private static readonly string[] servicios =
    {
        "Cambio de aceite",
        "Revisión de frenos",
        "Mantenimiento general",
        "Diagnóstico del vehículo",
        "Reparación de motor"
    };

    public static void MostrarServicios()
    {
        Console.WriteLine("\n=== SERVICIOS DISPONIBLES ===");

        for (int i = 0; i < servicios.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {servicios[i]}");
        }
    }

    public static string? ObtenerServicio(int opcion)
    {
        if (opcion < 1 || opcion > servicios.Length)
        {
            return null;
        }

        return servicios[opcion - 1];
    }
}