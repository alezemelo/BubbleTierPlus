namespace BubbleTier.Repository
{
    public class NumbersRepository : INumbersRepository
    {
        /// <summary>
        /// Questo metodo restituisce una sequenza di numeri interi casuali compresi tra -5000 e 5000. 
        /// Il numero di elementi restituiti è anch'esso casuale, compreso tra 100 e 1000. 
        /// I numeri restituiti sono unici, ovvero non ci sono duplicati nella sequenza.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetAll()
        {
            var random = new Random();
            var count = random.Next(100, 1001);
            var usedNumbers = new HashSet<int>();

            for (int i = 0; i < count; i++)
            {
                int number;
                do
                {
                    number = random.Next(-5000, 5001);
                } while (!usedNumbers.Add(number));

                yield return number; //numeri ritornati uno alla volta, senza dover aspettare che tutta la sequenza sia generata
            }
        }
    }
}
