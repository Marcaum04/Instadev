using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Usuario UsuarioFeed = new Usuario();
        public IActionResult Index()
        {
            List<Usuario> lista = UsuarioFeed.ListarUsuarios();
            int id = int.Parse(HttpContext.Session.GetString("_Id"));
            Usuario Logado = lista.Find(x => x.Id == id);
            ViewBag.UsuarioLogado = Logado; 
            return View();
        }
    }
}