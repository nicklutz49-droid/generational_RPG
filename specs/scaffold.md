# Spec: Solution scaffold

Routing: Sonnet 5      (per ORCHESTRATOR.md §4: scene/solution assembly against a settled structure)
Approved by developer: 2026-07-09

## Goal

A buildable, testable skeleton of the project matching `ARCHITECTURE.md`: three assemblies (`Sim.World`, `Sim.Tactics` — pure C#; `Game` — Godot), a headless xUnit test project, an enforced Sim-purity build check, and a CI workflow. No gameplay code, no gameplay interfaces. When done, `dotnet build` and `dotnet test` succeed from a clean checkout with no Godot editor installed.

## Pinned versions (from ARCHITECTURE.md — do not deviate)

- Godot 4.7-stable; `Game` uses the `Godot.NET.Sdk/4.7.0` MSBuild SDK from NuGet
- All projects target `net8.0`
- xUnit: latest stable 2.x at time of implementation; report the exact version in your summary so the orchestrator can record it in `ARCHITECTURE.md`

## Deliverables

1. `GenerationalRPG.sln` at repo root referencing all four projects.
2. `Sim.World/Sim.World.csproj` — plain `net8.0` class library. No package references. One placeholder type only (e.g., `namespace Sim.World; public static class AssemblyMarker {}`) — invent nothing else.
3. `Sim.Tactics/Sim.Tactics.csproj` — same as above, `namespace Sim.Tactics`.
4. `Game/Game.csproj` — `Godot.NET.Sdk/4.7.0` SDK project referencing `Sim.World` and `Sim.Tactics`. `Game/project.godot` — minimal Godot 4.7 project file with the .NET/C# configuration (assembly name `Game`). No scenes or scripts required beyond what an empty Godot .NET project needs to open cleanly in the 4.7 editor.
5. `Sim.Tests/Sim.Tests.csproj` — xUnit project referencing `Sim.World` and `Sim.Tactics` (never `Game`), runnable headless via `dotnet test`.
6. **Sim-purity build check**: an MSBuild mechanism (e.g., `Directory.Build.targets` scoped to `Sim.*` projects) that fails the **build** — error, not warning — if (a) any `.cs` file compiled into a `Sim.*` assembly contains `using Godot` or `Godot.`-qualified references, or (b) a `Sim.*` project acquires a reference to GodotSharp or the Godot.NET.Sdk. Keep the mechanism in MSBuild so it runs on every build everywhere, not only in CI.
7. `.github/workflows/ci.yml` — on push/PR: setup .NET 8 SDK, `dotnet build` the solution (warnings as errors), `dotnet test`.
8. Root `.gitignore` (Godot 4 + .NET), root `.editorconfig` (default C# conventions; treat warnings as errors via `Directory.Build.props`).

## Required tests (in Sim.Tests)

- `SimPurityTests.SimWorld_ReferencesNoGodotAssemblies` — via reflection, assert `Sim.World`'s referenced assemblies contain nothing matching `Godot*`.
- `SimPurityTests.SimTactics_ReferencesNoGodotAssemblies` — same for `Sim.Tactics`.
- One smoke test per Sim assembly proving the test project loads and executes against it.

These must pass via `dotnet test` with no Godot editor present, and the purity tests must genuinely fail if a Godot reference were introduced.

## Files allowed

- `GenerationalRPG.sln`, `Directory.Build.props`, `Directory.Build.targets`, `.gitignore`, `.editorconfig`
- `Sim.World/**`, `Sim.Tactics/**`, `Sim.Tests/**`, `Game/**`
- `.github/workflows/ci.yml`

## Files forbidden

- `ORCHESTRATOR.md`, `CLAUDE.md`, `ARCHITECTURE.md`, `FEATURES.md`, `BACKLOG.md`, `DECISIONS.md` (the orchestrator updates docs at the gate)
- `specs/**` (read-only for you), `.claude/**`, `README.md`

## Out of scope — do not do these even if convenient

- Any gameplay types, interfaces, or RNG abstractions. The RNG seam and any shared `Sim` interfaces are a future ADR — do NOT invent an `IRng`, a `Sim.Core` project, or similar.
- Scenes, sprites, input maps, or audio in `Game` beyond the empty-project minimum.
- Save/load, serialization, config systems.
- Additional test frameworks, analyzers, or NuGet packages beyond xUnit + its runner.

## Verification before reporting done

Install the .NET 8 SDK in your environment if absent. Run `dotnet build` (must be clean — zero warnings) and `dotnet test` (all green) from the repo root. Then prove the purity check works: temporarily add `using Godot;` to a `Sim.World` file, confirm the build FAILS with your custom error, revert it, and state in your report that you performed this negative test. Report the exact xUnit version used.
