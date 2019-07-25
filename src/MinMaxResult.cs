namespace MSeifert.Linq.MinMax
{
    /// <summary>
    /// Representing the result of a <see cref="MinMaxExt.MinMax{T}(System.Collections.Generic.IEnumerable{T})"/> invocation.
    /// </summary>
    /// <typeparam name="T">The type of items.</typeparam>
    public readonly struct MinMaxResult<T>
    {
        /// <summary>
        /// The minimum of the enumerable.
        /// </summary>
        /// <value>The stored minimum.</value>
        public T Minimum { get; }

        /// <summary>
        /// The maximum of the enumerable.
        /// </summary>
        /// <value>The stored maximum.</value>
        public T Maximum { get; }

        /// <summary>
        /// Create a new result instance.
        /// </summary>
        /// <param name="minimum">The minimum of the enumerable.</param>
        /// <param name="maximum">The maximum of the enumerable.</param>
        internal MinMaxResult(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
