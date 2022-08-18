using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
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

            Console.WriteLine($"Cliente {novoCliente.nome} cadastrado com sucesso");
        }
    }
}
