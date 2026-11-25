
using TallerMantenimiento.Models;

List<Cliente> clientes = new();
int siguienteId = 1;

while (true)
{
    Console.Clear();
    MostrarMenu();

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            RegistrarCliente(clientes, ref siguienteId);
            break;

        case "0":
            Console.WriteLine("\nSaliendo del sistema...");
            return;

        default:
            Console.WriteLine("\nOpción no válida.");
            break;
    }

    Console.Write("\nPresiona ENTER para volver al menú...");
    Console.ReadLine();
}

static void MostrarMenu()
{
    Console.WriteLine("========================================");
    Console.WriteLine("       TALLER DE MANTENIMIENTO");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine("             MENÚ PRINCIPAL");
    Console.WriteLine();
    Console.WriteLine("  [1] Registrar cliente");
    Console.WriteLine("  [0] Salir");
    Console.WriteLine();
    Console.WriteLine("---------------------------------------");
    Console.Write("Seleccione una opción: ");
}

static void RegistrarCliente(List<Cliente> clientes, ref int siguienteId)
{
    Console.Clear();
    Console.WriteLine("=== REGISTRO DE CLIENTE ===\n");

    string nombre = SolicitarNombre();
    string telefono = SolicitarTelefono();

    Cliente cliente = new Cliente
    {
        Id = siguienteId++,
        Nombre = nombre,
        Telefono = telefono
    };

    clientes.Add(cliente);

    Console.Clear();
    Console.WriteLine("¡CLIENTE REGISTRADO CORRECTAMENTE!");
    MostrarFichaCliente(cliente);
}

static string SolicitarNombre()
{
    while (true)
    {
        Console.Write("Nombre del cliente: ");
        string nombre = (Console.ReadLine() ?? "").Trim();

        if (!string.IsNullOrWhiteSpace(nombre))
            return nombre;

        Console.WriteLine("\nEl nombre es obligatorio.\n");
    }
}

static string SolicitarTelefono()
{
    while (true)
    {
        Console.Write("Teléfono: ");
        string telefono = (Console.ReadLine() ?? "").Trim();

        if (telefono.Length > 0 &&
            telefono.All(c => c >= '0' && c <= '9'))
        {
            return telefono;
        }

        Console.WriteLine("\nTeléfono inválido. Solo se permiten números.\n");
    }
}

static void MostrarFichaCliente(Cliente cliente)
{
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("           FICHA DEL CLIENTE");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"  ID:        {cliente.Id:D3}");
    Console.WriteLine($"  Nombre:    {cliente.Nombre}");
    Console.WriteLine($"  Teléfono:  {cliente.Telefono}");
    Console.WriteLine("----------------------------------------");
}
