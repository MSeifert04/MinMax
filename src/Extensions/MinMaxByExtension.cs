using System;
using System.Collections.Generic;

namespace MiSe.MinMax.Extensions
{
    /// <summary>
    /// <para>
    /// The MinMaxBy extension methods for <see cref="IEnumerable{T}"/>
    /// </para>
    /// <para>
    /// The MinMaxBy methods return the minimum and maximum item of the enumerable by comparing the
    /// result of a key-function applied to the items. The functions will not return the result of
    /// the key-function but the actual item that had the minimum/maximum key.
    /// In this regard these methods differs from the overload of Min and Max in the System.Linq
    /// namespace that take a function to **transform** the elements.
    /// </para>
    /// </summary>
    public static class MinMaxByExtension
    {
        /// <summary>
        /// Returns the minimum and maximum value of an iterable by comparing the results of a
        /// selector function. In case of multiple occurrences the first instance is returned.
        /// </summary>
        /// <typeparam name="TItem">
        /// The type of the values in the <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the values returned by the <paramref name="keyFunc"/> function.
        /// </typeparam>
        /// <param name="source">
        /// The enumerable of values from which to get the minimum and maximum.
        /// </param>
        /// <param name="keyFunc">
        /// The selector function that converts the values in the <paramref name="source"/> to the
        /// values that are compared.
        /// </param>
        /// <returns>
        /// A value tuple containing the minimum (first element) and maximum (second element).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="source"/> or <paramref name="keyFunc"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="source"/> contains no elements.
        /// </exception>
        public static MinMaxResult<TItem> MinMaxBy<TItem, TKey>(
            this IEnumerable<TItem> source,
            Func<TItem, TKey> keyFunc
            ) where TKey : IComparable<TKey>
            => MinMaxOps.MinMaxBy(source, keyFunc);

        /// <summary>
        /// Returns the minimum and maximum value of an iterable by comparing the results of a
        /// selector function. In case of multiple occurrences the first instance is returned.
        /// </summary>
        /// <typeparam name="TItem">
        /// The type of the values in the <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the values returned by the <paramref name="keyFunc"/> function.
        /// </typeparam>
        /// <param name="source">
        /// The enumerable of values from which to get the minimum and maximum.
        /// </param>
        /// <param name="keyFunc">
        /// The selector function that converts the values in the <paramref name="source"/> to the
        /// values that are compared.
        /// </param>
        /// <param name="comparer">
        /// The comparer for the values returned by the selector.
        /// </param>
        /// <returns>
        /// A value tuple containing the minimum (first element) and maximum (second element).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="source"/> or <paramref name="keyFunc"/> or
        /// <paramref name="comparer"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="source"/> contains no elements.
        /// </exception>
        public static MinMaxResult<TItem> MinMaxBy<TItem, TKey>(
            this IEnumerable<TItem> source,
            Func<TItem, TKey> keyFunc,
            IComparer<TKey> comparer
            )
            => MinMaxOps.MinMaxBy(source, keyFunc, comparer);
    }
}
