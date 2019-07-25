namespace MSeifert.Linq.MinMax
{
    /// <summary>
    /// Swap utility class.
    /// </summary>
    internal static class Swapper
    {
        /// <summary>Swaps the value of two variables.</summary>
        /// <typeparam name="T">The type of the variables.</typeparam>
        /// <param name="left">The first variable.</param>
        /// <param name="right">The second variable</param>
        public static void Swap<T>(ref T left, ref T right)
        {
            var tmp = left;
            left = right;
            right = tmp;
        }
    }
}
