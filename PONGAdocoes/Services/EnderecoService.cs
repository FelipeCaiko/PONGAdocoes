using PONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Services
{
    internal class EnderecoService
    {
        public string Conexao = "Data Source=localhost;Initial Catalog=ONGAdocao;User Id=sa;Password=LiipeCaiko3030;";
        SqlConnection conn;

        public EnderecoService()
        {
            conn = new SqlConnection(Conexao);
            conn.Open();
        }

        public void Add(Endereco endereco)
        {
            SqlCommand sqlInsert = new SqlCommand();

            sqlInsert.CommandText = "INSERT INTO Endereco (CEP, Bairro, Rua, Numero) VALUES (@CEP, @Bairro, @Rua, @Numero);";
            sqlInsert.Connection = conn;

            sqlInsert.Parameters.Add(new SqlParameter("@CEP", endereco.CEP));
            sqlInsert.Parameters.Add(new SqlParameter("@Bairro", endereco.Bairro));
            sqlInsert.Parameters.Add(new SqlParameter("@Rua", endereco.Rua));
            sqlInsert.Parameters.Add(new SqlParameter("@Numero", endereco.Numero));

            sqlInsert.ExecuteNonQuery();
        }

    }
}
