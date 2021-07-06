using System.Collections.Generic;
using System.IO;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{

    [Route("EdicaoPerfil")]
    public class EdicaoPerfilController : Controller
    {
        Usuario UsuarioEdit = new Usuario();

        [Route("Testando")]
        public IActionResult Index()
        {   
            List<Usuario> lista = UsuarioEdit.ListarUsuarios();
            int id = int.Parse(HttpContext.Session.GetString("_Id"));
            Usuario LogadoEdit = lista.Find(x => x.Id == id);
            ViewBag.UsuarioEditar = LogadoEdit; 
            return View();
        }

        [Route("EditandoTeste")]
        public IActionResult Editando(IFormCollection form){

            string caminho = "Database/Usuario.csv";
            int id = int.Parse(HttpContext.Session.GetString("_Id"));
            List<Usuario> userLines = UsuarioEdit.ListarUsuarios();
            List<string> linhas = UsuarioEdit.LerTodasLinhasCSV(caminho);

            Usuario usuarioEditado = userLines.Find(x => x.Id == id);
            string Nome = form["NomeEditado"];
            string User = form["NomeUsuarioEditado"];
            string Email = form["EmailEditado"];
            if (Nome != null)
            {
                usuarioEditado.Nome = Nome;
            }

            if (User != null)
            {
                usuarioEditado.NomeUsuario = User;
            }
            if (Email != null)
            {
                usuarioEditado.Email = Email;
            }
        
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuarios");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                usuarioEditado.ImagemPerfil = file.FileName;
            }
            else
            {
                usuarioEditado.ImagemPerfil = "padrao.png";
            }

            UsuarioEdit.EditarUsuario(usuarioEditado);

            return LocalRedirect("~/Perfil");
        }
    }
}