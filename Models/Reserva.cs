using System.Diagnostics;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
            suite.SelecionarTipoSuite();

        }


        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Suite.SelecionarCapacidade();

        }
       

        public int ObterQuantidadeHospedes()
        {
            return Suite.Capacidade;
        }


        public decimal CalcularValorDiaria()
        {
            Suite.CalcularValorDiaria();

            while (true)
            {

                try
                {

                    Console.WriteLine("Quantos dias deseja reservar? ");
                    DiasReservados = int.Parse(Console.ReadLine());

                    if (DiasReservados > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Número de dias inválido. A reserva deve ser feita para pelo menos 1 dia.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }


            Console.WriteLine("Calculando o valor da quantiade de dias...");
            Console.WriteLine($"Dias reservados: {DiasReservados}");


            decimal valor = Suite.ValorDiaria * DiasReservados * Suite.QuantidadeHospedes;
            Console.WriteLine($"Valor da reserva sem desconto: R$ {valor:F2}");


            if (DiasReservados >= 10)
            {
                valor = (valor - (valor * 0.10M));
                Console.WriteLine("Desconto de 10% aplicado para reservas acima de 10 dias!");
            }

            else
            {

                Console.WriteLine("Nenhum desconto aplicado.");
            }



            return decimal.Parse(valor.ToString("F2"));
        }
        
        

    }
    
}