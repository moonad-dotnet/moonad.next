using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonad
{
    public static partial class NextExtensions
    {
        public static void Next<T1, T2, T3>(this (T1, T2, T3) instance, Action<T1, T2, T3> action) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            action(instance.Item1, instance.Item2, instance.Item3);

        public static async Task Next<T1, T2, T3>(this (T1, T2, T3) instance, Func<T1, T2, T3, Task> func) 
            where T1 : notnull where T2: notnull where T3 : notnull =>
            await func(instance.Item1, instance.Item2, instance.Item3);

        public static async Task Next<T1, T2, T3>(this Task<(T1, T2, T3)> instance, Action<T1, T2, T3> action) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            (await instance).Next(action);

        public static async Task Next<T1, T2, T3>(this Task<(T1, T2, T3)> instance, Func<T1, T2, T3, Task> func) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await (await instance).Next(func);

        public static async Task Next<T1, T2, T3>(this (T1, T2, T3) instance,
                                            Func<T1, T2, T3, CancellationToken, Task> func,
                                            CancellationToken cancellationToken = default) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await func(instance.Item1, instance.Item2, instance.Item3, cancellationToken);

        public static async Task Next<T1, T2, T3>(this Task<(T1, T2, T3)> instance,
                                                   Func<T1, T2, T3, CancellationToken, Task> func,
                                                   CancellationToken cancellationToken = default) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await (await instance).Next(func, cancellationToken);

        public static U Next<T1, T2, T3, U>(this (T1, T2, T3) instance, Func<T1, T2, T3, U> func) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            func(instance.Item1, instance.Item2, instance.Item3);

        public static async Task<U> Next<T1, T2, T3, U>(this (T1, T2, T3) instance, Func<T1, T2, T3, Task<U>> func) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await func(instance.Item1, instance.Item2, instance.Item3);

        public static async Task<U> Next<T1, T2, T3, U>(this Task<(T1, T2, T3)> instance, Func<T1, T2, T3, U> func) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            (await instance).Next(func);

        public static async Task<U> Next<T1, T2, T3, U>(this Task<(T1, T2, T3)> instance, Func<T1, T2, T3, Task<U>> func) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await (await instance).Next(func);

        public static async Task<U> Next<T1, T2, T3, U>(this (T1, T2, T3) instance,
                                                              Func<T1, T2, T3, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await instance.Next(inst => func(inst.Item1, inst.Item2, inst.Item3, cancellationToken));

        public static async Task<U> Next<T1, T2, T3, U>(this Task<(T1, T2, T3)> instance,
                                                              Func<T1, T2, T3, CancellationToken, Task<U>> func,
                                                              CancellationToken cancellationToken = default) 
            where T1 : notnull where T2 : notnull where T3 : notnull =>
            await (await instance).Next(func, cancellationToken);
    }
}
