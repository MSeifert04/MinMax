using System;
using System.Collections.Generic;

namespace MSeifert.Linq.MinMax
{
    /// <summary>
    /// <para>The MinMax extension methods for <see cref="IEnumerable{T}"/>.</para>
    /// <para>The MinMax methods return the minimum and maximum item of the enumerable.</para>
    /// </summary>
    public static class MinMaxExt
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
                        Swapper.Swap(ref firstItem, ref secondItem);
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
        public static MinMaxResult<T> MinMax<T>(this IEnumerable<T> source, IComparer<T> comparer)
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
                        Swapper.Swap(ref firstItem, ref secondItem);
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
    }
}

