using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Models
{
    internal class Endereco
    {
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public Endereco(string CEP, string Bairro, string Rua, int Numero)
        {
            this.CEP = CEP;
            this.Bairro = Bairro;
            this.Rua = Rua;
            this.Numero = Numero;
        }
    }
}
