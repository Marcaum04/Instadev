using System.Collections.Generic;
using Instadev.Models;

namespace Instadev.Interfaces
{
    public interface IPost
    {
         void CadastrarPost(Post p);
         List<Post> ListarPosts();
         void DeletarPost(int id);
         void EditarPost(Post p);
    }
}