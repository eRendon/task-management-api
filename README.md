# Proyecto Task-Management-API

Este es un proyecto desarrollado en .NET Core que incluye una aplicación web utilizando ASP.NET Core y una base de datos PostgreSQL.

## Requisitos Previos

Asegúrate de tener instalado lo siguiente en tu sistema:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Configuración del Proyecto

1. Clona el repositorio en tu máquina local.
2. Abre una terminal y navega hasta el directorio del proyecto.
3. Restaura las dependencias del proyecto ejecutando el siguiente comando:
`dotnet restore`


## Base de Datos

Este proyecto utiliza PostgreSQL como base de datos. Asegúrate de tener PostgreSQL instalado y configurado en tu sistema antes de continuar.

### Creación de la Base de Datos

1. Crea una nueva base de datos en PostgreSQL con el nombre `ProyectoXYZ`.

### Configuración de la Conexión a la Base de Datos

En el archivo `appsettings.json`, asegúrate de configurar la cadena de conexión a la base de datos:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ProyectoXYZ;Username=usuario;Password=contraseña"
}
```

## Ejecución del Proyecto

Para ejecutar el proyecto, utiliza el siguiente comando:
`dotnet run`

Esto iniciará la aplicación web en http://localhost:5000.

## Pruebas
Este proyecto incluye pruebas unitarias desarrolladas con xUnit y Moq. Para ejecutar las pruebas, utiliza el siguiente comando:
`dotnet test`

## Documentación API
La documentación de la API está generada con Swagger. Puedes acceder a ella navegando a http://localhost:5155/swagger/v1/swagger.json una vez que el proyecto esté en ejecución.

## Licencia
Este proyecto está bajo la Licencia MIT.
