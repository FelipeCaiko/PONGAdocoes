using PONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Services
{
    internal class AnimalService
    {
        public string Conexao = "Data Source=localhost;Initial Catalog=ONGAdocao;User Id=sa;Password=LiipeCaiko3030;";
        SqlConnection conn;

        public AnimalService()
        {
            conn = new SqlConnection(Conexao);
            conn.Open();
        }
        public void Add(Animal animal)
        {
            int count = 0;

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Animal WHERE Chip = @Chip;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@Chip", animal.Chip));

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
            if (count != 0)
            {
                Console.WriteLine("Número do CHIP de Animal já cadastrado!");
                Console.ReadKey();
                return;
            }

            SqlCommand sqlInsert = new SqlCommand();

            sqlInsert.CommandText = "INSERT INTO Animal (Familia, Raca, Sexo, Nome, Situacao) VALUES (@Familia, @Raca, @Sexo, @Nome, @Situacao);";
            sqlInsert.Connection = conn;

            sqlInsert.Parameters.Add(new SqlParameter("@Familia", animal.Familia));
            sqlInsert.Parameters.Add(new SqlParameter("@Raca", animal.Raca));
            sqlInsert.Parameters.Add(new SqlParameter("@Sexo", animal.Sexo));
            sqlInsert.Parameters.Add(new SqlParameter("@Nome", animal.Nome));
            sqlInsert.Parameters.Add(new SqlParameter("@Situacao", animal.Situacao));

            sqlInsert.ExecuteNonQuery();
        }
        public void FindAll()
        {
            SqlCommand sqlSelectAll = new SqlCommand();

            sqlSelectAll.CommandText = "SELECT Chip, Familia, Raca, Sexo, Nome, Situacao FROM Animal;";
            sqlSelectAll.Connection = conn;

            using (SqlDataReader reader = sqlSelectAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Chip: {0}", reader.GetInt32(0));
                    Console.WriteLine("Familia: {0}", reader.GetString(1));
                    Console.WriteLine("Raça: {0}", reader.GetString(2));
                    Console.WriteLine("Sexo: {0}", reader.GetString(3));
                    Console.WriteLine("Nome: {0}", reader.GetString(4));
                    Console.WriteLine("Situacao: {0}", reader.GetString(5));
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nFim da impressão de animais cadastrados. Pressione ENTER para continuar!");
            Console.ReadKey();
        }
        public void Update()
        {
            int count = 0;
            Console.Write("Informe o Número do CHIP do animal que irá ser atualizado: ");
            int chipAnimal = int.Parse(Console.ReadLine());

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Animal WHERE Chip = @Chip;";
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
                Console.WriteLine("Número do CHIP de Animal não cadastrado!");
                Console.ReadKey();
                return;
            }

            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Informe a opcao que deseja alterar: ");
                Console.WriteLine(" 1 - Familia");
                Console.WriteLine(" 2 - Raça");
                Console.WriteLine(" 3 - Sexo");
                Console.WriteLine(" 4 - Nome do animal");
                Console.WriteLine(" 0 - Sair");
                Console.Write(" Informe a opcao: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Write("Informe a nova familia: ");
                        string novaFamilia = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Animal SET Familia = @Familia WHERE Chip = @Chip";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Familia", novaFamilia));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Familia alterada com secesso!");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Informe a nova raça: ");
                        string novaRaca = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Animal SET Raca = @Raca WHERE Chip = @Chip";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Raca", novaRaca));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Raca alterado com secesso!");
                        Console.ReadKey();
                        break;

                    case 3:
                        bool verifSexo = true;
                        char novosexo;
                        do
                        {
                            Console.Write("Informe o Sexo do Animal. M / F : ");
                            novosexo = char.Parse(Console.ReadLine().ToUpper());

                            if (novosexo != 'M' && novosexo != 'F')
                            {
                                Console.WriteLine("Voce inseriu um sexo inválido!");
                                verifSexo = false;
                            }
                            else
                                verifSexo = true;

                        } while (verifSexo == false);

                        sqlCommand.CommandText = "UPDATE Animal SET Sexo = @Sexo WHERE Chip = @Chip";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Sexo", novosexo));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Sexo alterado com secesso!");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Informe o novo nome: ");
                        string novoNome = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Animal SET Nome = @Nome WHERE Chip = @Chip";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Nome", novoNome));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Nome alterado com secesso!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Write("\n Opcao Inválida! Aperte ENTER para executar novamente.");
                        Console.ReadKey();
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
        }
        public void Delete()
        {
            int count = 0;
            Console.Write("Informe o Número do CHIP do animal que irá ser atualizado: ");
            int RemoverCHIP = int.Parse(Console.ReadLine());

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Animal WHERE Chip = @Chip;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@Chip", RemoverCHIP));

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
                Console.WriteLine("Número do CHIP de Animal não cadastrado!");
                Console.ReadKey();
                return;
            }

            //Remover Pessoa
            SqlCommand sqlDelete = new SqlCommand();
            sqlDelete.CommandText = "DELETE FROM Animal WHERE Chip = @Chip;";
            sqlDelete.Connection = conn;
            sqlDelete.Parameters.Add(new SqlParameter("@Chip", RemoverCHIP));
            sqlDelete.ExecuteNonQuery();

            Console.WriteLine("Animal Removido com Sucesso!");
            Console.ReadKey();
        }
    }
}
