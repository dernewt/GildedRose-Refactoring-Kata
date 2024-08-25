using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using GildedRoseKata;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        Assembly.GetAssembly(typeof(GildedRose))
            .EntryPoint.Invoke(this, new[] { new[] { "30" } });

        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}