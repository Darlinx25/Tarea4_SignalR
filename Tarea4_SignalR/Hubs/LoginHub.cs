using Tarea4_SignalR.Model;
using Microsoft.AspNetCore.SignalR;
namespace Tarea4_SignalR.Hubs;
public class LoginHub : Hub
{
    private readonly ILogger<LoginHub> _logger;

    public LoginHub(ILogger<LoginHub> logger)
    {
        _logger = logger;
    }
    public void Login(string email, string pass)
    {   
        _logger.LogInformation("SignalR identificacion del usuario: " + Context.ConnectionId);
        Usuario usuario = new Usuario(email, pass);         
        if (!usuario.EsUsuarioValido()) return;
        if (usuario.NecesitarVerificacion())
        {
            string usrId = Context.ConnectionId;
            var http = Context.GetHttpContext();
            string url = $"{http?.Request.Scheme}://{http?.Request.Host}/verificar/usuario/{usrId}";
            _logger.LogInformation($"Simulá hacer click en: {url}");
            
        }
    }
}