using System;
using System.IO;
using System.Text.Json;
using adm_conemu; // usamos las clases RootConfig, ProjectConfig, etc.

// Nombre del archivo de configuración por defecto
string defaultConfigFileName = "config_conemu.json";

// Si se pasa un parámetro por línea de comandos, lo usamos como path;
// si no, usamos el nombre por defecto.
string configPath = args.Length > 0 ? args[0] : defaultConfigFileName;

// Mostrar dónde está buscando el archivo (útil para debug)
Console.WriteLine($"Buscando archivo de configuración: {configPath}");
Console.WriteLine();

if (!File.Exists(configPath))
{
    Console.WriteLine($"No se encontró el archivo de configuración: {configPath}");
    Console.WriteLine("Sugerencias:");
    Console.WriteLine(" - Verifica que 'config_conemu.json' esté en el mismo directorio que el ejecutable,");
    Console.WriteLine("   o pásale la ruta completa como parámetro.");
    return;
}

try
{
    // Leer el contenido del archivo JSON
    string json = File.ReadAllText(configPath);

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    // Deserializar el JSON a nuestra clase RootConfig
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

    Console.WriteLine("Fin de la lectura de configuración. (Versión A OK)");
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrió un error al leer o parsear el archivo de configuración:");
    Console.WriteLine(ex.Message);
}



