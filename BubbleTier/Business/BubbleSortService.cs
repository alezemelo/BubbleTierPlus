using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleTier
{
    /// <summary>
    /// Classe che contiene la logica di business (o chiamala del service layer se preferisci) per eseguire la bubble sort su una lista di interi non ordinati.
    /// </summary>
    internal class BubbleSortService
    {
        /// <summary>
        /// The number repository.
        /// Questo si chiama Campo della classe o field.
        /// In questo caso è una variabile che appartiene alla classe e viene usata per memorizzare un riferimento a un oggetto di tipo NumbersRepository, che è necessario per accedere ai dati da ordinare.)
        /// </summary>
        private readonly INumbersRepository _numberRepository;

        // NON serve un campo nel servizio per gestire la lista di numeri... non è compito del servizio procacciarsi i dati...e soprattutto non serve statico perche vivrebbe trasversalmente alle istanze delle classi, e non è questo il comportamento che vogliamo. 
        //public static int[] numbersUnorderedSequence { get; private set; }
        public BubbleSortService(INumbersRepository numberRepository)
        {
            this._numberRepository = numberRepository;
        }
       
        // Non è compito del servizio ottenere i dati lo fa il repository per noi
        //public static int[] GetRepoData()
        //{
        //    NumbersRepository repository = new NumbersRepository();
        //    int[] toBeOrdered = new int[Config.numeroDiNumeriDaOrdinare];
        //    for (int i = 0; i < Config.numeroDiNumeriDaOrdinare; i++)
        //    {
        //        toBeOrdered[i] = repository.GetData();
        //    }
        //    return toBeOrdered;
        //}



        // Questo metodo prende in input un array di interi non ordinati e restituisce un nuovo array con gli stessi numeri ordinati in modo crescente.
        // Si puo usare solo dentro questa classe o dentro le classi che la ereditano (protected). non la puoi chiamare da fuori della classe.
        protected int[] BubbleSort(int[] numbersUnorderedSequence)
        {
            // Copia per evitare di 'toccare' l'array originale
            int[] resultantOrderedArray = (int[])numbersUnorderedSequence.Clone();
            int n = resultantOrderedArray.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (resultantOrderedArray[j] > resultantOrderedArray[j + 1])
                    {
                        // scambio i due elementi
                        // Crea una tupla temporanea che contiene i valori nelle posizioni invertite.
                        // Esempio: se array[j] = 5 e array[j + 1] = 3, crea la tupla(3, 5) e ci assegna la trupla creata in modo invertito (5,3).
                        (resultantOrderedArray[j], resultantOrderedArray[j + 1]) = (resultantOrderedArray[j + 1], resultantOrderedArray[j]);
                    }
                }
            }

            return resultantOrderedArray;
        }

        /// <summary>
        /// Gets the ordered numbers.
        /// Questo è il metodo pubblico che possono utilizzare i consumatori del servizio per ottenere i numeri ordinati.
        /// I consumatori saranno nel layer di presentazione (o chiamalo UI layer se preferisci) che è quello che si occupa di interagire con l'utente e mostrare i risultati.
        /// </summary>
        /// <returns>Ritorna una tupla con i numeri ordinati e come erano prima dell'ordinamento</returns>
        public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedNumbers()
        {
            var unorderedNumbers = _numberRepository.GetAll();

            // Se unorderedNumbers è un IEnumerable<int>, devi convertirlo in un array usando ToArray() prima di passarlo a BubbleSort.
            //return BubbleSort(unorderedNumbers.ToArray()); // ma questo si puo fare oggi con l'espressione di raccolta che vedi qui sotto...
            var ordered = BubbleSort([.. unorderedNumbers]);
            // restituisco una tupla con sia i numeri ordinati che i numeri prima dell'ordinamento
            return (ordered, unorderedNumbers);
        }

        //public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedPiDigits()
        //{
        //    var unorderedNumbers = _piGrecoRepository.GetPi();
        //    var ordered = BubbleSort([.. unorderedNumbers]);
        //    return (ordered, unorderedNumbers);
        //}
    }
}
