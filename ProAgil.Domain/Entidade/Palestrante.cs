using System.Collections.Generic;
using ProAgil.Domain.Entidade;

namespace ProAgil.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curriculo {get; set;}
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email {get; set;}
        public List<RedeSocial> Sociais { get; set; }
        public List<PalestranteEvento> PalestranteEventos { get; set; }
    }
}