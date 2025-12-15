# Requisitos para la herramienta ConEmu Project Helper

## Software

1. **Sistema operativo**
   - Windows 10 o superior.

2. **Visual Studio**
   - Visual Studio 2022 instalado.
   - Workload recomendado:
     - "Desarrollo de escritorio con .NET" (o equivalente).
   - Asegurarse de tener soporte para **.NET 8**:
     - Si no aparece .NET 8 al crear un proyecto, instalar el SDK.

3. **SDK de .NET**
   - .NET SDK 8.x
   - Se puede verificar en una terminal (cmd o PowerShell):
     ```bash
     dotnet --list-sdks
     ```
     Debería aparecer alguna línea que empiece con `8.`

4. **ConEmu**
   - ConEmu instalado (por defecto en algo como `C:\Program Files\ConEmu\ConEmu64.exe`).
   - Tener claro dónde está el archivo `ConEmu64.exe` para usarlo más adelante
     al crear el acceso directo.

## Estructura de carpetas de ejemplo

- `C:\per\pro\rpt\`  → Root del proyecto de reportes.
  - `src\`
  - `build\`
  - `env\`
  - `doc\`

## Objetivo de la primera versión

- Crear una aplicación de consola en C# (.NET 8) que:
  1. Lea un archivo de configuración del proyecto (JSON).
  2. Lo deserialice en clases C#.
  3. Imprima en pantalla la información leída (proyecto + terminales).

Las versiones siguientes agregarán:
- Creación automática del acceso directo (.lnk).
- Creación / actualización de la Task en el archivo de configuración de ConEmu.


