# IngWeb_Minicore_Notas

## Asignación

En este repositorio se aloja el proyecto para la asignación de Minicore para el tercer progreso de Ingeniería Web. El objetivo de este proyecto es implementar un sistema que permita recibir datos de entrada que se utilicen para filtrar los datos de la aplicación. En este caso, la aplicación es una aplicación web de una sola pantalla que permite registrar estudiantes y calificaciones. Ademas, se puede calcular la calificación final necesaria para cada estudiante considerando las calificaciones en un rango de fechas determinado.

## Desarrollo

Para esta asignación, se utilizó .NET Core 8 y SQL Server. Se utilizó un modelo MVC conformado por los siguientes archivos:
  #### Modelos
  Estudiante -> Esta clase consta de Id y Nombre. Se utiliza para saber a qué persona le corresponde cada calificación.
  Calificación -> Esta clase consta de Id, Fecha, Nombre y EsudianteId. La fecha se utiliza para determinar el progreso a la que corresponde la calificación, el nombre permite describir a la asignación a la que corresponde la califiación y el EstudianteId es la llave foránea que vincula a la calificación con un alumno.

## Instrucciones

Una vez clonado la solución en su máquina local, se deberá abrir en Visual Studio y ejecutar una instancia de SQLite.
- En el archivo AppSettings.json se deberá modificar el nombre del servidor en la connection string y agregar un nombre de base de datos.
- Abrir la consola de gestión de paquetes NuGET y escirbir los siguientes comandos:
    - add-migration AgregarTodo
    - update-database
 
  Después, podrá ejecutarse la aplicación utilizando cualquier navegador.

