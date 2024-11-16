# Moonad.Next

A simple F#'s pipe-forward operator port for C#. This lib is part of the [Moonad](https://moonad.net) project.

![Version](https://img.shields.io/nuget/v/moonad.next?label=version&color=029632) ![Tests](https://img.shields.io/github/actions/workflow/status/moonad-dotnet/moonad.next/tests.yml?logo=github&label=tests&color=029632) ![Nuget](https://img.shields.io/nuget/dt/moonad.next?logo=nuget&label=downloads&color=029632)

## Installing
The project's package can be found on [Nuget](https://nuget.org/packages/moonad.next) and installed by your IDE or shell as following:

```shell
dotnet add package Moonad.Next
```

or

```shell
PM> Install-Package Moonad.Next
```

### Pipe-forward

The pipe-forward operator offers a way to chain methods passing the result of the prior to the next as the first parameter.

Example 1 - Sync:
```c#
10.Next(i => i + 10)
  .Next(i => $"Total: {i}")
  .Next(s => Console.WriteLine(s)); //"Total: 20"
```

Example 2 - Async:
```c#
10.Next(i => i * 10)
  .Next(async i => await Task.FromResult($"Total: {i}"))
  .Next(s => Console.WriteLine(s)); //"Total: 100"
```

Example 3 - Tuple<T1, T2>:
```c#
(8, 2).Next((x, y) => x * y)
      .Next((i) => $"Sum result: {i}"); //16
```

Example 4 - Tuple<T1, T2, T3>:
```c#
(1, 3, 5).Next((x, y, z) => (x + y, z))
         .Next((x, y) => x * y)
         .Next(x => Math.Pow(x, 2)); //400
```