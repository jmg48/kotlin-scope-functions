
using System;
using System.Threading.Tasks;

namespace Kotlin
{
    public static class ScopeFunctionExtensions
    {
        public static TOut? Let<TIn, TOut>(this TIn value, Func<TIn, TOut?> func) => func(value);

        public static Task<TOut?> LetAsync<TIn, TOut>(this TIn value, Func<TIn, Task<TOut?>> func) => func(value);

        public static T? Also<T>(this T? value, Action<T> func)
        {
            if (value != null)
            {
                func(value);
            }

            return value;
        }

        public static async Task<T?> AlsoAsync<T>(this T? value, Func<T, Task> func)
        {
            if (value != null)
            {
                await func(value);
            }

            return value;
        }

        public static T? TakeIf<T>(this T value, Func<T, bool> predicate) => predicate(value) ? value : default;

        public static async Task<T?> TakeIfAsync<T>(this Task<T> value, Func<T, bool> predicate) => (await value).Let(it => predicate(it) ? it : default);
    }
}