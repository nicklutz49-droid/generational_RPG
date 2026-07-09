# ARCHITECTURE.md

## Pinned versions

| Component | Version | Status |
|---|---|---|
| Godot (.NET build) | **4.7-stable** (released 2026-06-18) | ✅ pinned (developer, 2026-07-09) |
| Godot.NET.Sdk (NuGet) | 4.7.0 | ✅ pinned |
| .NET target framework | `net8.0` (.NET 8 is the minimum since Godot 4.4; SDK 8.0+ required) | ✅ pinned |
| xUnit | 2.9.3 (+ xunit.runner.visualstudio 3.1.5, Microsoft.NET.Test.Sdk 18.7.0) | ✅ pinned (scaffold, 2026-07-09) |

Known limitation: `GenerationalRPG.sln` uses standard `Debug|Release` configurations, not the `Debug/ExportDebug/ExportRelease` scheme the Godot editor generates for its own solutions. `dotnet build`/`dotnet test` are unaffected (verified); the editor's Build button / `--export` flow is unvalidated — revisit if export tooling is ever driven from this solution.

API verification (`ORCHESTRATOR.md` §11) is against the Godot 4.7 docs: https://docs.godotengine.org/en/4.7/ — never against recalled signatures. If the developer later updates to a 4.7.x patch release, update this table; minor patches do not need an ADR, version jumps (4.8+) do.

## Assembly layout

Three assemblies. Dependencies point one way only.

```
Sim.World    pure C#, zero Godot references — world sim (post-M0: settlements, economy)
Sim.Tactics  pure C#, zero Godot references — grid combat, encounters, transition state
Game         Godot project — rendering, input, audio, scene tree. No rules.
```

- `Game` references `Sim.World` and `Sim.Tactics`. Nothing references `Game`.
- `using Godot;` in any `Sim.*` file is an automatic rejection, enforced by build check (to be added with the first solution scaffold; the check fails the build, it does not warn).
- All game rules live in `Sim.*` and are covered by headless xUnit tests. `Game` is presentation only.

## Determinism contract

- All sim/combat randomness flows from an injected, seeded RNG source. `new Random()`, `Guid.NewGuid()`-as-entropy, time-based seeds, and iteration over unordered collections in rule logic are all violations.
- Same seed + same input sequence = same output, on every platform, every run.
- Determinism-sensitive code (transition, combat resolution, economy tick, save/load) routes to Opus 4.8 per `ORCHESTRATOR.md` §4 and requires tests that replay a seed and assert exact outcomes.

## ADR log

Structural changes to any of the above require a dated ADR in `DECISIONS.md` first.
