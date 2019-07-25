using System;
using System.Collections.Generic;

namespace MSeifert.Linq.MinMax
{
    /// <summary>
    /// The MinMaxBy extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class MinMaxByExt
    {
        /// <summary>Returns the minimum and maximum value of an iterable by comparing the results of a selector function. In case of multiple occurrences the first instance is returned.</summary>
        /// <typeparam name="TItem">The type of the values in the <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the values returned by the <paramref name="selector"/> function.</typeparam>
        /// <param name="source">The enumerable of values from which to get the minimum and maximum.</param>
        /// <param name="selector">The selector function that converts the values in the <paramref name="source"/> to the values that are compared.</param>
        /// <returns>A value tuple containing the minimum (first element) and maximum (second element).</returns>
        /// <exception cref="ArgumentNullException">If the <paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If the <paramref name="source"/> contains no elements.</exception>
        public static MinMaxResult<TItem> MinMaxBy<TItem, TKey>(this IEnumerable<TItem> source, Func<TItem, TKey> selector) where TKey : IComparable<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(Texts.Texts.ContainsNoElements);
            }

            var key = selector(enumerator.Current);
            var min = enumerator.Current;
            var max = min;
            var minKey = key;
            var maxKey = key;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                var firstItemKey = selector(firstItem);
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    var secondItemKey = selector(secondItem);
                    if (firstItemKey.CompareTo(secondItemKey) > 0)
                    {
                        Swapper.Swap(ref firstItem, ref secondItem);
                        Swapper.Swap(ref firstItemKey, ref secondItemKey);
                    }
                    if (firstItemKey.CompareTo(minKey) < 0)
                    {
                        min = firstItem;
                        minKey = firstItemKey;
                    }
                    if (secondItemKey.CompareTo(maxKey) > 0)
                    {
                        max = secondItem;
                        maxKey = secondItemKey;
                    }
                }
                else
                {
                    if (firstItemKey.CompareTo(minKey) < 0)
                    {
                        min = firstItem;
                        minKey = firstItemKey;
                    }
                    else if (firstItemKey.CompareTo(maxKey) > 0)
                    {
                        max = firstItem;
                        maxKey = firstItemKey;
                    }
                }
            }
            return new MinMaxResult<TItem>(min, max);
        }


        /// <summary>Returns the minimum and maximum value of an iterable by comparing the results of a selector function. In case of multiple occurrences the first instance is returned.</summary>
        /// <typeparam name="TItem">The type of the values in the <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the values returned by the <paramref name="selector"/> function.</typeparam>
        /// <param name="source">The enumerable of values from which to get the minimum and maximum.</param>
        /// <param name="selector">The selector function that converts the values in the <paramref name="source"/> to the values that are compared.</param>
        /// <param name="comparer">The comparer for the values returned by the selector.</param>
        /// <returns>A value tuple containing the minimum (first element) and maximum (second element).</returns>
        /// <exception cref="ArgumentNullException">If the <paramref name="source"/> or <paramref name="selector"/> or <paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If the <paramref name="source"/> contains no elements.</exception>
        public static MinMaxResult<TItem> MinMaxBy<TItem, TKey>(this IEnumerable<TItem> source, Func<TItem, TKey> selector, IComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(Texts.Texts.ContainsNoElements);
            }

            var key = selector(enumerator.Current);
            var min = enumerator.Current;
            var max = min;
            var minKey = key;
            var maxKey = key;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                var firstItemKey = selector(firstItem);
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    var secondItemKey = selector(secondItem);
                    if (comparer.Compare(firstItemKey, secondItemKey) > 0)
                    {
                        Swapper.Swap(ref firstItem, ref secondItem);
                        Swapper.Swap(ref firstItemKey, ref secondItemKey);
                    }
                    if (comparer.Compare(firstItemKey, minKey) < 0)
                    {
                        min = firstItem;
                        minKey = firstItemKey;
                    }
                    if (comparer.Compare(secondItemKey, maxKey) > 0)
                    {
                        max = secondItem;
                        maxKey = secondItemKey;
                    }
                }
                else
                {
                    if (comparer.Compare(firstItemKey, minKey) < 0)
                    {
                        min = firstItem;
                        minKey = firstItemKey;
                    }
                    else if (comparer.Compare(firstItemKey, maxKey) > 0)
                    {
                        max = firstItem;
                        maxKey = firstItemKey;
                    }
                }
            }
            return new MinMaxResult<TItem>(min, max);
        }
    }
}
