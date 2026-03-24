using BubbleTier.Presentation;

namespace EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scegli i dati da ordinare: 1 = casuali, 2 = cifre di PI");
            var choiceText = Console.ReadLine();
            if (int.TryParse(choiceText, out var choice))
            {
                var controller = new ControllerToOrder(choice);
                var result = controller.GetOrderedNumbers();
                //var piResult = controller.GetOrderedNumersPi();
                Console.WriteLine("Dati non ordinati:");
                PrintArray([.. result.unordered]);
                Console.WriteLine();
                Console.WriteLine("Dati ordinati:");
                PrintArray([.. result.ordered]);
            }
            Console.ReadLine();
        }
        static void PrintArray(IEnumerable<int> numbers)
        {
            var str = string.Join(", ", numbers);
            Console.WriteLine(str);
        }
    }
}
