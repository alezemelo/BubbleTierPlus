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


    }
}
