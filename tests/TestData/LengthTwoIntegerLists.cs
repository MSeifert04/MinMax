using System.Collections.Generic;
using Xunit;

namespace MSeifert.Linq.MinMax.Tests.TestData
{
    internal class LengthTwoIntegerLists : TheoryData<List<int>>
    {
        public LengthTwoIntegerLists()
        {
            Add(new List<int> { 1, 2 });
            Add(new List<int> { 2, 1 });
        }
    }
}
