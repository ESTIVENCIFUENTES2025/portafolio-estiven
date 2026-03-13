using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Controllers.Servicios;
using Portafolio.Models;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly IRepositorioProyectos repositorioProyectos;
    private readonly IServiciosEmail serviciosEmail;

    public HomeController(IRepositorioProyectos repositorioProyectos,IServiciosEmail serviciosEmail)
    {
        this.repositorioProyectos = repositorioProyectos;
        this.serviciosEmail = serviciosEmail;
    }

    public IActionResult Index()
    {

       
        var proyectos = repositorioProyectos.ObtenerProyectos().Take(5).ToList();
        var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
        return View(modelo);
    }

    public IActionResult Proyectos()
    {
        var proyectos = repositorioProyectos.ObtenerProyectos();
        return View(proyectos);
    }
    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }
    [HttpPost]
     public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
    {
        await serviciosEmail.Enviar(contactoViewModel);
        return RedirectToAction("Gracias");
    }
    public IActionResult Gracias()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
