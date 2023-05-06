# ASP.NET Core Web API – Backend

En el siguiente enlace podran encontrar la API desplegada **https://www.apitevolvers.somee.com/swagger/index.html** 

Esta API está diseñada en el lenguaje C# en el entorno .Net, creada con la plantilla ASP.NET Core Web API y cuenta con la herramienta Swagger; cuenta con una arquitectura de N capas donde se separa el Modelo para que no sea impactado directamente, haciendo uso de Dtos, Interfaces y Repositorios.

Para la realización de las peticiones a la base de datos se utiliza el ORM Entity Framework. 



## Puntos a tener en cuenta

Antes de empezar con el proceso de clonación del repositorio, debemos tener en cuenta los siguientes requisitos:
- Visual studio code 2022
- SqlServer 2019+



Una vez clonado el repositorio debemos ingresar al archivo appsettings.json y modificar el parámetro Server a la variable DefaultConnection por el nombre de nuestro servidor local SQLServer.

Abrir la consola del administrador de paquetes y digitar el comando add-migration myNewMitration y presionamos la tecla enter.

Una vez se ejecute por completo, digitamos le siguiente comando update-database y presionamos la tecla enter (Estos anteriores comandos nos permiten crear la base de datos en nuestro SQLServer según los parámetros establecidos en nuestro contexto).

Ejecutamos la aplicación y ya podemos hacer uso de nuestra API con la ayuda de la interfaz que nos brinda Swagger.
