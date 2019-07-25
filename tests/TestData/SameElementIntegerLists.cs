using System.Collections.Generic;
using Xunit;

namespace MSeifert.Linq.MinMax.Tests.TestData
{
    internal class SameElementIntegerLists : TheoryData<List<int>>
    {
        public SameElementIntegerLists()
        {
            Add(new List<int> { 1 });
            Add(new List<int> { 1, 1 });
            Add(new List<int> { 1, 1, 1 });
            Add(new List<int> { 1, 1, 1, 1 });
            Add(new List<int> { 1, 1, 1, 1, 1 });
            Add(new List<int> { 1, 1, 1, 1, 1, 1 });
            Add(new List<int> { 1, 1, 1, 1, 1, 1, 1 });
            Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 });
        }
    }
}
