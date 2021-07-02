using System;
using System.IO;
using Instadev.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    [Route("Cadastro")]
    public class CadastroController : Controller
    {
        Usuario UsuarioModel = new Usuario();
        public IActionResult Index()
        {
            ViewBag.Usuarios = UsuarioModel.ListarUsuarios();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar()
        {
            Usuario NovoUsuario = new Usuario();
            NovoUsuario.Nome = form[];
            NovoUsuario.Email = form[];
            NovoUsuario.SetarSenha(form[]);
            NovoUsuario.NomeUsuario(form[]);
            NovoUsuario.Id = Int32.Parse(form[]);

              if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuarios");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                NovoUsuario.ImagemPerfil = file.FileName;                
            }
            else
            {
                NovoUsuario.ImagemPerfil = "padrao.png";
            }

            UsuarioModel.CadastrarUsuario(NovoUsuario);            
            ViewBag.Usuarios = UsuarioModel.ListarUsuarios();

             return LocalRedirect("~/Cadastro");
        }
    }
}