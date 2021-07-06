using System;
using System.Collections.Generic;
using System.IO;
using Instadev.Interfaces;

namespace Instadev.Models
{
    public class Post : InstadevBase, IPost
    {
        public string NomeAutor{ get; set; }
        public string ImagemAutor{ get; set; }
        public int IdAutor { get; set; }
        public int IdPost { get; set; }
        public string Texto { get; set; }
        public int Curtidas { get; set; }
        public string imagem { get; set; }
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

                NovoPost.NomeAutor = linha[0];
                NovoPost.ImagemAutor = linha[1];
                NovoPost.IdPost = Int32.Parse(linha[2]);
                NovoPost.imagem = linha[3];
                NovoPost.Curtidas = Int32.Parse(linha[4]);
                NovoPost.Texto = linha[5];
                NovoPost.IdAutor = Int32.Parse(linha[6]);

                posts.Add(NovoPost);
            }

            return posts;
        }

        public string PrepararLinha(Post p){
            return $"{p.NomeAutor};{p.ImagemAutor};{p.IdPost};{p.imagem};{p.Curtidas};{p.Texto};{p.IdAutor}";
        }
    }
}