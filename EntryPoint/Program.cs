using BubbleTier.Business;
using BubbleTier.Presentation;
using BubbleTier.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            do
            {
                Console.WriteLine("Scegli i dati da ordinare: 1 = casuali, 2 = cifre di PI");
                var choiceText = Console.ReadLine();

                if (!int.TryParse(choiceText, out var choice))
                {
                    Console.WriteLine("Scelta non valida.");
                    Console.ReadLine();
                    return;
                }

                var builder = Host.CreateApplicationBuilder(args);

                if (choice == 2)
                    builder.Services.AddSingleton<INumbersRepository, PiGrecoRepository>();
                else
                    builder.Services.AddSingleton<INumbersRepository, NumbersRepository>();

                builder.Services.AddSingleton<IBubbleSortService, BubbleSortService>();
                builder.Services.AddSingleton<ControllerToOrder>();

                using var host = builder.Build();

                var controller = host.Services.GetRequiredService<ControllerToOrder>();
                var result = controller.GetOrderedNumbers();

                Console.WriteLine("Dati non ordinati:");
                PrintArray(result.unordered);
                Console.WriteLine();
                Console.WriteLine("Dati ordinati:");
                PrintArray(result.ordered);
                Console.WriteLine("Premi 1 per uscire: ");
                var exitText = Console.ReadLine();
                exit = int.TryParse(exitText, out var exitValue) && exitValue == 1;
            } while (!exit);
        }
        static void PrintArray(IEnumerable<int> numbers)
        {
            var str = string.Join(", ", numbers);
            Console.WriteLine(str);
        }
    }
}
