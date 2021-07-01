using System.Collections.Generic;
using Instadev.Models;

namespace Instadev.Interfaces
{
    public interface IUsuario
    {
         void CadastrarUsuario(Usuario u);
         void DeletarUsuario (int i);
         void EditarUsuario(Usuario u);
         List<Usuario> ListarUsuarios();
    }
}