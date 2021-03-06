﻿using System;
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

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!!")]
        [RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüçãõ]+(( |'|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüçãõ]+){1,3}", ErrorMessage ="O {0} apenas pode conter letras e espaços em branco. Cada palavra começa em Maiúscula, seguida de minúsculas.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!!")]
        [RegularExpression("[A-ZÍÉÂÁ]*[a-záéíóúàèìòùâêîôûäëïöüçãõ -]*", ErrorMessage = "A {0} apenas pode conter letras e espaços em branco. Cada palavra começa em Maiúscula, seguida de minúsculas.")]
        public string Esquadra { get; set; }

        public string Fotografia { get; set; }


        //referência às multas q um agente 'emite'
        public virtual ICollection<Multas> ListaDeMultas { get; set; }

    }
}