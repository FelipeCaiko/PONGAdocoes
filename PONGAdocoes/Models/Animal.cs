using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Models
{
    internal class Animal
    {
        public int Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public char Situacao { get; set; }

        public Animal(string Familia, string Raca, char Sexo, string Nome)
        {
            this.Familia = Familia;
            this.Raca = Raca;
            this.Sexo = Sexo;
            this.Nome = Nome;
            this.Situacao = 'D';
        }


    }
}
