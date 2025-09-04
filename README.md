# Prueba técnica Veconinter

## Instrucciones para correr el proyecto

### Requisitos previos
1. **Instalar .NET SDK**: Asegúrate de tener instalado el SDK de .NET 8.0.
2. **Instalar PostgreSQL**: Este proyecto utiliza PostgreSQL como base de datos. Asegúrate de tenerlo instalado y configurado.
3. **Configurar las variables de entorno**:
   - `DefaultConnection`: Cadena de conexión para la base de datos PostgreSQL.
   - `JWT_KEY`: Clave secreta para la generación de tokens JWT.

### Configuración de la base de datos

> [!NOTE]
> El sistema propsuesto hace uso de una base de daos PostgreSQL. La instalación y configuración se dejan a discreción del lector, dado que la configuración puede variar entre sistemas operativos, e incluso en distribuciones de linux (paqueteria y etc...), se recomienda la opcion de la containerización, pero incluso esa podria requerir configuración adicional no contamplada en este documento.

1. **Actualizar la cadena de conexión**:
   - Abre el archivo `Backend/PersonalDataManagementSystem.API/appsettings.json`.
   - Modifica la sección `ConnectionStrings` para incluir la cadena de conexión de tu base de datos PostgreSQL:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=127.0.0.1;Database=veconinter;Username=takina;Password=takina;Search Path=public"
     }
     ```
> [!NOTE]
> No utilice localhost como host de conexión con PostgresSQL, especialmenete en SO linux dado que intentara conectarse a la BD usando el usuario y las credenciales del usuario en el sistema operativo, en lugar de las credenciales nativas de la BD.

2. **Aplicar las migraciones**:
   - Navega al directorio `Backend/PersonalDataManagementSystem.API` en la terminal.
   - Ejecuta los siguientes comandos:
     ```bash
     dotnet ef database update --project PersonalDataManagementSystem.Infrastructure/PersonalDataManagementSystem.Infrastructure.csproj --startup-project PersonalDataManagementSystem.API/PersonalDataManagementSystem.API.csproj 
     ```

### Pasos para ejecutar el proyecto
1. **Backend**:
   - Navega al directorio `Backend/PersonalDataManagementSystem.API`.
   - Ejecuta el siguiente comando:
     ```bash
     dotnet run
     ```
   - La API estará disponible en `http://localhost:5153`.

2. **Frontend**:
   - Navega al directorio [PersonalDataManagementSystem.Front](http://_vscodecontentref_/0).
   - Ejecuta el siguiente comando:
     ```bash
     dotnet run
     ```
   - La aplicación estará disponible en `http://localhost:5158`.

> [!NOTE]
> Siempre y cuando se ejecute con la configuración HTTP, si se desea utilizar IISExpress o HTTPS recuerde configurar y validar sus sertificados autofrimados.

---

## Patrones de software utilizados

### 1. **Repository Pattern**
   - **Ubicación**: 
     - BusinessObjects
   - **Descripción**: Este patrón se utiliza para abstraer la lógica de acceso a datos. Por ejemplo, las clases ClientsRepository y SubClientsRepository encapsulan las operaciones CRUD para las entidades Client y SubClient.

### 2. **Dependency Injection**
   - **Ubicación**: 
     - Configuración en Program.cs y ApplicationRegistration.cs 
   - **Descripción**: Se utiliza para inyectar dependencias como IClientsRepository  ISubClientsRepository y servicios como CreateClient  o GetSubClients.

### 3. **DTOs (Data Transfer Objects)**
   - **Ubicación**: 
     - DTOs
   - **Descripción**: Los DTOs como ClientDTO y SubClientDTO se utilizan para transferir datos entre las capas de la aplicación, evitando exponer directamente las entidades del dominio.

### 4. **CQRS (Command Query Responsibility Segregation)** *Implementado parcialmente*
   - **Ubicación**: 
     - Comandos: Commands
     - Consultas: Queries
   - **Descripción**: Este patrón separa las operaciones de escritura (comandos) de las de lectura (consultas), mejorando la escalabilidad y mantenibilidad.