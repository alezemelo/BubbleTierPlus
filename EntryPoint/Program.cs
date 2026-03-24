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
            Choice c;
            var builder = Host.CreateApplicationBuilder(args);

            // Le repo non hanno uno stato e non devono essere ricreate ad ogni richiesta, quindi le registriamo come singleton.

            builder.Services.AddKeyedSingleton<INumbersRepository, PiGrecoRepository>("pigreco");
            builder.Services.AddKeyedSingleton<INumbersRepository, NumbersRepository>("random");

            //Il servizio di BubbleSort dipende dalla scelta choice fatta ad utente in un loop do while, quindi non possiamo registrarlo come singleton,
            //perche avrebbe una dipendenza che (potenzialmente) cambia ad ogni iterazione del loop.

            builder.Services.AddScoped<IBubbleSortService, BubbleSortService>();
            builder.Services.AddScoped<ControllerToOrder>();

            //Un servizio (es in questo caso: ControllerToOrder) non dovrebbe mai dipendere da un altro servizio (BubbleSortService) a lifetime più corto del suo --> Captive Dependency
            // Se ControllerToOrder fosse stato registrato come singleton, avrebbe una dipendenza captive su BubbleSortService che è scoped,
            // e questo non va bene perche il servizio singleton vivrebbe più a lungo del servizio scoped, e potrebbe accedere a un'istanza di BubbleSortService che è stata già eliminata
            // dallo scope precedente.
            // 1 - Singleton
            // 2 - Scoped
            // 3 - Transient

            using var host = builder.Build();


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

                using (var scope = host.Services.CreateScope())
                {
                    var controller = scope.ServiceProvider.GetRequiredService<ControllerToOrder>();

                    c = choice == 1 ? Choice.RandndomNumbers : Choice.PiGreco;
                    var result = controller.GetOrderedNumbers(c);
                    PrintOrders(result);
                }

                Console.Write("\nPremi 1 per uscire: ");
                var exitText = Console.ReadLine();
                exit = int.TryParse(exitText, out var exitValue) && exitValue == 1;

            } while (!exit);
        }

        // Questo metodo stampa i numeri ordinati e non ordinati in console.
        static void PrintOrders((IEnumerable<int> ordered, IEnumerable<int> unordered) result)
        {
            Console.WriteLine("Dati non ordinati:");
            PrintArray(result.unordered);
            Console.WriteLine();
            Console.WriteLine("Dati ordinati:");
            PrintArray(result.ordered);
            
        }

        // Questo metodo prende una sequenza di numeri interi e li stampa in console separati da virgole.
        static void PrintArray(IEnumerable<int> numbers)
        {
            var str = string.Join(", ", numbers);
            Console.WriteLine(str);
        }
    }
}


// 1. Finisci di implementare la scelta da ui
// 2. fai in modo che adf ogni scelta sia inizializzato un nuovo scope
// 