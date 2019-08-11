using System;
using System.Collections.Generic;

namespace MiSe.MinMax
{
    /// <summary>Class containing the MinMax methods.</summary>
    public static class MinMaxOps
    {
        /// <summary>
        /// Returns the minimum and maximum value of an iterable. In case of multiple occurrences
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
        public static MinMaxResult<T> MinMax<T>(IEnumerable<T> source) where T : IComparable<T>
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(Texts.Texts.ContainsNoElements);
            }

            var min = enumerator.Current;
            var max = min;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    if (firstItem.CompareTo(secondItem) > 0)
                    {
                        (firstItem, secondItem) = (secondItem, firstItem);
                    }
                    if (firstItem.CompareTo(min) < 0)
                    {
                        min = firstItem;
                    }
                    if (secondItem.CompareTo(max) > 0)
                    {
                        max = secondItem;
                    }
                }
                else
                {
                    if (firstItem.CompareTo(min) < 0)
                    {
                        min = firstItem;
                    }
                    else if (firstItem.CompareTo(max) > 0)
                    {
                        max = firstItem;
                    }
                }
            }
            return new MinMaxResult<T>(min, max);
        }

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
        public static MinMaxResult<T> MinMax<T>(IEnumerable<T> source, IComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
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

            var min = enumerator.Current;
            var max = min;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    if (comparer.Compare(firstItem, secondItem) > 0)
                    {
                        (firstItem, secondItem) = (secondItem, firstItem);
                    }
                    if (comparer.Compare(firstItem, min) < 0)
                    {
                        min = firstItem;
                    }
                    if (comparer.Compare(secondItem, max) > 0)
                    {
                        max = secondItem;
                    }
                }
                else
                {
                    if (comparer.Compare(firstItem, min) < 0)
                    {
                        min = firstItem;
                    }
                    else if (comparer.Compare(firstItem, max) > 0)
                    {
                        max = firstItem;
                    }
                }
            }
            return new MinMaxResult<T>(min, max);
        }

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
            IEnumerable<TItem> source,
            Func<TItem, TKey> keyFunc
            ) where TKey : IComparable<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keyFunc == null)
            {
                throw new ArgumentNullException(nameof(keyFunc));
            }

            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException(Texts.Texts.ContainsNoElements);
            }

            var key = keyFunc(enumerator.Current);
            var min = enumerator.Current;
            var max = min;
            var minKey = key;
            var maxKey = key;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                var firstItemKey = keyFunc(firstItem);
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    var secondItemKey = keyFunc(secondItem);
                    if (firstItemKey.CompareTo(secondItemKey) > 0)
                    {
                        (firstItem, secondItem) = (secondItem, firstItem);
                        (firstItemKey, secondItemKey) = (secondItemKey, firstItemKey);
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
            IEnumerable<TItem> source,
            Func<TItem, TKey> keyFunc,
            IComparer<TKey> comparer
            )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keyFunc == null)
            {
                throw new ArgumentNullException(nameof(keyFunc));
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

            var key = keyFunc(enumerator.Current);
            var min = enumerator.Current;
            var max = min;
            var minKey = key;
            var maxKey = key;
            while (enumerator.MoveNext())
            {
                var firstItem = enumerator.Current;
                var firstItemKey = keyFunc(firstItem);
                if (enumerator.MoveNext())
                {
                    var secondItem = enumerator.Current;
                    var secondItemKey = keyFunc(secondItem);
                    if (comparer.Compare(firstItemKey, secondItemKey) > 0)
                    {
                        (firstItem, secondItem) = (secondItem, firstItem);
                        (firstItemKey, secondItemKey) = (secondItemKey, firstItemKey);
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
