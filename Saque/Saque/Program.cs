using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saque
{
    internal class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                var notasDisponiveis = new Dictionary<int, int>();
                var totalDisponivel = 0;

                Console.WriteLine($"Digite a quantidade de notas disponíveis de 100:");
                var notas = Convert.ToInt32(Console.ReadLine());
                notasDisponiveis.Add(100, notas);
                totalDisponivel += 100 * notas;

                Console.WriteLine($"Digite a quantidade de notas disponíveis de 50:");
                notas = Convert.ToInt32(Console.ReadLine());
                notasDisponiveis.Add(50, notas);
                totalDisponivel += 50 * notas;

                Console.WriteLine($"Digite a quantidade de notas disponíveis de 20:");
                notas = Convert.ToInt32(Console.ReadLine());
                notasDisponiveis.Add(20, notas);
                totalDisponivel += 20 * notas;

                Console.WriteLine($"Digite a quantidade de notas disponíveis de 10:");
                notas = Convert.ToInt32(Console.ReadLine());
                notasDisponiveis.Add(10, notas);
                totalDisponivel += 10 * notas;

                Console.WriteLine($"Total disponível em notas: {totalDisponivel}");

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite o valor do saque ou 'r' para reiniciar o programa: ");
                    var entrada = Console.ReadLine();

                    if (entrada == "r")
                        break;

                    var saque = Convert.ToInt32(entrada);

                    //Só temos notas que são divisíveis por 10, não podendo sacar 52 ou 65 por exemplo.
                    if (saque % 10 != 0)
                    {
                        Console.WriteLine("Saque não efetuado. Só é possível sacar valores divisíveis por 10.");
                        continue;
                    }

                    //Saque disponível
                    if (saque > totalDisponivel)
                    {
                        Console.WriteLine($"Saque não efetuado. Infelizmente não temos o valor de saque disponível em caixa. Saque máximo disponível: {totalDisponivel}");
                        continue;
                    }

                    var notasUtilizadas = new Dictionary<int, int>()
                    {
                        {100, 0},
                        {50, 0},
                        {20, 0},
                        {10, 0}
                    };

                    foreach (var notaDisponivel in notasDisponiveis)
                    {
                        var qtdNotas = notaDisponivel.Value;

                        while (qtdNotas > 0)
                        {
                            if (saque - notaDisponivel.Key < 0)
                                break;

                            saque -= notaDisponivel.Key;
                            notasUtilizadas[notaDisponivel.Key]++;
                            qtdNotas--;
                        }
                    }

                    if (saque != 0)
                    {
                        Console.WriteLine("Saque não efetuado. Não temos notas disponíveis para sacar este valor.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Saque efetuado com sucesso! Notas utilizadas:");
                        Console.WriteLine($"Notas de 100: {notasUtilizadas[100]}");
                        Console.WriteLine($"Notas de 50: {notasUtilizadas[50]}");
                        Console.WriteLine($"Notas de 20: {notasUtilizadas[20]}");
                        Console.WriteLine($"Notas de 10: {notasUtilizadas[10]}");
                    }
                }
            }
        }
    }
}
