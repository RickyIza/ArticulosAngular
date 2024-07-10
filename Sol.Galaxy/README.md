# Crear la Base de Datos con Entity Framework en .NET

Para crear la base de datos usando Entity Framework (EF) Core en un proyecto con múltiples capas en .NET, sigue estos pasos:

## 1. Instala las herramientas de EF Core CLI

Si aún no has instalado las herramientas de línea de comandos de EF Core, ejecuta el siguiente comando:

```bash
dotnet tool install --global dotnet-ef
```

## 2. Crear el Migration

En la consola de comandos, debemos ubicarnos en la carpeta base de la Solucion y ejecutar el siguiente comando:

```bash
dotnet ef migrations add MigracionBDSQL --project Sol.Galaxy.Data --startup-project Sol.Galaxy.MinimalApi
```

## 2. Ejecuta la Migration

En la misma consola de comandos, debemos ejecutar el siguiente comando:

```bash
dotnet ef database update --project Sol.Galaxy.Data --startup-project Sol.Galaxy.MinimalApi

```