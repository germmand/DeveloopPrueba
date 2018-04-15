# DSBackEnd

El proyecto fue creado bajo el _framework_ de `ASP.NET`  bajo la arquitectura/patrón `MVC` versión `5`, aunque sólo se trabaja como proyecto `WebApi`, ya que las vistas fueron desarrolladas en el proyecto de [DSFrontend](https://github.com/germmand/DeveloopPruebaFrontEnd).

## Herramientas usadas

1. Para el diseño y trabajo de la base de datos se hace uso de `EntityFramework` bajo el enfoque `Code First` haciendo uso de la `Fluent API`.
Se trató se mantener siempre una estructura limpia y organizada, por lo que las configuraciones de las relaciones se hacen en clases separadas en la carpeta "Configuraciones".

2. Se hizo uso de [AutoMapper](https://automapper.org/) para el mapeo de entidades DTO y entidades que identifican a las relaciones en la base de datos como tal.

3. Aunque las vistas se trabajan en el proyecto de [DSFrontend](https://github.com/germmand/DeveloopPruebaFrontEnd), el proyecto fue creado bajo el patrón/arquitectura `MVC`, por lo que acciones pueden retornar vistas en caso de que el controlador herede de la clase necesaria, en caso de que se quiera hacer que ciertas acciones retornen vistas, se instaló el _framework_ de diseño [Material Design for Bootstrap](https://mdbootstrap.com/). 

4. Para el recorrido del archivo Excel, el cual es envíado desde el _frontend_, se utilizó `OleDB`, el cual facilita su procesamiento ya que se trabaja las tablas de Excel con consultas `SQL`.

## Pasos para montar la aplicación

* Clonarse el proyecto: `git clone https://github.com/germmand/DeveloopPrueba.git`.
* Moverse a la carpeta clonada: `cd DeveloopPrueba`.
* Abrir la solución en Visual Studio (.sln).
* En el menú superior de Visual Studio dirigirse a `View` -> `Other Windows` -> `Package Manager Console`. 
* Hacer click en `Restore Packages` (Restaurar Paquetes), Visual Studio se encargará del resto.
* Una vez se hayan instalado todos los paquetes, ejecutar el siguiente comando en dicha consola: `update-database`.
* Correr la aplicación presionando `F5` o haciendo click en el ícono de `Start Debugging`.

## Notas
* Toda la comunicación entre el _frontend_ y el _backend_ se hace en formato `JSON`, exceptuando el _endpoint_ que recibe el archivo Excel el cual tiene un `Content-Type` de `multipart/form-data`.

## BUGS
* Cuando el formato de fecha que recibe es inválido, éste es truncado y se devuelve un _string_ vacío. Cuando el comportamiento deseado es retornar el mismo dato/_string_ que recibió adjunto con un mensaje en la respuesta indicando el formato de la fecha para que éste luego sea mostrado desde el _frontend_.
* Probablemente algún otro. 