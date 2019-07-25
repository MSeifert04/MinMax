using System.Collections.Generic;
using Xunit;

namespace MSeifert.Linq.MinMax.Tests.TestData
{
    internal class LengthFourIntegerLists : TheoryData<List<int>>
    {
        public LengthFourIntegerLists()
        {
            Add(new List<int> { 1, 2, 3, 4 });
            Add(new List<int> { 1, 2, 4, 3 });
            Add(new List<int> { 1, 3, 2, 4 });
            Add(new List<int> { 1, 3, 4, 2 });
            Add(new List<int> { 1, 4, 2, 3 });
            Add(new List<int> { 1, 4, 3, 2 });

            Add(new List<int> { 2, 1, 3, 4 });
            Add(new List<int> { 2, 1, 4, 3 });
            Add(new List<int> { 2, 3, 1, 4 });
            Add(new List<int> { 2, 3, 4, 1 });
            Add(new List<int> { 2, 4, 1, 3 });
            Add(new List<int> { 2, 4, 3, 1 });

            Add(new List<int> { 3, 1, 2, 4 });
            Add(new List<int> { 3, 1, 4, 2 });
            Add(new List<int> { 3, 2, 1, 4 });
            Add(new List<int> { 3, 2, 4, 1 });
            Add(new List<int> { 3, 4, 1, 2 });
            Add(new List<int> { 3, 4, 2, 1 });

            Add(new List<int> { 4, 1, 2, 3 });
            Add(new List<int> { 4, 1, 3, 2 });
            Add(new List<int> { 4, 2, 1, 3 });
            Add(new List<int> { 4, 2, 3, 1 });
            Add(new List<int> { 4, 3, 1, 2 });
            Add(new List<int> { 4, 3, 2, 1 });
        }
    }
}
