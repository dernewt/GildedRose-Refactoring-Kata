using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using GildedRoseKata;
using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata.Services;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Assembly.GetAssembly(typeof(GildedRose))
            .EntryPoint.Invoke(this, new[] { new[] { "30" } });

        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}