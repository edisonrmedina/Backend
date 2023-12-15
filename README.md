README: Ejecución de dos Microservicios en .NET con Creación de Base de Datos

Este README proporciona instrucciones detalladas para ejecutar dos microservicios en .NET y establecer una base de datos llamada 'DBACCOUNT'. Asegúrese de seguir los pasos proporcionados para una configuración exitosa.

1. Clonar el Repositorio
Clona el repositorio en tu máquina local:

bash
Copy code
git clone https://github.com/edisonrmedina/Backend.git
2. Configuración de la Base de Datos
Abre tu servidor de base de datos SQL Server y crea una nueva base de datos llamada 'DBACCOUNT'.
3. Configuración de la Cadena de Conexión
En ambos microservicios (por ejemplo, Microservicio1 y Microservicio2), encuentra el archivo appsettings.json.

Dentro de cada archivo appsettings.json, busca la sección de configuración de la cadena de conexión a la base de datos. Debería verse algo así:

json
Copy code
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DBACCOUNT;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Reemplaza la cadena de conexión por la tuya, asegurándote de que coincida con la configuración de tu servidor de base de datos.

4. Compilación y Ejecución de Microservicios
Abre una terminal en el directorio de cada microservicio y ejecuta los siguientes comandos:

bash
Copy code
cd Microservicio1
dotnet build
dotnet run
bash
Copy code
cd Microservicio2
dotnet build
dotnet run
5. Acceso a los Microservicios
Después de ejecutar ambos microservicios, deberían estar disponibles en las siguientes direcciones:

clientMicroservicie: https://localhost:7238/
accountMicroservice: https://localhost:7239/

6. Verificación
Puedes verificar si los microservicios están funcionando correctamente accediendo a las siguientes URL:

8. ¡Listo!
Ahora deberías tener ambos microservicios en ejecución y conectados a la base de datos 'DBACCOUNT'. Asegúrate de realizar los pasos de configuración correctamente y ajustar las configuraciones según sea necesario. ¡Disfruta desarrollando con .NET!
