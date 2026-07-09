# DECISIONS.md

Dated ADRs, newest first. Every architectural choice, §2 change, developer override, and Sonnet→Opus escalation lands here with the alternatives that were rejected.

---

## ADR-0001 — Adopt the ORCHESTRATOR.md operating process (2026-07-09)

**Decision:** The repo is operated under `ORCHESTRATOR.md`: a Fable orchestrator that plans, specs, delegates, and gates; Opus 4.8 and Sonnet 5 subagents that implement from specs; four living docs (`ARCHITECTURE.md`, `FEATURES.md`, `BACKLOG.md`, `DECISIONS.md`) plus per-task specs in `specs/`.

**Also authorized by this ADR** (process infrastructure, not M0 docs, so §8's four-file limit is not violated):
- `CLAUDE.md` — entry point so the rules load automatically at session start
- `specs/` — one spec per task, deleted on merge
- `.claude/agents/impl-opus.md`, `.claude/agents/impl-sonnet.md` — subagent definitions implementing the §4 model routing, each embedding the §12 rules

**Rejected alternatives:**
- *Rules only in chat memory / user instructions* — doesn't survive new sessions; docs beat memory.
- *Single CONTRIBUTING.md for everything* — mixes durable facts, live state, and deferred ideas; each has a different update trigger, so they get separate files.
- *One generic subagent, model chosen ad hoc* — routing drifts; encoding it in agent definitions makes §4 the default path instead of a judgment call.

**Open items:** engine version unpinned in `ARCHITECTURE.md` (blocks first code commit); Sim-purity build check to be created with the solution scaffold.
