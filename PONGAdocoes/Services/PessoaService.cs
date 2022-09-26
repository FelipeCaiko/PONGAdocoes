using PONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONGAdocoes.Services
{
    internal class PessoaService
    {
        public string Conexao = "Data Source=localhost;Initial Catalog=ONGAdocao;User Id=sa;Password=LiipeCaiko3030;";
        SqlConnection conn;

        public PessoaService()
        {
            conn = new SqlConnection(Conexao);
            conn.Open();
        }

        public void Add(Pessoa pessoa, string CEP)
        {
            int count = 0;

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Pessoa WHERE CPF = @CPF;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@CPF", pessoa.CPF));

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
                Console.WriteLine("CPF digitado já cadastrado!");
                Console.ReadKey();
                return;
            }

            SqlCommand sqlInsert = new SqlCommand();

            sqlInsert.CommandText = "INSERT INTO Pessoa (Nome, CPF, Sexo, DataNascimento, Telefone, Endereco) VALUES (@Nome, @CPF, @Sexo, @DataNascimento, @Telefone, @Endereco);";
            sqlInsert.Connection = conn;

            sqlInsert.Parameters.Add(new SqlParameter("@Nome", pessoa.Nome));
            sqlInsert.Parameters.Add(new SqlParameter("@CPF", pessoa.CPF));
            sqlInsert.Parameters.Add(new SqlParameter("@Sexo", pessoa.Sexo));
            sqlInsert.Parameters.Add(new SqlParameter("@DataNascimento", pessoa.DataNascimento));
            sqlInsert.Parameters.Add(new SqlParameter("@Telefone", pessoa.Telefone));
            sqlInsert.Parameters.Add(new SqlParameter("@Endereco", CEP));

            sqlInsert.ExecuteNonQuery();
        }

        public void FindAll()
        {
            SqlCommand sqlSelectAll = new SqlCommand();

            sqlSelectAll.CommandText = "SELECT Nome, CPF, Sexo, DataNascimento, Telefone, CEP, Bairro, Rua, Numero FROM Pessoa p, Endereco e WHERE p.Endereco = e.CEP;";
            sqlSelectAll.Connection = conn;

            using (SqlDataReader reader = sqlSelectAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Nome: {0}", reader.GetString(0));
                    Console.WriteLine("CPF: {0}", reader.GetString(1));
                    Console.WriteLine("Sexo: {0}", reader.GetString(2));
                    Console.WriteLine("Data de Nascimento: {0}", reader.GetDateTime(3));
                    Console.WriteLine("Telefone: {0}", reader.GetString(4));
                    Console.Write("CEP: {0}", reader.GetString(5));
                    Console.Write(" - Bairro: {0}", reader.GetString(6));
                    Console.Write(" - Rua: {0}", reader.GetString(7));
                    Console.Write(" - Numero: {0}", reader.GetInt32(8));
                    Console.WriteLine("\n");

                }
                reader.Close();
            }
            conn.Close();
            Console.WriteLine("Fim da impressão de pessoas cadastradas. Pressione ENTER para continuar!");
            Console.ReadKey();
        }

        public void Update()
        {
            int count = 0;
            Console.Write("Informe o CPF da Pessoa que deseja atualizar: ");
            string cpfPessoa = Console.ReadLine();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Pessoa WHERE CPF = @CPF;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@CPF", cpfPessoa));

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

            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Informe a opcao que deseja alterar: ");
                Console.WriteLine(" 1 - Nome");
                Console.WriteLine(" 2 - Sexo");
                Console.WriteLine(" 3 - Data de Nascimento");
                Console.WriteLine(" 4 - Telefone");
                Console.WriteLine(" 0 - Sair");
                Console.Write(" Informe a opcao: ");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 1:
                        Console.Write("Informe o novo nome: ");
                        string novoNome = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Pessoa SET Nome = @Nome WHERE CPF = @CPF";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Nome", novoNome));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Nome alterado com secesso!");
                        Console.ReadKey();
                        break;

                    case 2:
                        bool verifSexo = true;
                        char novosexo;
                        do
                        {
                            Console.Write("Informe o Sexo. M / F : ");
                            novosexo = char.Parse(Console.ReadLine().ToUpper());

                            if (novosexo != 'M' && novosexo != 'F')
                            {
                                Console.WriteLine("Voce inseriu um sexo inválido!");
                                verifSexo = false;
                            }
                            else
                                verifSexo = true;

                        } while (verifSexo == false);

                        sqlCommand.CommandText = "UPDATE Pessoa SET Sexo = @Sexo WHERE CPF = @CPF";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Sexo", novosexo));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Sexo alterado com secesso");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Informe a nova data de nascimento: ");
                        string novaDat = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Pessoa SET DataNascimento = @DataNascimento WHERE CPF = @CPF";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@DataNascimento", novaDat));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Data de nascimento alterada com secesso!");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Informe o novo telefone: ");
                        string novoTelefone = Console.ReadLine();

                        sqlCommand.CommandText = "UPDATE Pessoa SET Telefone = @Telefone WHERE CPF = @CPF";
                        sqlCommand.Connection = conn;

                        sqlCommand.Parameters.Add(new SqlParameter("@Telefone", novoTelefone));

                        sqlCommand.ExecuteNonQuery();

                        Console.WriteLine("Telefone alterado com secesso!");
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
            Console.Write("Informe o CPF da Pessoa que deseja remover: ");
            string RemoverCPF = Console.ReadLine();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Pessoa WHERE CPF = @CPF;";
            sqlCommand.Connection = conn;

            sqlCommand.Parameters.Add(new SqlParameter("@CPF", RemoverCPF));

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

            SqlCommand sqlSelectCEP = new SqlCommand();

            sqlSelectCEP.CommandText = "SELECT Endereco from Pessoa p WHERE p.CPF = @CPF;";
            sqlSelectCEP.Parameters.Add(new SqlParameter("@CPF", RemoverCPF));
            sqlSelectCEP.Connection = conn;

            using (SqlDataReader reader = sqlSelectCEP.ExecuteReader())
            {
                if (reader.Read())
                {
                    string cep = reader.GetString(0);

                    reader.Close();

                    //Remover Pessoa
                    SqlCommand sqlDelete = new SqlCommand();
                    sqlDelete.CommandText = "DELETE FROM Pessoa WHERE CPF = @CPF;";
                    sqlDelete.Connection = conn;
                    sqlDelete.Parameters.Add(new SqlParameter("@CPF", RemoverCPF));
                    sqlDelete.ExecuteNonQuery();

                    //Remover Endereco
                    sqlSelectCEP = new SqlCommand();
                    sqlSelectCEP.CommandText = "DELETE FROM Endereco WHERE CEP = @CEP;";
                    sqlSelectCEP.Connection = conn;
                    sqlSelectCEP.Parameters.Add(new SqlParameter("@CEP", cep));
                    sqlSelectCEP.ExecuteNonQuery();

                }
            }
            conn.Close();
            Console.WriteLine("Pessoa Removida com Sucesso!");
            Console.ReadKey();
        }
    }
}
