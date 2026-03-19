namespace BubbleTier
{
    // Qyuesto è l'entry point e vedilo al di fuori dei livelli... immaginalo come l'utente finale che consuma il presentation layer
    internal class Program
    {
        static void Main(string[] args)
        {
            // devo creare una istanza del Controller per consumare il presentation layer
            // qualcosa tipo 'new OrderedNumberController()' ma c'è un problema serve il service da mettere come parametro... e a sua volta il repository...
            // Quindi qui ora costruisco la catena delle dipendenze

            var repository = new NumbersRepository();
            var service = new BubbleSortService(repository);
            var controller = new OrderedNumberController(service);

            // ora posso consumare il presentation layer
            var result = controller.GetOrderedNumbers();

            Console.WriteLine("Dati non ordinati:");
            PrintArray([.. result.unordered]);
            Console.WriteLine();
            Console.WriteLine("Dati ordinati:");
            PrintArray([.. result.ordered]);
        }
        static void PrintArray(IEnumerable<int> numbers)
        {
            var str = string.Join(", ", numbers);
            Console.WriteLine(str);
        }
    }
}
