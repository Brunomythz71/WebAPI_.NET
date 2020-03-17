using System;
using System.Collections.Generic;
using ProAgil.Domain.Entidade;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int EventoID { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QntPessoas {get;set;}
        public string Email { get; set; }
        public List<Lote> Lotes { get; set; }
        public string ImagemURL {get;set;}
        public List<RedeSocial> Sociais {get; set;}
        public List<PalestranteEvento> PalestranteEventos { get; set; }
    }
}