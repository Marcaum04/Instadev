using System;
using System.Collections.Generic;
using System.IO;
using Instadev.Interfaces;

namespace Instadev.Models
{
    public class Post : InstadevBase, IPost
    {
        private int IdAutor { get; set; }
        private int IdPost { get; set; }
        private string Texto { get; set; }
        private int Curtidas { get; set; }
        private string imagem { get; set; }
        private const string CAMINHO = "Database/Post.csv";
        
        public Post()
        {
            CriarPastaEArquivo(CAMINHO);
        }
        public void CadastrarPost(Post p)
        {
            string[] linha = {PrepararLinha(p)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void DeletarPost(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[1] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }

        public void EditarPost(Post p)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[1] == p.IdPost.ToString());
            linhas.Add( PrepararLinha(p) );
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Post> ListarPosts()
        {
            List<Post> posts = new List<Post>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach(var item in linhas){

                string[] linha = item.Split(";");
                Post NovoPost = new Post();

                NovoPost.IdAutor = Int32.Parse(linha[0]);
                NovoPost.IdPost = Int32.Parse(linha[1]);
                NovoPost.imagem = linha[2];
                NovoPost.Curtidas = Int32.Parse(linha[3]);
                NovoPost.Texto = linha[4];

                posts.Add(NovoPost);
            }

            return posts;
        }

        private string PrepararLinha(Post p){
            return $"{p.IdAutor};{p.IdPost};{p.imagem};{p.Curtidas};{p.Texto}";
        }
    }
}