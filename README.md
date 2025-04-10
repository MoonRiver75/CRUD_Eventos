🌸✨ Sistema de Gestión de Eventos Full Stack ✨🌸
¡Hola! 👋 Aquí tienes todo lo que necesitas para hacer funcionar este proyecto super cute 💖 de gestión de eventos con Angular + .NET + SQL Server. ¡Vamos paso a pasito! 👣

🌈 Paso 1: Prepara tu ambiente (¡Como decorar tu cuarto! 🎀)
bash
Copy
# 1. Instala Node.js (v18+) - ¡El glitter de tu app!
nvm install 18

# 2. Angular CLI (v19.2.6) - Nuestro pincel mágico ✨
npm install -g @angular/cli@19.2.6

# 3. .NET 8 SDK - La base fuerte 💪
winget install Microsoft.DotNet.SDK.8
🧸 Paso 2: Configuración Backend (¡La cocina secreta! 🍳)
🎀 appsettings.json (Tu receta favorita 📜)
json
Copy
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EventDetailDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
🛠 Ejecuta el backend (¡Precalienta el horno! 🔥)
bash
Copy
dotnet restore   # Prepara los ingredientes
dotnet ef database update  # ¡Hornea la base de datos!
dotnet run       # ¡Sirve en http://localhost:5023!
💖 Nota importante: Nuestro backend es un poco tímido con Docker 🐳. A veces tiene problemas para conectar con SQL Server en contenedores. ¡Pero tenemos solución! 👇

🐻 Paso 3: Docker con amor (¡La mejor solución! 💌)
🎀 docker-compose.yml (¡Nuestra cajita mágica!)
yaml
Copy
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
      - sql_data:/var/opt/mssql  # ¡Para que no se pierdan tus datos!

  webapi:
    build: .
    environment:
      - ConnectionStrings__DefaultConnection=Server=sqlserver;Database=EventDetailDB;User=sa;Password=TuContraseñaSuperSegura123;
    ports:
      - "8080:8080"
    depends_on:
      - sqlserver  # ¡Primero el SQL, después el amor!

volumes:
  sql_data:  # ¡Nuestro diario secreto!
✨ Tip super importante: Usa siempre la misma versión de SQL Server en tu imagen Docker y en local. ¡Así evitamos dramas! 💃

🎨 Paso 4: Frontend Angular (¡La fiesta bonita! 🎉)
🧸 environment.ts (¡Tu invitación digital!)
typescript
Copy
export const environment = {
  production: false,
  apiBaseUrl: 'http://localhost:5023/api'  // ¡Donde vive el backend!
};
🎀 Ejecuta el frontend (¡Que empiece la fiesta!)
bash
Copy
cd frontend
npm install   # ¡Abre los regalos!
ng serve      # ¡Fiesta en http://localhost:4200!
🍭 Problemas conocidos & Soluciones (¡Primeros auxilios! 🩹)
Síntoma	Solución	Emoji
SQL Server no quiere jugar 😾	Usa TrustServerCertificate=True en tu cadena de conexión	🛡️
Docker no da abrazos 🐳❌	Prueba con docker-compose down -v y vuelve a intentar	🔄
El backend está moody 🌧️	Verifica los logs con docker logs nombre_contenedor	🔍
💌 Notita especial de Docker
"Querido diario: Hoy el backend aún no está 100% amigable con Docker en producción. Pero si usas nuestra imagen oficial de SQL Server 2022, ¡todo será más fácil! 🐇✨"

🎊 ¡Y listo!
Ahora tienes un sistema full stack funcionando como un sueño de algodón de azúcar 🍬. ¿Necesitas algo más? ¡Aquí estoy! 💖

Con cariño,
Tu asistente tech favorita ✨💻🌸

PS: No olvides cambiar las contraseñas por unas super secretas 🤫🔑
