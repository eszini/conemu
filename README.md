# Create ConEmu Terminals for a Project Environment

This project contains utilities and configuration files to automatically generate:

- A Windows shortcut named after the project (e.g. `Project.lnk`)
- A ConEmu Task with:
  - Task parameters (working directory, etc.)
  - A list of terminals (tabs) to create with predefined names and paths

## Example Project Layout

For a project environment like the following:

- `C:\per`  
  Root for everything

- `C:\per\pro`  
  Root for all projects

- `C:\per\pro\proy_name`  
  Root for project **proy_name**

- `C:\per\pro\proy_name\src`  
  Directory for source files

- `C:\per\pro\proy_name\build`  
  Directory for build artifacts / generated binaries

- `C:\per\pro\proy_name\env`  
  Directory for environment scripts (e.g. setting environment variables)

- `C:\per\pro\proy_name\doc`  
  Directory for documentation

The tool can generate a ConEmu Task with multiple terminals (tabs), for example:

- A **Root** terminal at `C:\per\pro\proy_name`
- A **Src** terminal at `C:\per\pro\proy_name\src`
- A **Build** terminal at `C:\per\pro\proy_name\build`
- Additional custom terminals as defined in the configuration file

