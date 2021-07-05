using System;
using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {

        Post publicacao = new Post();
        Usuario user = new Usuario();

        public IActionResult Index()
        {
            int id = int.Parse(HttpContext.Session.GetString("_Id"));
            List<Post> publi = publicacao.ListarPosts();
            List<Post> postagens = publi.FindAll(x => x.IdAutor == id);

            List<Usuario> users = user.ListarUsuarios();
            Usuario usuarioLogado = users.Find(y => y.Id == id);

            ViewBag.Posts = postagens;
            ViewBag.Perfil = usuarioLogado;
            
            return View();
        }
    }
}