
# 🌸✨ Sistema de Gestión de Eventos Full Stack ✨🌸

¡Hola! 👋 Aquí tienes todo lo que necesitas para hacer funcionar este super cute proyecto de gestión de eventos con **Angular** + **.NET** + **SQL Server**. ¡Vamos paso a pasito! 👣

---

## 🌈 Paso 1: Prepara tu ambiente (¡Como decorar tu cuarto! 🎀)

### 1. Instalar Node.js (v18+)
Primero, necesitamos **Node.js** para ejecutar el frontend.

```bash
nvm install 18
```

### 2. Instalar Angular CLI (v19.2.6)
Con Angular CLI podremos crear y manejar nuestra aplicación frontend:

```bash
npm install -g @angular/cli@19.2.6
```

### 3. Instalar .NET SDK (v8)
La base para el backend:

```bash
winget install Microsoft.DotNet.SDK.8
```

---

## 🧸 Paso 2: Configuración Backend (¡La cocina secreta! 🍳)

### 🎀 Configuración de la conexión a la base de datos (appsettings.json)
Asegúrate de tener el archivo `appsettings.json` configurado correctamente en el proyecto del backend:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EventDetailDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 🛠 Ejecutar el backend
Ejecuta los siguientes comandos para restaurar las dependencias, crear la base de datos y ejecutar el backend:

```bash
dotnet restore   # Prepara las dependencias
dotnet ef database update  # Crea la base de datos
dotnet run       # Inicia el backend en http://localhost:5023
```

---

## 💖 Paso 3: Docker con amor (¡La mejor solución! 💌)

Si prefieres usar **Docker** para ejecutar el backend y SQL Server, te dejamos este archivo `docker-compose.yml`:

### 🎀 Configuración de Docker
```yaml
version: '3.8'

services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      SA_PASSWORD: "TuContraseñaSuperSegura123!"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"
    volumes:
      - sql_data:/var/opt/mssql  # ¡Persistencia de datos!

  webapi:
    build: .
    environment:
      - ConnectionStrings__DefaultConnection=Server=sqlserver;Database=EventDetailDB;User=sa;Password=TuContraseñaSuperSegura123;
    ports:
      - "8080:8080"
    depends_on:
      - sqlserver  # ¡Primero SQL, luego el backend!

volumes:
  sql_data:
```

### Solución de problemas Docker

- **Si Docker no conecta con SQL Server:**  
  Asegúrate de usar la misma versión de SQL Server en la imagen Docker y en local. Si el problema persiste, prueba con el siguiente comando:

  ```bash
  docker-compose down -v && docker-compose up
  ```

---

## 🎨 Paso 4: Frontend Angular (¡La fiesta bonita! 🎉)

### 🧸 Configuración de Angular
Edita el archivo `environment.ts` para que el frontend apunte a tu API:

```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'http://localhost:5023/api'
};
```

### 🎀 Ejecutar el frontend
Ahora, ve a la carpeta de frontend y ejecuta los siguientes comandos:

```bash
cd frontend
npm install   # Instala las dependencias
ng serve      # Inicia el frontend en http://localhost:4200
```

---

## 🍭 Problemas conocidos & Soluciones (¡Primeros auxilios! 🩹)

| Síntoma                              | Solución                                      | Emoji |
|--------------------------------------|-----------------------------------------------|-------|
| SQL Server no quiere jugar 😾        | Usa `TrustServerCertificate=True` en la cadena de conexión. | 🛡️ |
| Docker no da abrazos 🐳❌            | Prueba con `docker-compose down -v` y luego `docker-compose up`. | 🔄 |
| El backend está moody 🌧️            | Revisa los logs con `docker logs nombre_contenedor` para más detalles. | 🔍 |

---

## 💌 Notita especial de Docker
"Querido diario: Hoy el backend aún no está 100% amigable con Docker en producción, pero si usas nuestra imagen oficial de SQL Server 2022, ¡todo será más fácil! 🐇✨"

---

## 🎊 ¡Y listo! 🎉
Ahora tienes un sistema full stack funcionando como un sueño de algodón de azúcar 🍬. Si tienes alguna pregunta o necesitas ayuda, ¡aquí estoy! 💖

Con cariño,  
Tu asistente tech favorita ✨💻🌸

PS: No olvides cambiar las contraseñas por unas super secretas 🤫🔑
