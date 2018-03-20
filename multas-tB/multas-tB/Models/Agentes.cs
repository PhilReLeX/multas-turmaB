using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multas_tB.Models
{
    public class Agentes
    {
        public Agentes()
        {
            ListaDeMultas = new HashSet<Multas>();
        }

        [Key]
        public int ID { get; set; } //chave primária

        public string Nome { get; set; }

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }


        //referência às multas q um agente 'emite'
        public virtual ICollection<Multas> ListaDeMultas { get; set; }

    }
}