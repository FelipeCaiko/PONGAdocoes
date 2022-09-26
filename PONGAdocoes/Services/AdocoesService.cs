using PONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Services
{
    internal class AdocoesService
    {
        public string Conexao = "Data Source=localhost;Initial Catalog=ONGAdocao;User Id=sa;Password=LiipeCaiko3030;";
        SqlConnection conn;

        public AdocoesService()
        {
            conn = new SqlConnection(Conexao);
            conn.Open();
        }

        public void Add()
        {
            int count = 0;
            Console.Write("Informe o CPF da pessoa que irá adotar: ");
            string cpfAdotante = Console.ReadLine();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Pessoa WHERE CPF = @CPF;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@CPF", cpfAdotante));

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("CPF digitado não cadastrado!");
                Console.ReadKey();
                return;
            }

            count = 0;

            Console.Write("Informe o Número do CHIP do animal que irá ser adotado: ");
            int chipAnimal = int.Parse(Console.ReadLine());

            sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Animal WHERE Chip = @Chip AND Situacao ='D';";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@Chip", chipAnimal));

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Número do CHIP de Animal não cadastrado ou já adotado!");
                Console.ReadKey();
                return;
            }

            sqlCommand = conn.CreateCommand();

            sqlCommand.CommandText = "INSERT INTO Adocoes(CPF, Chip, DataAdocao) VALUES (@CPF, @Chip, @DataAdocao);";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@CPF", cpfAdotante));
            sqlCommand.Parameters.Add(new SqlParameter("@Chip", chipAnimal));
            sqlCommand.Parameters.Add(new SqlParameter("@DataAdocao", DateTime.Now.ToShortDateString()));

            sqlCommand.ExecuteNonQuery();

            sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "UPDATE Animal SET Situacao = 'A' WHERE Chip = @Chip";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@Chip", chipAnimal));

            sqlCommand.ExecuteNonQuery();


            Console.WriteLine("Adoção concluida!\n");
            Console.ReadKey();

        }

        public void FindAll()
        {
            SqlCommand sqlSelectAll = new SqlCommand();

            sqlSelectAll.CommandText = "SELECT Id, CPF, Chip FROM Adocoes;";
            sqlSelectAll.Connection = conn;

            using (SqlDataReader reader = sqlSelectAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: {0}", reader.GetInt32(0));
                    Console.WriteLine("CPF: {0}", reader.GetString(1));
                    Console.WriteLine("Chip: {0}", reader.GetInt32(2));
                    Console.WriteLine();
                }
                Console.WriteLine("Fim da impressão de Adoções cadastradas. Pressione ENTER para continuar!");
                Console.ReadKey();
            }

        }
    }
}
