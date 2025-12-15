using System;
using System.IO;
using System.Text.Json;
using ConEmuProjectHelper;

// Ruta por defecto del archivo de configuración
// (en la misma carpeta que el ejecutable, por ahora apuntamos al archivo del proyecto)
string defaultConfigFileName = "config_rpt.json";

// Permitir pasar el path del config por parámetro (opcional)
string configPath = args.Length > 0 ? args[0] : defaultConfigFileName;

if (!File.Exists(configPath))
{
    Console.WriteLine($"No se encontró el archivo de configuración: {configPath}");
    Console.WriteLine("Asegurate de que exista o pásalo como parámetro:");
    Console.WriteLine("  ConEmuProjectHelper.exe ruta\\a\\config_rpt.json");
    return;
}

try
{
    string json = File.ReadAllText(configPath);

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    RootConfig? config = JsonSerializer.Deserialize<RootConfig>(json, options);

    if (config == null)
    {
        Console.WriteLine("No se pudo deserializar la configuración (config == null).");
        return;
    }

    // Mostrar datos del proyecto
    Console.WriteLine("=== Proyecto ===");
    Console.WriteLine($"Nombre           : {config.Project.Name}");
    Console.WriteLine($"Root             : {config.Project.Root}");
    Console.WriteLine($"TaskName         : {config.Project.TaskName}");
    Console.WriteLine($"ShortcutName     : {config.Project.ShortcutName}");
    Console.WriteLine($"ConEmuPath       : {config.Project.ConEmuPath}");
    Console.WriteLine($"TaskDirParam     : {config.Project.TaskDirParam}");
    Console.WriteLine();

    // Mostrar terminales
    Console.WriteLine("=== Terminales ===");
    int i = 1;
    foreach (var term in config.Terminals)
    {
        Console.WriteLine($"Terminal {i}:");
        Console.WriteLine($"  SubDir : {term.SubDir}");
        Console.WriteLine($"  Title  : {term.Title}");
        Console.WriteLine($"  EnvBat : {term.EnvBat}");
        Console.WriteLine();
        i++;
    }
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrió un error al leer o parsear el archivo de configuración:");
    Console.WriteLine(ex.Message);
}

