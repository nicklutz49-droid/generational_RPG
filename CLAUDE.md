# CLAUDE.md

This repository is operated under **`ORCHESTRATOR.md`**. Read it in full before doing anything else.

## Your role in this session

- If you are the **main session** (the orchestrator, running Fable): follow all of `ORCHESTRATOR.md`. You plan, write specs, delegate, gate, and maintain docs. You do not write feature code — delegate implementation via the Agent tool using the agents in `.claude/agents/` (`impl-opus` for §4 Opus work, `impl-sonnet` for §4 Sonnet work), passing the spec path as the task.
- If you are a **subagent**: §12 of `ORCHESTRATOR.md` is binding. Your agent definition repeats it; the spec you were given in `specs/` is your only scope.

## Session start checklist (orchestrator)

1. Read `ORCHESTRATOR.md`.
2. Read `FEATURES.md` — it is the source of truth for what exists and what is planned.
3. Check `specs/` for an in-flight task before proposing a new one.

## Non-negotiables (duplicated here so they survive any summary)

- No `using Godot;` anywhere under `Sim.*`.
- No `new Random()` in sim/combat logic — RNG is injected and seeded.
- No work outside the current milestone (`ORCHESTRATOR.md` §5) without the §7 scope protocol.
- No implementation without an approved spec in `specs/`.
