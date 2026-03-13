using System;
using System.Net;
using System.Net.Mail;
using Portafolio.Models;

namespace Portafolio.Controllers.Servicios;

public interface IServiciosEmail
{
    Task Enviar(ContactoViewModel contacto);
}

public class ServiciosEmailGmail : IServiciosEmail
{
    private readonly IConfiguration configuration;

    public ServiciosEmailGmail(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task Enviar(ContactoViewModel contacto)
    {
        var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
        var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
        var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
        var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");
        var smtpCliente = new SmtpClient(host, puerto);
        smtpCliente.EnableSsl = true;
        smtpCliente.UseDefaultCredentials = false;
        smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
        var mensaje = new MailMessage(emailEmisor, emailEmisor,
        $"El cliente{contacto.Nombre}({contacto.Email}) quiere contactarte", contacto.Mensaje);

        await smtpCliente.SendMailAsync(mensaje);

    }


}
