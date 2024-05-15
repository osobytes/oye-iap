# Aplicaci�n web Blazor con ejemplo de EF Core

Este ejemplo ilustra el uso de los escenarios de Blazor Web App EF Core descritos en la documentaci�n de Blazor.

Esta Aplicacion Utiliza Entity Framework Core para acceder a una base de datos SQLite. La aplicaci�n muestra una lista de pel�culas y permite al usuario agregar, editar y eliminar pel�culas.

## �Qu� es Entity Framework?
Entity Framework (EF) es un ORM (Object-Relational Mapper) que permite a los desarrolladores .NET trabajar con una base de datos utilizando objetos .NET. Elimina la necesidad de la mayor�a del c�digo de acceso a datos que normalmente necesitar�as escribir. EF Core es una versi�n ligera, extensible y de c�digo abierto de Entity Framework.
Migraciones en Entity Framework
Las migraciones en Entity Framework son una forma de mantener la base de datos actualizada para que coincida con el modelo de datos de la aplicaci�n. Las migraciones incluyen la creaci�n de nuevas tablas, la modificaci�n de tablas existentes y otros cambios en la base de datos.
Dado que ya se ha creado una migraci�n inicial, puedes aplicar esta migraci�n y todas las migraciones futuras utilizando los siguientes pasos:

## Instalacion de Entity Framework
1. Instalar Entity Framework Core: Para instalar Entity Framework Core, abre una terminal y ejecuta el siguiente comando:
```bash
dotnet tool install --global dotnet-ef
```

## Migraciones de BD
1.	Aplicar las migraciones: Para aplicar todas las migraciones pendientes, abre una terminal en el directorio ra�z de tu proyecto (donde se encuentra el archivo .csproj) y ejecuta el siguiente comando

``` bash
dotnet ef database update
```

Este comando aplicar� todas las migraciones pendientes. Si quieres aplicar una migraci�n espec�fica, puedes especificar su nombre:
```bash
dotnet ef database update NombreDeLaMigracion
```

2.	Crear nuevas migraciones: Si realizas cambios en tus modelos que requieren cambios en la base de datos, puedes crear una nueva migraci�n con el siguiente comando:
```bash
dotnet ef migrations add NombreDeLaMigracion
```

Reemplaza `NombreDeLaNuevaMigracion` con un nombre que describa los cambios que est�s realizando.

3.	Revertir migraciones: Si necesitas deshacer una migraci�n, puedes utilizar el siguiente comando:
```bash
dotnet ef database update NombreDeLaMigracionAnterior
```

Este comando revertir� la base de datos al estado de `NombreDeLaMigracionAnterior`.
Recuerda que las migraciones pueden modificar tu esquema de base de datos, por lo que siempre es una buena idea hacer una copia de seguridad de tu base de datos antes de aplicar migraciones.