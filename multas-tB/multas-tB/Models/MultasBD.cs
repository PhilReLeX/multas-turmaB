using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace multas_tB.Models
{
        public class MultasBD : DbContext
        {
        //construtor q indica qual a base de dados a utilizar
        public MultasBD() : base("Name=MultasBDConectionString") { }


        //descrever os nomes das tabelas na Base de Dados
        public virtual DbSet<Multas> Multas { get; set; }
        public virtual DbSet<Agentes> Agentes { get; set; }
        public virtual DbSet<Condutores> Condutores { get; set; }
        public virtual DbSet<Viaturas> Viaturas { get; set; }


    }
}