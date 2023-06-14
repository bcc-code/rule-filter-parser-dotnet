namespace BccCode.Linq.Async;

/// <summary>
/// Holding extension methods to <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
internal static class AsyncEnumerable
{
    /// <summary>
    /// Client side execution of Linq method <b>Select</b> with <see cref="IAsyncEnumerable{T}"/> as source. 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// Is thrown when either <paramref name="source"/> or <paramref name="selector"/> is <c>null</c>.
    /// </exception>
    public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        await foreach (var item in source)
        {
            yield return selector.Invoke(item);
        }
    }
}