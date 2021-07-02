using System;
using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    public class PerfilController : Controller
    {

        Post publicacao = new Post();
        Usuario user = new Usuario();
        public IActionResult Index(int id)
        {
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