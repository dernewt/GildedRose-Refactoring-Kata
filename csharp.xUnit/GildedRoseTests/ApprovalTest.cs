using System.Text;
using System.Reflection;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        int daysToRun = 30;

        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        var capturedOutput = new StringBuilder();
        Console.SetOut(new StringWriter(capturedOutput));

        object[] daysToRunArgs = [new[] { daysToRun.ToString() }];
        Assembly.GetAssembly(typeof(GildedRose))?.EntryPoint
            ?.Invoke(this, daysToRunArgs);

        return Verify(capturedOutput);
    }

    [Fact]
    public Task NoDaysPassed()
    {
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        var capturedOutput = new StringBuilder();
        Console.SetOut(new StringWriter(capturedOutput));

        object[] emptyArgs = [Array.Empty<string>()];
        Assembly.GetAssembly(typeof(GildedRose))?.EntryPoint
            ?.Invoke(this, emptyArgs);

        return Verify(capturedOutput);
    }
}