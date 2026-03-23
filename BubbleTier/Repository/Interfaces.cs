using System.Collections.Generic;

namespace BubbleTier
{
    public interface INumbersRepository
    {
        public IEnumerable<int> GetAll();
    }
}