# FEATURES.md

## Implemented

*(nothing yet)*

## Planned — M0 (one dungeon, combat only, no world map)

Ordered per the build-order constraint (`ORCHESTRATOR.md` §6): the snap-to-grid transition comes first.

1. Solution scaffold: `Sim.World`, `Sim.Tactics`, `Game` assemblies + Sim-purity build check + xUnit harness
2. Free-roam → grid snap-to-tactical transition (design ADR required first; Opus 4.8)
3. Grid-native dungeon geometry, collision, movement, pathfinding
4. One hand-authored dungeon
5. Free-roam exploration
6. Tactical combat with hardcoded fixed party
7. First enemy archetype (a second is out of scope until this one passes review)
8. Per-feature juice pass (gated per `ORCHESTRATOR.md` §10, not a phase)
