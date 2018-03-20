using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace multas_tB.Models
{
    public class Multas
    {

        public int ID { get; set; } //Primary Key

        public string Infracao { get; set; }

        public string LocalMulta { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataMulta { get; set; }

        //**********************************************************************************
        //representar as chaves forasteiras que relacionam esta classe com as outras classes
        //**********************************************************************************

        //FK para a tabela dos condutores
        //...Constraint NomeDoTermo
        //Foreign Key NomeDoAtributo references NomeDaTabela(NomeDoAtributoPK)
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }

        //FK para as viaturas
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

        //FK para os agentes
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public virtual Agentes Agente { get; set; }


    }
}