namespace Sim.Tests;

public class SmokeTests
{
    [Fact]
    public void SimWorld_AssemblyLoadsAndTypeIsAccessible()
    {
        var type = typeof(Sim.World.AssemblyMarker);

        Assert.Equal("Sim.World", type.Namespace);
        Assert.Equal(nameof(Sim.World.AssemblyMarker), type.Name);
    }

    [Fact]
    public void SimTactics_AssemblyLoadsAndTypeIsAccessible()
    {
        var type = typeof(Sim.Tactics.AssemblyMarker);

        Assert.Equal("Sim.Tactics", type.Namespace);
        Assert.Equal(nameof(Sim.Tactics.AssemblyMarker), type.Name);
    }
}
