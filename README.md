
# 🌸✨ Sistema de Gestión de Eventos Full Stack ✨🌸

![image](https://github.com/user-attachments/assets/a5e762c2-2b5c-43b0-b09e-ded20ae11058)


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
    "DevConnection": "Server=RONNY;Database=EventDetailDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
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

![image](https://github.com/user-attachments/assets/836be3b8-50e6-4d60-a9a1-1bcf8b587259)


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

-------

 **SweetAlert2 (para alertas interactivas y hermosas)**  
   ✨ Dale vida a las alertas de tu app con **SweetAlert2**. Si aún no lo has instalado, corre el siguiente comando:

   ```bash
   npm install sweetalert2
```
![image](https://github.com/user-attachments/assets/21eb13d3-df46-4610-a8af-f52157426ed1)


-------

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




# 🌸✨ Información Adicional ✨🌸

¡Hola, hola! 💖 Aquí te dejo algunos detallitos súper importantes sobre el proyecto, ¡espero que te encanten! 😍

---

## 💖 Formulario Inteligente 💖

El formulario fue creado con amor ❤️, basándome en varios libros y fuentes súper confiables sobre cómo hacer formularios de manera **inteligente** y **efectiva**. Una de las cosas que aprendí fue sobre la **validación de formularios**. Aunque nunca se habló de añadir validaciones, pensé que sería una idea muy **inteligente** hacerle saber al usuario si algo no está bien, ¿verdad? 💅🏼✨

Entonces, empecé a añadir algunas validaciones para marcar los campos que podrían estar incorrectos, ¡para que el usuario no se preocupe por esos detalles! 😌 Es como si el formulario fuera una súper amiga diciéndote qué corregir. Se hicieron algunas pruebas, pero siempre hay espacio para **mejorar** y **añadir más validaciones** según se necesite. 💪

---

## 🐳 Docker con Amor 💕

La idea inicial era dockerizar todo el proyecto desde el principio, ¡pero decidí dejarlo para probar las dos partes primero! 🌸

La primera parte, el **frontend**, ¡sí está manejado por Docker! 🐳 Puedes desplegarlo usando Docker, pero también puedes hacerlo como te lo indican las instrucciones, ¡añadiendo la base de datos de la manera tradicional! Es como tener lo mejor de los dos mundos 😘✨

---

## 📦 El Patrocinador del Orden: El Repository Pattern 🎀

Lo más emocionante de este proyecto fue usar el **Repository Pattern** (¡sí, lo usé por primera vez! 😱). Lo había escuchado antes, pero nunca lo había **aplicado**. Esta vez, lo puse en práctica de la mejor manera posible y, ¡me encanta cómo resultó! 💖 Algunas de las **ventajas** que me sorprendieron fueron que es mucho **más fácil de mantener** y, obvio, ¡**es mucho más fácil de escalar**! 🚀

---

## 🌟 ¡Muy emocionado! 🌟

Estoy **tan emocionado** con este proyecto y muy **agradecido** con todos los que me han apoyado. ¡Espero recibir un feedback pronto y oír cosas súper positivas de parte de ustedes! 😄✨ Estoy segurísimo de que se nota el **cariño y el esfuerzo** que puse en todo este sistema 💕.
  
**Roldan Madero** 💖✨
Con cariño,  
Tu asistente tech favorito ✨💻🌸

PS: No olvides cambiar las contraseñas por unas super secretas 🤫🔑
