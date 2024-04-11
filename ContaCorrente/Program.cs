using System.Security.Cryptography.X509Certificates;

namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao, cadastro = 0;
            while(true)
            {
                Cliente Cliente1 = new Cliente();
                Console.Write("\nDigite seu nome: ");
                Cliente1.nome = Console.ReadLine();
                Console.Write("\nDigite seu sobrenome: ");
                Cliente1.sobrenome = Console.ReadLine();
                Cliente1.cpf = Engine.LerInt("\nDigite seu CPF: ");
                Cliente1.senha = Engine.LerInt("\nDigite sua senha: ");
                opcao = Engine.LerInt("\nVocê é pessoa fisica ou juridica?\n\n1. Pessoa Física\n2. Pessoa Juridica\n\nSua opção: ");
                Cliente1.fisicaOUjuridica = Cliente.PJouPF(opcao);
                cadastro++;

                Conta Conta1 = new Conta();
                Conta1.numerodaconta = cadastro;
                Conta1.titular = Cliente1;

                if (Conta1.saldo == 0)
                {
                    decimal deposito;
                    Console.Write("\nSua conta está zerada, será necessário fazer um depóstio para continuar.");
                    deposito = Conta.Deposito(Conta1.saldo);
                    Conta1.saldo += deposito;
                }
                if 

            }
        }
    }
    public class Engine
    {
        public static int Checagem(int opcao)
        {
            while (true)
            {
                if (opcao != 1 && opcao != 2)
                {
                    Console.Write("\nPor favor escolha uma opção valida do menu.\n\nPrecione qualquer tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                break;
            }
            return opcao;
        }
        public static int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }

                Console.Write("\nPor favor digite um numero.\n\nPrecione qualquer tecla para continuar.");
                Console.ReadKey();
                Interface.Cabecalho();
            }
        }
        public static decimal LerDecimal(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = decimal.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("\n\n######################################################################################");
                Console.WriteLine("###                                                                                ###");
                Console.WriteLine("###                                     ATENÇÃO                                    ###");
                Console.WriteLine("###                                                                                ###");
                Console.WriteLine("###              Comando inválido. Por favor digite um numero válido.              ###");
                Console.WriteLine("###                                                                                ###");
                Console.WriteLine("###                     Precione qualquer tecla para continuar.                    ###");
                Console.WriteLine("###                                                                                ###");
                Console.WriteLine("######################################################################################");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.ReadKey();
                Interface.Cabecalho();
            }
        }
        static string Historico(int numerodaconta, decimal saldo, decimal limite, string status)
        {
            string historico;
            historico = "texto do historico";
            return historico;
        }

    }
    public class Interface
    {
        public static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                          Academia do programador 2024                          ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                              Jogo da adivinhação                               ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################\n\n");
        }        
    }
    public class Conta
    {
        public int numerodaconta;
        public decimal saldo = 0, limite;
        public bool statusespecial, usuarionovo; 
        public Cliente titular;

        public static bool ContaEespecial(decimal saldo)
        {
            if (saldo > 100000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static decimal Deposito(decimal saldo)
        {
            decimal deposito = Engine.LerDecimal("\nPor favor, digite o valor para deposito: ");
            Interface.Cabecalho();
            Console.Write($"\n\nDeposito de R${deposito} efetuado com sucesso! O saldo atual é de R${deposito + saldo}");
            return deposito;
        }


    }
    public class Cliente
    {
        public string nome, sobrenome, fisicaOUjuridica;
        public int cpf, senha;

        public static string PJouPF(int opcao)
        {
            string pjpf = "Por favor não leia isso, se vc leu, então é pq bugou";
            if (opcao == 1)
            {
                pjpf = "Pessoa Física";
            }
            else
            {
                pjpf = "Pessoa Jurídica";
            }
            return pjpf;
        }
    }
}
