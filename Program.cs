using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using System;

[MemoryDiagnoser]
public class SwitchBenchmark
{
    [Benchmark]
    public string RunSwitchExpressions()
    {
        string result = "";
        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            int number = random.Next(0, 101);
            result = number switch
            {
                >= 0 and < 10 => "Between 0 and 10 (exclusive)",
                >= 10 and < 20 => "Between 10 and 20 (exclusive)",
                >= 20 and < 30 => "Between 20 and 30 (exclusive)",
                >= 30 and < 40 => "Between 30 and 40 (exclusive)",
                >= 40 and < 50 => "Between 40 and 50 (exclusive)",
                >= 50 and < 60 => "Between 50 and 60 (exclusive)",
                _ => "Other cases"
            };
        }
        return result;
    }

    [Benchmark]
    public string RunSwitchExpressions2()
    {

        string result2 = "";
        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            int number2 = random.Next(0, 101);

            result2 = number2 switch
            {
                _ when (number2 >= 0 && number2 < 10) => "Between 0 and 10 (exclusive)",
                _ when (number2 >= 10 && number2 < 20) => "Between 10 and 20 (exclusive)",
                _ when (number2 >= 20 && number2 < 30) => "Between 20 and 30 (exclusive)",
                _ when (number2 >= 30 && number2 < 40) => "Between 30 and 40 (exclusive)",
                _ when (number2 >= 40 && number2 < 50) => "Between 40 and 50 (exclusive)",
                _ when (number2 >= 50 && number2 < 60) => "Between 50 and 60 (exclusive)",
                _ => "Other cases"
            };

        }
        return result2;
    }
    static void Main()
    {
        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddDiagnoser(MemoryDiagnoser.Default);
        _ = BenchmarkRunner.Run<SwitchBenchmark>(config);
    }
}
