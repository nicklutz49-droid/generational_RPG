# specs/

One spec per task, written by the orchestrator (`ORCHESTRATOR.md` §9), deleted on merge. An empty directory (this README aside) means no task is in flight.

Every spec uses this template:

```markdown
# Spec: <task name>

Routing: Opus 4.8 | Sonnet 5      (per ORCHESTRATOR.md §4)
Approved by developer: <date>

## Goal
One paragraph. What exists when this is done.

## Interface
Exact signatures/types this task must implement or consume. Interfaces
originate here — the subagent must not invent any (§11).

## Required tests
Named tests that must exist and pass, including at least one that fails
if the logic breaks. Determinism-sensitive work: a seed-replay test
asserting exact outcomes.

## Files allowed
Explicit list. Touching anything else = stop and report back (§12).

## Files forbidden
Anything easy to reach for that is out of bounds for this task.

## Out of scope
Adjacent work the subagent must not do, even if convenient.
```
