# IMPLEMENTACIÓN DE APIWEB USANDO NETCORE 6 C#

Ejemplo practico de la implementacion de Api Web usando C# NETCORE 6


## Aclaración de licencia para la plataforma .net <a name="License"></a>
La plataforma .net es gratuito y de código abierto, lo anterior se puede corroborar en [Net foundation](https://dotnetfoundation.org/) y en el repositorio de la plataforma en [GitHub](https://github.com/dotnet), tambien por parte de [Microsoft](https://dotnet.microsoft.com/en-us/platform/free)
### Servidor default de .net <a name="ServerDefault"></a>
Por defecto, la plataforma ocupa un servidor llamado **Kestrel** que al igual que **.net** tambien es de [código abierto](https://github.com/dotnet/aspnetcore/tree/main/src/Servers/Kestrel)
## INSTALACION NECESARIA
Para ejecutar el proyecto tener instalado la herramienta de NETCORE 6
Para el desarrollo se requiere del **SDK** de .net. El cual se puede obtener de dos formas: la primera es mediante el  [SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) y la segunda es mediante el IDE de [Visual Studio Community 2022](https://visualstudio.microsoft.com/es/vs/). En este readme se instalará solamente el SDK.


## COMANDOS PARA INICIAR EL PROYECTO
Construir la Api Web
`dotnet build`

Ejecutar Api
`dotnet run`

## PUERTO EXPUESTO
Por defecto el puerto es:

`PORT: 7062`

## RUTA SWAGGER
Documentacion de la Api con Swagger

`/localhost:PORT/swagger`
