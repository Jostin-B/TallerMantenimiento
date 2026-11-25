
using TallerMantenimiento.Models;
using TallerMantenimiento.Services;

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

        case "2":
            ConsultarClientes(clientes);
            break;

        case "3":
            ActualizarCliente(clientes);
            break;

        case "0":
            Console.WriteLine("\nSaliendo del sistema...");
            return;

        default:
            Console.WriteLine("\nOpción no válida. Intente nuevamente.");
            break;
    }

    Console.Write("\nPresiona ENTER para volver al menú...");
    Console.ReadLine();
}

static void MostrarMenu()
{
    Console.WriteLine("=======================================");
    Console.WriteLine("       TALLER DE MANTENIMIENTO");
    Console.WriteLine("=======================================");
    Console.WriteLine();
    Console.WriteLine("             MENÚ PRINCIPAL");
    Console.WriteLine();
    Console.WriteLine("  [1] Registrar cliente");
    Console.WriteLine("  [2] Consultar clientes");
    Console.WriteLine("  [3] Actualizar cliente");
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
    string servicio = SeleccionarServicio();

    Cliente cliente = new Cliente
    {
        Id = siguienteId++,
        Nombre = nombre,
        Telefono = telefono,
        Servicio = servicio
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

        if (!string.IsNullOrWhiteSpace(nombre) &&
            nombre.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\'') &&
            nombre.Any(char.IsLetter))
        {
            return nombre;
        }

        Console.WriteLine(
            "\nNombre inválido. Solo se permiten letras, espacios, guiones y apóstrofes.\n");
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

static string SeleccionarServicio()
{
    while (true)
    {
        CatalogoServicios.MostrarServicios();

        Console.Write("\nSeleccione el número del servicio: ");

        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine(
                "\nDebe introducir un número válido. Intente nuevamente.");
            continue;
        }

        string? servicio = CatalogoServicios.ObtenerServicio(opcion);

        if (servicio == null)
        {
            Console.WriteLine("\nEl servicio no existe. Intente nuevamente.");
            continue;
        }

        return servicio;
    }
}

static void ConsultarClientes(List<Cliente> clientes)
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("         CLIENTES REGISTRADOS");
    Console.WriteLine("========================================");

    if (clientes.Count == 0)
    {
        Console.WriteLine("\nNo hay clientes registrados.");
        return;
    }

    Console.WriteLine($"\nTotal de clientes: {clientes.Count}");

    foreach (Cliente cliente in clientes)
    {
        MostrarFichaCliente(cliente);
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
    Console.WriteLine($"  Servicio:  {cliente.Servicio}");
    Console.WriteLine("----------------------------------------");
}

static void ActualizarCliente(List<Cliente> clientes)
{
    Console.Clear();
    Console.WriteLine("=== ACTUALIZAR CLIENTE ===\n");

    if (clientes.Count == 0)
    {
        Console.WriteLine("No hay clientes registrados.");
        return;
    }

    Console.Write("Ingrese el ID del cliente: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("\nDebe introducir un ID válido.");
        return;
    }

    Cliente? cliente = clientes.Find(c => c.Id == id);

    if (cliente == null)
    {
        Console.WriteLine("\nNo se encontró un cliente con ese ID.");
        return;
    }

    MostrarFichaCliente(cliente);

    while (true)
    {
        Console.WriteLine("\n¿Qué desea modificar?");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Teléfono");
        Console.WriteLine("3. Servicio solicitado");
        Console.WriteLine("0. Cancelar");
        Console.Write("\nSeleccione una opción: ");

        string? opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                cliente.Nombre = SolicitarNombre();
                break;

            case "2":
                cliente.Telefono = SolicitarTelefono();
                break;

            case "3":
                cliente.Servicio = SeleccionarServicio();
                break;

            case "0":
                Console.WriteLine("\nActualización cancelada.");
                return;

            default:
                Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                continue;
        }

        Console.Clear();
        Console.WriteLine("¡CLIENTE ACTUALIZADO CORRECTAMENTE!");
        MostrarFichaCliente(cliente);
        return;
    }
}
