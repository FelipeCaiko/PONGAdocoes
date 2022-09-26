using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Models
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Pessoa(string Nome, string CPF, char Sexo, DateTime DataNascimento, string Telefone)
        {
            this.Nome = Nome;
            this.CPF = CPF;
            this.Sexo = Sexo;
            this.DataNascimento = DataNascimento;
            this.Telefone = Telefone;
        }
    }
}
