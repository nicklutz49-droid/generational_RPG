# ARCHITECTURE.md

## Pinned versions

| Component | Version | Status |
|---|---|---|
| Godot (.NET build) | **TBD — developer must pin before the first code commit** | ⚠ unpinned |
| .NET SDK | TBD (whatever the pinned Godot version requires) | ⚠ unpinned |
| xUnit | TBD (pin on first test project) | ⚠ unpinned |

No code may be committed while the engine version is unpinned (`ORCHESTRATOR.md` §11 depends on it: API calls are verified against the pinned version's docs, not recall).

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
