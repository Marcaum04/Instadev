using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Usuario LoginUsuario = new Usuario();
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> lista = LoginUsuario.LerTodasLinhasCSV("Database/Usuario.csv");
            string logado = lista.Find(x => x.Split(";")[1] == form["Email"] && x.Split(";")[2] == form["Senha"]);

            if (logado != null)
            {
                HttpContext.Session.SetString("_Id", logado.Split(";")[4]);
                return LocalRedirect("~/Feed");
            }
            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_Username");
            return LocalRedirect("~/");
        }
    }
}