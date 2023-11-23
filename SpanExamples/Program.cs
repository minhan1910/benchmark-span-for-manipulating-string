

//var input = "INV-12313123213";
//var res = false;
//if (input.StartsWith("INV", StringComparison.Ordinal))
//{
//    res = true;
//}

//Console.WriteLine(res);

using BenchmarkDotNet.Running;
using SpanExamples;

BenchmarkRunner.Run<BenmarkTest>();