using System.Collections.Generic;

namespace BubbleTier
{
    public interface IBubbleSortService
    {
        public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedNumbers();

    }
 
}