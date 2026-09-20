# Tarea 4 - SignalR: Login con verificación de email

## Descripción
App ASP.NET Core (Razor Pages) que implementa un login con verificación de
usuario por email. Usa SignalR para que el servidor notifique a la pestaña de
login cuando el correo fue verificado y la redirija automáticamente a la página
de bienvenida, sin que el usuario recargue ni vuelva a ingresar sus credenciales.

## Cómo correr
```
dotnet run
```


## Abrir https://localhost:7097


## Cómo usar
1. En la página de login, ingresar cualquier email y contraseña.
2. En la consola del servidor ingresar a la URL que imprime (/verificar/usuario/{connectionId}).
3. La pestaña del login se redirige sola a /PaginaBienvenida.
## Cómo funciona
- El cliente se conecta al Hub (/loginHub) y recibe un ConnectionId.
- Al enviar Login(email, pass), el servidor simula el envío del mail
logueando la URL de verificación.
- El endpoint /verificar/usuario/{connectionId} usa IHubContext para
enviar VerificacionOk solo a ese cliente (Clients.Client).
- La página de login escucha ese evento (connection.on) y redirige sola.
## Estructura
- Hubs/LoginHub.cs – Hub con el método Login
- Model/Usuario.cs – modelo (validación simulada)
- Pages/LoginConVerificacion.cshtml – login + cliente SignalR
- Pages/PaginaBienvenida.cshtml – destino del redirect

## Diagrama de Secuencia
<img width="1420" height="757" alt="image" src="https://github.com/user-attachments/assets/7013a3d7-1aae-4016-927b-72d1d186ed41" />

