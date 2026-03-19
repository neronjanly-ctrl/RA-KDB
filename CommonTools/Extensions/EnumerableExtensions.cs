using System.Collections.Concurrent;
using System.Collections.Generic;

namespace System.Linq;

public static class EnumerableExtensions
{
    /// <summary>
    ///     Creates a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>
    ///     according to a specified key selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">An <see cref="IEnumerable&lt;TSource&gt;"/> to create a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <returns>A <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> that contains keys and values.</returns>
    /// <exception cref="ArgumentNullException">source or keySelector is null. -or- keySelector produces a key that is null.</exception>
    /// <exception cref="ArgumentException">keySelector produces duplicate keys for two elements.</exception>
    public static ConcurrentDictionary<TKey, TSource> ToConcurrentDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        return new ConcurrentDictionary<TKey, TSource>(source.ToDictionary(keySelector));
    }

    /// <summary>
    ///     Creates a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>
    ///     according to a specified key selector function and key comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">An <see cref="IEnumerable&lt;TSource&gt;"/> to create a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">An <see cref="IEqualityComparer&lt;TKey&gt;"/> to compare keys.</param>
    /// <returns>A <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> that contains keys and values.</returns>
    /// <exception cref="ArgumentNullException">source or keySelector is null. -or- keySelector produces a key that is null.</exception>
    /// <exception cref="ArgumentException">keySelector produces duplicate keys for two elements.</exception>
    public static ConcurrentDictionary<TKey, TSource> ToConcurrentDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
        return new ConcurrentDictionary<TKey, TSource>(source.ToDictionary(keySelector, comparer));
    }

    /// <summary>
    ///     Creates a <see cref="ConcurrentDictionary&lt;TKey, TElement&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>
    ///     according to specified key selector and element selector functions.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">An <see cref="IEnumerable&lt;TSource&gt;"/> to create a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <returns>A <see cref="ConcurrentDictionary&lt;TKey, TElement&gt;"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence.</returns>
    /// <exception cref="ArgumentNullException">source or keySelector is null. -or- keySelector produces a key that is null.</exception>
    /// <exception cref="ArgumentException">keySelector produces duplicate keys for two elements.</exception>
    public static ConcurrentDictionary<TKey, TElement> ToConcurrentDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
        return new ConcurrentDictionary<TKey, TElement>(source.ToDictionary(keySelector, elementSelector));
    }

    /// <summary>
    ///     Creates a <see cref="ConcurrentDictionary&lt;TKey, TElement&gt;"/> from an <see cref="IEnumerable&lt;TSource&gt;"/>
    ///     according to a specified key selector function, a comparer, and an element selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
    /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> to create a <see cref="ConcurrentDictionary&lt;TKey, TSource&gt;"/> from.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">An <see cref="System.Collections.Generic.IEqualityComparer&lt;TKey&gt;"/> to compare keys.</param>
    /// <returns>A <see cref="ConcurrentDictionary&lt;TKey, TElement&gt;"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence.</returns>
    /// <exception cref="ArgumentNullException">source or keySelector is null. -or- keySelector produces a key that is null.</exception>
    /// <exception cref="ArgumentException">keySelector produces duplicate keys for two elements.</exception>
    public static ConcurrentDictionary<TKey, TElement> ToConcurrentDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
        return new ConcurrentDictionary<TKey, TElement>(source.ToDictionary(keySelector, elementSelector, comparer));
    }
}
