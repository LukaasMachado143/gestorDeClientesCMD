using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace gestotCMD
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> Clientes = new List<Cliente>();

        enum Menu { Listar = 1, Adicionar, Remover, Sair};
        static void Main(string[] args)
        {
            int indexOpcao;
            bool fecharPrograma;

            carregarDados();
            Console.WriteLine("Gestor de clintes no CDM, Seja bem vindo !");

            fecharPrograma = false;

            while (!fecharPrograma)
            {
                Console.WriteLine("\nEscolha uma opção abaixo: ");
                Console.WriteLine("1 -> Listar Clientes");
                Console.WriteLine("2 -> Adicionar Clientes");
                Console.WriteLine("3 -> Remover Clientes");
                Console.WriteLine("4 -> Fechar o programa");
                indexOpcao = int.Parse(Console.ReadLine());

                Menu opcaoSelecionada = (Menu)indexOpcao;


                switch(opcaoSelecionada)
                {
                    case Menu.Listar:
                        Console.WriteLine("\nOpção * LISTAR * clientes selecionada !");
                        Listar();
                        Console.WriteLine("Aperte ENTER para sair");
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        deletarCliente();
                        break;
                    case Menu.Sair:
                        Console.WriteLine("Programa encerrado com sucesso, pressione ENTER para fechar o programa.");
                        fecharPrograma=true;
                        break;
                    default:
                        Console.WriteLine("A opção selecionada não existe !\nEscolha uma das opções listadas acima.");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void Adicionar()
        {
            Cliente novoCliente = new Cliente();

            Console.WriteLine("\nOpção * ADICIONAR * clientes selecionada !");
            
            Console.WriteLine("\n-> Informe o nome do cliente: ");
            novoCliente.nome = Console.ReadLine();

            Console.WriteLine("-> Informe o e-mail do cliente: ");
            novoCliente.email = Console.ReadLine();

            Console.WriteLine("-> Informe o cpf do cliente: ");
            novoCliente.cpf = Console.ReadLine();

            Clientes.Add(novoCliente);
            SalvarNoArquivo();

            Console.WriteLine($"Cliente {novoCliente.nome} cadastrado com sucesso");
        }

        static void Listar()
        {
            int i = 0;
            
            if (Clientes.Count > 0)
            {
                foreach (Cliente clienteAtual in Clientes)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"->ID: {i}");
                    Console.WriteLine($"->Nome: {clienteAtual.nome}");
                    Console.WriteLine($"->E-mail: {clienteAtual.email}");
                    Console.WriteLine($"->CPF: {clienteAtual.cpf}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não há clientes cadastrados !");
            }
            Console.WriteLine("---------------------------------------------------");
        }

        static void SalvarNoArquivo()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, Clientes);

            stream.Close();
        }

        static void carregarDados()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                if (Clientes != null)
                {
                    Clientes = (List<Cliente>)encoder.Deserialize(stream);
                    
                }else
                {
                    Clientes = new List<Cliente>();
                }
            }
            catch(Exception e)
            {
                Clientes = new List<Cliente>();
            }

            stream.Close();
        }

        static void deletarCliente()
        {
            int id;
            Console.WriteLine("\nOpção * DELETAR * clientes selecionada !");

            Listar();

            Console.WriteLine("-> Informe o ID do cliente: ");
            id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < Clientes.Count)
            {
                Clientes.RemoveAt(id);
                SalvarNoArquivo();
            }
            else
            {
                Console.WriteLine("O ID digitado é inválido");
            }
           
        }
    }
}
