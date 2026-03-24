using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleTier.Business
{
    public interface IBubbleSortService
    {
        public (IEnumerable<int> ordered, IEnumerable<int> unordered) GetOrderedNumbers();

    }
}
