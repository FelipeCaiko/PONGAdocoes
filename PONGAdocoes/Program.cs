using PONGAdocoes.Models;
using PONGAdocoes.Services;
using System;
using System.Threading;

namespace PONGAdocoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1 - Menu Manter Pessoas");
                Console.WriteLine("2 - Menu Manter Animais");
                Console.WriteLine("3 - Menu de Adoções");
                Console.WriteLine("0 - Sair do Programa");

                Console.Write("Opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Você saiu do Menu Principal!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        opc = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Pessoas:");
                            Console.WriteLine("1 - Cadastrar Pessoa");
                            Console.WriteLine("2 - Atualizar Cadastro de Pessoa");
                            Console.WriteLine("3 - Mostrar Pessoas Cadastradas");
                            Console.WriteLine("4 - Remover Pessoa Cadastrada");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());

                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.Write("Informe o Nome: ");
                                    string nome = Console.ReadLine();
                                    Console.Write("Informe o CPF: ");
                                    string cpf = Console.ReadLine();

                                    bool verifSexo = true;
                                    char sexo;
                                    do
                                    {
                                        Console.Write("Informe o Sexo. M / F : ");
                                        sexo = char.Parse(Console.ReadLine().ToUpper());

                                        if (sexo != 'M' && sexo != 'F')
                                        {
                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                            verifSexo = false;
                                        }
                                        else
                                            verifSexo = true;

                                    } while (verifSexo == false);

                                    Console.Write("Informe a Data de Nascimento: ");
                                    DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                                    dataNascimento.ToShortDateString();
                                    Console.Write("Informe Telefone para Contato: ");
                                    string telefone = Console.ReadLine();

                                    Console.Write("Informe CEP: ");
                                    string CEP = Console.ReadLine();
                                    Console.Write("Informe Bairro: ");
                                    string bairro = Console.ReadLine();
                                    Console.Write("Informe Rua: ");
                                    string rua = Console.ReadLine();
                                    Console.Write("Informe Numero da Residência: ");
                                    int numero = int.Parse(Console.ReadLine());

                                    Endereco endereco = new Endereco(CEP, bairro, rua, numero);
                                    Pessoa pessoa = new Pessoa(nome, cpf, sexo, dataNascimento, telefone);

                                    EnderecoService enderecoService = new EnderecoService();
                                    enderecoService.Add(endereco);

                                    PessoaService pessoaService = new PessoaService();
                                    pessoaService.Add(pessoa, CEP);

                                    Console.WriteLine("Pessoa adicionada com Sucesso!");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    pessoaService = new PessoaService();
                                    pessoaService.Update();
                                    break;
                                case 3:
                                    Console.Clear();
                                    pessoaService = new PessoaService();
                                    pessoaService.FindAll();
                                    break;
                                case 4:
                                    pessoaService = new PessoaService();
                                    pessoaService.Delete();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção Inválida!");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        } while (opc != 0);
                        break;

                    case 2:
                        Console.Clear();
                        opc = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Animais:");
                            Console.WriteLine("1 - Cadastrar Animal");
                            Console.WriteLine("2 - Atualizar Cadastro de Animal");
                            Console.WriteLine("3 - Mostrar Animais Cadastrados");
                            Console.WriteLine("4 - Remover Animal Cadastrado");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());

                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.Write("Informe a Familia do Animal: ");
                                    string familia = Console.ReadLine();
                                    Console.Write("Informe a Raça do Animal: ");
                                    string raca = Console.ReadLine();

                                    bool verifSexo = true;
                                    char sexo;
                                    do
                                    {
                                        Console.Write("Informe o Sexo do Animal. M / F : ");
                                        sexo = char.Parse(Console.ReadLine().ToUpper());

                                        if (sexo != 'M' && sexo != 'F')
                                        {
                                            Console.WriteLine("Voce inseriu um sexo inválido!");
                                            verifSexo = false;
                                        }
                                        else
                                            verifSexo = true;

                                    } while (verifSexo == false);

                                    Console.Write("Informe o Nome do Animal: ");
                                    string nomeAnimal = Console.ReadLine();

                                    Animal animal = new Animal(familia, raca, sexo, nomeAnimal);

                                    AnimalService animalService = new AnimalService();
                                    animalService.Add(animal);

                                    Console.WriteLine("Animal adicionado com Sucesso!");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    animalService = new AnimalService();
                                    animalService.Update();
                                    break;
                                case 3:
                                    Console.Clear();
                                    animalService = new AnimalService();
                                    animalService.FindAll();
                                    break;
                                case 4:
                                    animalService = new AnimalService();
                                    animalService.Delete();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção Inválida!");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        } while (opc != 0);
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu Adoções");
                            Console.WriteLine("1 - Cadastrar Adoção");
                            Console.WriteLine("2 - Mostrar Adoções de Animais");
                            Console.WriteLine("0 - Voltar Menu Principal");
                            Console.Write("Opção: ");
                            opc = int.Parse(Console.ReadLine());
                            switch (opc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    AdocoesService adocoesService = new AdocoesService();
                                    adocoesService.Add();
                                    break;
                                case 2:
                                    Console.Clear();
                                    adocoesService = new AdocoesService();
                                    adocoesService.FindAll();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção Inválida!");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        } while (opc != 0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(2000);
                        break;
                }
            } while (true);
        }
    }
}
