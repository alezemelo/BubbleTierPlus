using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleTier
{
    internal class OrderedNumberController
    {
        private readonly BubbleSortService _sortService;

        public OrderedNumberController(BubbleSortService sortService) {
        
            // Il controller dipende dal Service (non di deve porre il problema delle dipendenze del servizio)
            _sortService = sortService;
        }

        public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedNumbers() {
            // Il controller si occupa di orchestrare le chiamate al servizio e al repository per ottenere i dati ordinati.
            // In questo caso, chiama il metodo BubbleSort del servizio per ordinare i numeri ottenuti dal repository.
            // Il servizio restituisce gia un tipo identico o compatibile con questo livello di presentazione.
            return _sortService.GetOrderedNumbers();
        }

        //public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedNumersPi() {
            // Se vogliamo esporre anche i numeri non ordinati, possiamo aggiungere un metodo che chiama direttamente il repository per ottenere i dati non ordinati.
            // In questo caso, chiama il metodo GetAll del repository per ottenere i numeri non ordinati.
            //return _sortService.GetOrderedPiDigits();
        //}

    }
}
