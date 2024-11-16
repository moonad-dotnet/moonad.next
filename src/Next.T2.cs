using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonad
{
    public static partial class NextExtensions
    {
        public static void Next<T1, T2>(this (T1, T2) instance, Action<T1, T2> action) where T1 : notnull where T2 : notnull =>
            action(instance.Item1, instance.Item2);

        public static async Task Next<T1, T2>(this (T1, T2) instance, Func<T1, T2, Task> func) where T1: notnull where T2: notnull =>
            await func(instance.Item1, instance.Item2);

        public static async Task Next<T1, T2>(this Task<(T1, T2)> instance, Action<T1, T2> action) where T1: notnull where T2: notnull =>
            (await instance).Next(action);

        public static async Task Next<T1, T2>(this Task<(T1, T2)> instance, Func<T1, T2, Task> func) where T1: notnull where T2: notnull =>
            await (await instance).Next(func);

        public static async Task Next<T1, T2>(this (T1, T2) instance,
                                            Func<T1, T2, CancellationToken, Task> func,
                                            CancellationToken cancellationToken = default) where T1: notnull where T2: notnull =>
            await func(instance.Item1, instance.Item2, cancellationToken);

        public static async Task Next<T1, T2>(this Task<(T1, T2)> instance,
                                                   Func<T1, T2, CancellationToken, Task> func,
                                                   CancellationToken cancellationToken = default) where T1: notnull where T2: notnull =>
            await (await instance).Next(func, cancellationToken);

        public static U Next<T1, T2, U>(this (T1, T2) instance, Func<T1, T2, U> func) where T1 : notnull where T2 : notnull =>
            func(instance.Item1, instance.Item2);

        public static async Task<U> Next<T1, T2, U>(this (T1, T2) instance, Func<T1, T2, Task<U>> func) where T1 : notnull where T2 : notnull =>
            await func(instance.Item1, instance.Item2);

        public static async Task<U> Next<T1, T2, U>(this Task<(T1, T2)> instance, Func<T1, T2, U> func) where T1 : notnull where T2 : notnull =>
            (await instance).Next(func);

        public static async Task<U> Next<T1, T2, U>(this Task<(T1, T2)> instance, Func<T1, T2, Task<U>> func) where T1: notnull where T2: notnull =>
            await (await instance).Next(func);

        public static async Task<U> Next<T1, T2, U>(this (T1, T2) instance, 
                                                              Func<T1, T2, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) where T1 : notnull where T2 : notnull =>
            await instance.Next(inst => func(inst.Item1, inst.Item2, cancellationToken));

        public static async Task<U> Next<T1, T2, U>(this Task<(T1, T2)> instance,
                                                              Func<T1, T2, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) where T1 : notnull where T2 : notnull =>
            await (await instance).Next(func, cancellationToken);
    }
}
