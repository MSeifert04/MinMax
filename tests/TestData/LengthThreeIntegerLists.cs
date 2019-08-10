using System.Collections.Generic;
using Xunit;

namespace MSeifert.MinMax.Tests.TestData
{
    internal class LengthThreeIntegerLists : TheoryData<List<int>>
    {
        public LengthThreeIntegerLists()
        {
            Add(new List<int> { 1, 2, 3 });
            Add(new List<int> { 1, 3, 2 });
            Add(new List<int> { 2, 1, 3 });
            Add(new List<int> { 2, 3, 1 });
            Add(new List<int> { 3, 1, 2 });
            Add(new List<int> { 3, 2, 1 });
        }
    }
}
