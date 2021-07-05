using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{

    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Usuario LoginUsuario = new Usuario();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(IFormCollection form)
        {
            List<string> lista = LoginUsuario.LerTodasLinhasCSV("Database/Usuario");
            string logado = lista.Find(x => x.Split(";")[1] == form["Email"] && x.Split(";")[2] == form["Senha"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("_Id", logado.Split(";")[6]);
                return LocalRedirect("~/Feed");
            }
            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_Username");
            return LocalRedirect("~/Login");
        }
    }
}