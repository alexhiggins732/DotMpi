# DotMpi

![Nuget](https://img.shields.io/nuget/v/HigginsSoft.DotMpi.svg?style=flat-square) ![Release Tests](https://github.com/alexhiggins732/DotMpi/actions/workflows/release.yml/badge.svg) ![Pre-Release Tests](https://github.com/alexhiggins732/DotMpi/actions/workflows/pre-release.yml/badge.svg)

# Installation

DotMpi is available as [nuget package](https://www.nuget.org/packages/HigginsSoft.DotMpi/) can be installed using nuget:
- Visual Studio Package Manager
 - `Install-Package HigginsSoft.DotMpi` 
- DotNet CLI
 - `dotnet add package HigginsSoft.DotMpi` 
-  PackageReference
 - `<PackageReference Include="HigginsSoft.DotMpi" />` 

Instructions for other package managers are availabe on the nuget package page.

# Introduction

DotMpi is a DotNet library that aims to bring multiprocessor functionality inspired by Open MPI to the DotNet world. It was developed as a solution to the limitations of DotNet's built-in `Parallel.For` function, which often leads to a lack of performance due to thread starvation.

DotMpi enables control over which CPU processors to use, leading to increased performance. It was developed during the creation of a new C# math library for working with multiple precision integers, factoring numbers, and other number theory functions. The need for parallelization led to the development of DotMpi.

Using DotMpi, the library can now sieve numbers up to 2^31 in just half a second, which is nearly three times faster than wall time using bbuhrow's Yafu, which is implemented in c and uses highly tuned assembly. Yafu isn't likely using multiple cores for prime sieving, but it is still nice to see a DotNet implementation that runs faster.

DotMpi also opens up possibilities for proper stress testing, load testing, and concurrency testing in DotNet, as well as easily clustering workloads across network infrastructure.


## Usage

To use DotMpi, simply reference the DotMpi namespace in your code and use the available functions.

For convenience, the syntax of the existing `Parallel.For` is available as part of a fluent API.

``` csharp
var runner = Mpi
    .ParallelFor(0, numThreads, target, i => new(i, "Hello World"))
    .Run()
    .Wait();
```

Like the built in `System.Threading.Tasks.Parallel.For` the first to arguments represent the start and end index inclusive.

The third and for paramters are exclusive to `DotMpi`. The 3rd parameter, `target`, is the target function you wish to execute.

The the fourth paramter is a function to supply arguments to your `target` function.

The `Wait()` function will block until all processes have completed. If you do not want to block
instead of calling `Wait()` just call `Run()` and monitor execution with the methods available. 

A current limitation is you can only call `static` methods only as other processes will not have access to instance data
of the process launching the processor threads.

The Api requires the static method to be cast to a `Func<>` to enforce strong typing of arguments in the method for serialization
of arguments and data between processes.

Additionally, arguments and returned data must be serializable as the libary uses IPC on named pipes, which requires binary serialization
of data to pass information back and forth.

You can however pass any arguments need to the method that will be invoked and your method can return any state data you need.


### What's new

What's new:

 - Events can now be used to access multi-processor function call data before they are executed and to receive real-time access to the return results before waiting for all function calls to complete.
 - Results are now stored in a Dictionary<int, TResult> to allow consumers to access results based on the start and end indices to the function runner instead of needing to manually map a zero-based index to the call parameters.
 - Unit tests now offer complete coverage of the public DotMpi api.
 - Build pipeline has been updated to produce pre-release alpha NuGet packages from the develop branch and pre-release beta release candidate NuGet packages from the release branch.
 - Error logging can be enabled using `WithLogging` using the Fluent Api. This sets the `EnableLogging` property on the `FunctionRunner` and also enables file-based logging for each process.
 - An unmanaged library type loader has been added to handle methods that have libraries in the `/runtime/<target-platform>` instead of the root application directory.

### How to use

#### Hello World

``` csharp
public static string MpiHelloWorld(int threadIndex, string message)
{
    var p = Process.GetCurrentProcess();
    int cpuNumber = 0;
    for (var cpuMask = ((int)p.ProcessorAffinity); cpuMask > 1; cpuNumber++, cpuMask >>= 1) ;
    return @$"{message} from thread {threadIndex} on process {p} on cpu {cpuNumber}";
}
  
public static void HelloWorldTest(int numThreads)
{
    Func<int, string, string> target = MpiHelloWorld;
    var timer = Stopwatch.StartNew();
    var runner = Mpi
        .ParallelFor(0, numThreads, target, i => new(i, "Hello World"))
        .Run()
        .Wait();

    for (var i = 0; i < numThreads; i++)
    {
        var result = runner.Results[i];
        Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
    }

    Console.WriteLine($"[{DateTime.Now}] Completed {numThreads} process threads in {timer.Elapsed}");
    timer.Stop();
}

```

Under the hood of the `ParralelFor` fluent api call. 

`Mpi.Parallel(numThreads)` and `Mpi.Parallel(start,end)` return a `ParallelMethodBuilder`.


``` csharp

var builder = Mpi.Parallel(numThreads);

```

The builder can then be used to register a target function to execute.

``` csharp

var parallelMethod = builder.For(target);

```

Again, target needs to a `Func<>` that points to a static method you wish to execute.

You can pass the arguments to parallelMethod either statically or using an argument provider delegate.

``` csharp

var parallelMethod = parallelMethod.WithArgs(arg0, arg1, arg2, ...);

```

These arguments need to match the type can count of the arguments in the target `Func<>`

For example. `static string Method()` would be a `Func<string>` and take no arguments, while `static string Method(int a)` would be a 
a `Func<int, string>`

In addition to providing static arguments, you can pass a delegate that will provide unique arguments to each process thread.

``` csharp

var parallelMethod = parallelMethod.WithArgs(i => new(arg1, arg2, arg3));

```

The argument provider delegate is definted as `Func<int, ArgList<T0, ..., TN>` which will match the type parameters in your target method.

For convience the new constructor `i => new(arg1, arg2, arg3)` provides simple way to define the function. You can also call another function
to provide arguments.

For exmaple:
``` csharp

public static HelloWorld(int threadIndex, string message)
 => $"Hello World from thread {threadIndex}";

public static string GetCustomArgs(int threadIndex)
        => threadIndex % 5 == 0 ? "Hello World" : "Good Bye World";
public static void HelloWorldTest(int numThreads)
{

    Func<int, string, string> target = HelloWorld;
    var runner = Mpi
        .ParallelFor(0, numThreads, target, i => GetCustomArgs);
        .Run()
        .Wait();

    for (var i = 0; i < numThreads; i++)
    {
        var result = runner.Results[i];
        Console.WriteLine($"[{DateTime.Now}] Result {i}: {result}");
    }
}

``` 

The unlike the target, the argument provider does not have to be static. For example, you can do:

``` csharp
public class CustomArgProvider
{
    public string GetCustomArgs(int threadIndex)
        => threadIndex % 5 == 0 ? "Hello World" : "Good Bye World";
}

var provider = new CustomArgProvider();
Func<int, string, string> target = HelloWorld;
var runner = Mpi
    .ParallelFor(0, numThreads, target, i => CustomArgProvider.GetCustomArgs);
    .Run()
    .Wait();

``` 

### Events

While the `Run()` and `Wait()` methods return a function runner that you can use to access the results of each process in an array you can
also use an event handler to subscribe to method results and method invocation data.

The events provides result and meta data about the process and arguments provided.

To access the events api, you must call `Build()` seperately first. The `Run()` method internally calls build and calls the the parallel
function runner's run method.

``` csharp
Func<int, string, string> target = HelloWorld;

var runner = Mpi
    .ParallelFor(0, numThreads, target, i => CustomArgProvider.GetCustomArgs);
    .Build();

runner.FunctionInvoked += (sender, e) =>
        {
            //the thread index
            var thread = e.ThreadIndex;

            // the args provider use to send args to the function
            var args = e.ArgProvider.ToArray().Select(i => (int)i);
            
            /// the processId the function ran on
            var processId= e.ProcessId;

            // the pipe name used for the process that ran the function.
            var pipeName = e.PipeName;

            // the serialized function call data sent.
            var functionData = e.FunctionCallData;
        }

runner.FunctionResultReturned += (sender, e) =>
        {
            //the thread index
            var thread = e.ThreadIndex;

            // the result
            var result = e.Result;

            // the args provider use to send args to the function
            var args = e.ArgProvider.ToArray().Select(i => (int)i);
            
            /// the processId the function ran on
            var processId= e.ProcessId;

            // the pipe name used for the process that ran the function.
            var pipeName = e.PipeName;

        }

runner.Run();
``` 

If you want to capture them for later use, you can save them to an array based on the thread index.

If you only want access to the results of each function, use the `.Results` array from the function runner.

``` csharp


Func<int, string, string> target = HelloWorld;

var invoked = new FunctionInvokedEventArgs<string>[numThreads];
var returned = new FunctionResultEventArgs<string>[numThreads];

func.FunctionInvoked += (sender, e) => invoked[e.ThreadIndex] = e;
func.FunctionResultReturned += (sender, e) => => returned[e.ThreadIndex] = e;
``` 


## Roadmap

Detail the following:
1. - [ ]   Introduction
	   - [ ]  Brief overview of the project
2.   - [ ] Motivation
		- [ ]   Discuss why DotMpi was created and the problem it solves
3.  - [ ]  Features
	    - [ ]   List of features DotMpi provides
4.   - [ ] Usage
		- [ ]   Quickstart guide to using DotMpi in your own project
		- [ ]   In-depth explanation of each feature and how to use it
5.   - [ ] Future plans
6.   - [ ] Performance
		- [ ]   Discussion on the performance benefits of DotMpi
		- [ ]  Benchmarking data
7.  - [ ]  Contributing
		- [ ]   Guidelines for contributing to DotMpi
8.   - [ ] License
		- [ ]   Information about the project's license

## Checklist

 - [ ] Introduction
     - [ ] Title
     - [ ] Brief overview of the project
 - [ ] Motivation
     - [ ] Explanation of why DotMpi was created and the problem it solves
 - [ ] Features
     - [ ]  List of features DotMpi provides
 - [ ]  Usage
    - [ ] Quickstart guide
         - [ ]  Installation
         - [ ]  Setting up a project
         - [ ] Basic usage example
    - [ ] In-depth explanation of each feature and how to use it
 - [ ] Future plans
	 - [ ] Authentication
	 - [ ] Remote connections
		 - [ ] Agent installe
	 - [ ] Custom serializers
	 - [ ] Event Api
     - [ ] Code Cleanup / Refactoring
     - [ ] Unit Tests
     - [ ] Docs
     - [ ] Wiki
     - [ ] Nuget Package
 - [ ] Performance
     - [ ] Discussion on the performance benefits of DotMpi
    - [ ] Benchmarking data
 - [ ] Contributing
     - [ ] Guidelines for contributing to DotMpi
 - [ ] License
     - [ ]   Information about the project's license



## Contributing

If you are interested in contributing to DotMpi, please submit a pull request with your changes and a description of the changes made.

## License

HigginsSoft.DotMpi is licensed under the [GNU General Public License v3.0](COPYING). See the [LICENSE](LICENSE) file for details about using and redistributing this software.

## Acknowledgments

Special thanks to the creators of [Open MPI](https://www.open-mpi.org/doc/v1.8/man1/mpirun.1.php) and [bbuhrow's Yafu](https://github.com/bbuhrow/yafu) for inspiring and guiding the development of DotMpi.