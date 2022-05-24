using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Domain
{
    public class Cliente
    {
        public Cliente(string nome, string telefone, string cEP, string estado, string cidade)
        {
            Nome = nome;
            Telefone = telefone;
            CEP = cEP;
            Estado = estado;
            Cidade = cidade;
        }

        public Cliente(){}

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
