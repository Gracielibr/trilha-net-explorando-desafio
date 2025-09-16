namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        private int quantidadeHospedes;
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public int QuantidadeHospedes { get; set; }
    

        public void SelecionarTipoSuite()
        {
            int opcao;
            bool opcaoValida = false;

            while (!opcaoValida)
            {
                Console.WriteLine("Escolha qual tipo de suíte que deseja reservar: ");
                Console.WriteLine("1 - Premium  - Capacidade de 3 hóspedes(R$ 100,00 p/ pessoa)");
                Console.WriteLine("2 - Luxo  - Capacidade de 4 hóspedes (R$ 50,00 p/ pessoa)");
                Console.WriteLine("3 - Standard  - Capacidade de 5 hóspedes(R$ 30,00 p/pessoa)");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        TipoSuite = "Premium";
                        ValorDiaria = 100;
                        Capacidade = 3;
                        Console.WriteLine("Suíte Premium selecionada!");
                        opcaoValida = true;
                        break;
                    case 2:
                        TipoSuite = "Luxo";
                        ValorDiaria = 50;
                        Capacidade = 4;
                        Console.WriteLine("Suíte Luxo selecionada!");
                        opcaoValida = true;
                        break;
                    case 3:
                        TipoSuite = "Standard";
                        ValorDiaria = 30;
                        Capacidade = 5;
                        Console.WriteLine("Suíte Standard selecionada!");
                        opcaoValida = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Escolha 1, 2 ou 3.");
                        break;

                }
            }
        }

        public void SelecionarCapacidade()
        {
            bool capacidadeValida = false;

            while (!capacidadeValida)
            {
                try
                {
                    Console.WriteLine($"Digite a quantidade de hóspedes que deseja reservar (máximo: {Capacidade}): ");
                    int quantidadeDesejada = int.Parse(Console.ReadLine());

                    if (quantidadeDesejada <= Capacidade && quantidadeDesejada > 0)
                        {
                        QuantidadeHospedes = quantidadeDesejada;
                        Console.WriteLine($"{quantidadeDesejada} hóspedes foram cadastrados com sucesso!");
                        capacidadeValida = true;

                        }  
                    else if (quantidadeDesejada <= 0)
                        {
                        throw new ArgumentException("A quantidade de hóspedes deve ser maior que zero.");
                        }
                    else
                        {
                        throw new ArgumentException($"A capacidade máxima desta suíte é {Capacidade} hóspedes.");
                        }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite um número válido.");                    }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Número muito grande. Digite um valor válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
        }

        public void CalcularValorDiaria()
        {
          
            Console.WriteLine("Calculando o valor da diária...");
            decimal valorTotal = ValorDiaria * QuantidadeHospedes; 
            Console.WriteLine($"Valor total da diária para {QuantidadeHospedes} hospede(s) é de: R$ {valorTotal:F2}");    
       
        }
    }
}