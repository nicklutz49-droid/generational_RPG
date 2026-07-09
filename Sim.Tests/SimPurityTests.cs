using System;
using System.Linq;
using System.Reflection;

namespace Sim.Tests;

public class SimPurityTests
{
    [Fact]
    public void SimWorld_ReferencesNoGodotAssemblies()
    {
        AssertNoGodotReferences(typeof(Sim.World.AssemblyMarker).Assembly);
    }

    [Fact]
    public void SimTactics_ReferencesNoGodotAssemblies()
    {
        AssertNoGodotReferences(typeof(Sim.Tactics.AssemblyMarker).Assembly);
    }

    private static void AssertNoGodotReferences(Assembly assembly)
    {
        var godotReferences = assembly.GetReferencedAssemblies()
            .Where(referenced => referenced.Name is not null
                && referenced.Name.StartsWith("Godot", StringComparison.Ordinal))
            .Select(referenced => referenced.Name)
            .ToList();

        Assert.Empty(godotReferences);
    }
}
