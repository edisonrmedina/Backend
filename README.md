# Ejecución de Dos Microservicios en .NET con Base de Datos

Este README proporciona instrucciones detalladas para ejecutar dos microservicios en .NET y establecer una base de datos llamada 'DBACCOUNT'. Sigue estos pasos para una configuración exitosa.

## 1. Clonar el Repositorio

```bash
git clone https://github.com/edisonrmedina/Backend.git
```

Este README proporciona instrucciones detalladas para ejecutar dos microservicios en .NET y establecer una base de datos llamada 'DBACCOUNT'. Sigue estos pasos para una configuración exitosa.

## 2. Base de datos
Abre tu servidor de base de datos SQL Server vrea una bd llamada 'BDACCOUNT' y ejecuta el script BaseDatos.sql proporcionado en la carpeta Scripts del repositorio. 

## 3. Configuración de la Cadena de Conexión
En ambos microservicios (por ejemplo, Microservicio1 y Microservicio2), encuentra el archivo appsettings.json.

Dentro de cada archivo appsettings.json, busca la sección de configuración de la cadena de conexión a la base de datos. Debería verse algo así:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DBACCOUNT;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
## 4. Compilación y Ejecución de Microservicios
Abre una terminal en el directorio de cada microservicio y ejecuta los siguientes comandos:

```bash
cd ClientMicroservice
dotnet build
dotnet run
```
```bash
cd AccountMicroservice
dotnet build
dotnet run
```

## 5. Acceso 
 Después de ejecutar ambos microservicios, estarán disponibles en las siguientes direcciones:
ClientMicroservice: https://localhost:7238/
AccountMicroservice: https://localhost:7239/

## 7. ¡Listo!
Ahora deberías tener ambos microservicios en ejecución y conectados a la base de datos 'DBACCOUNT'. 
