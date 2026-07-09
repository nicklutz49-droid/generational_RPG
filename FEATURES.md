# FEATURES.md

## Implemented

- Solution scaffold (2026-07-09): `GenerationalRPG.sln` with `Sim.World`, `Sim.Tactics` (pure net8.0), `Game` (Godot.NET.Sdk 4.7.0), `Sim.Tests` (xUnit, headless); MSBuild Sim-purity check failing the build on any Godot reference under `Sim.*` (SIMPURITY001/002, negative-tested); CI workflow (build -warnaserror + test)

## Planned — M0 (one dungeon, combat only, no world map)

Ordered per the build-order constraint (`ORCHESTRATOR.md` §6): the snap-to-grid transition comes first.

1. Free-roam → grid snap-to-tactical transition (design ADR required first; Opus 4.8)
2. Grid-native dungeon geometry, collision, movement, pathfinding
3. One hand-authored dungeon
4. Free-roam exploration
5. Turn-based tactical combat with hardcoded fixed party (engine models basic actions + 4 equipped ability slots, data-driven ability definitions — ADR-0002; 0 HP = knockout with bleed-out-to-death rule — ADR-0003)
6. First enemy archetype (a second is out of scope until this one passes review)
7. Per-feature juice pass (gated per `ORCHESTRATOR.md` §10, not a phase)
