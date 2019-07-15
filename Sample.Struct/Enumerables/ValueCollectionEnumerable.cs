using System.Collections;
using System.Collections.Generic;

namespace Sample.Struct.Enumerables
{
    public static class ValueCollectionEnumerable
    {
        public static Enumerable<T, Dictionary<TKey, T>.ValueCollection.Enumerator, ValueCollectionEnumerable<TKey, T>> AsStructEnumerable<TKey, T>
            (this Dictionary<TKey, T>.ValueCollection keys)
            => new Enumerable<T, Dictionary<TKey, T>.ValueCollection.Enumerator, ValueCollectionEnumerable<TKey, T>>
                (new ValueCollectionEnumerable<TKey,T>(keys));
    }

    public readonly struct ValueCollectionEnumerable<TKey, T> : IEnumerable<T, Dictionary<TKey, T>.ValueCollection.Enumerator>
    {
        internal ValueCollectionEnumerable(Dictionary<TKey, T>.ValueCollection unwrap) => Unwrap = unwrap;

        public Dictionary<TKey, T>.ValueCollection Unwrap { get; }

        public Dictionary<TKey, T>.ValueCollection.Enumerator GetEnumerator() => Unwrap.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}