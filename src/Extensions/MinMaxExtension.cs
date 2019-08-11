using System;
using System.Collections.Generic;

namespace MiSe.MinMax.Extensions
{
    /// <summary>
    /// <para>The MinMax extension methods for <see cref="IEnumerable{T}"/>.</para>
    /// <para>The MinMax methods return the minimum and maximum item of the enumerable.</para>
    /// </summary>
    public static class MinMaxExtension
    {
        /// <summary
        /// >Returns the minimum and maximum value of an iterable. In case of multiple occurrences
        /// the first instance is returned.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the values in the <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The enumerable of values from which to get the minimum and maximum.
        /// </param>
        /// <returns>
        /// A value tuple containing the minimum (first element) and maximum (second element).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="source"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="source"/> contains no elements.
        /// </exception>
        public static MinMaxResult<T> MinMax<T>(this IEnumerable<T> source) where T : IComparable<T>
            => MinMaxOps.MinMax(source);

        /// <summary>
        /// Returns the minimum and maximum value of an iterable using a comparer. In case of
        /// multiple occurrences the first instance is returned.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the values in the <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The enumerable of values from which to get the minimum and maximum.
        /// </param>
        /// <param name="comparer">
        /// The comparer for the values.
        /// </param>
        /// <returns>
        /// A value tuple containing the minimum (first element) and maximum (second element).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="source"/> or <paramref name="comparer"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="source"/> contains no elements.
        /// </exception>
        public static MinMaxResult<T> MinMax<T>(this IEnumerable<T> source, IComparer<T> comparer)
            => MinMaxOps.MinMax(source, comparer);
    }
}
