# DECISIONS.md

Dated ADRs, newest first. Every architectural choice, §2 change, developer override, and Sonnet→Opus escalation lands here with the alternatives that were rejected.

---

## ADR-0002 — Game pillars recorded as fixed facts; 4-slot ability loadout modeled from M0 (2026-07-09)

**Context:** The developer stated the game vision in full (verbatim capture in `BACKLOG.md` B-001…B-012). Most of it is post-M0 content, but three things are identity-level facts and one is an M0 engine constraint.

**Decision 1 — §2 amendments (developer-stated, recorded here per §2's ADR requirement):**
- Guild pillar: the player is a single character leading a failing guild; the core loop is restoring and sustaining it (hiring, equipping, leveling members, wages, travel supplies). The player character can fight but never has to.
- Generational pillar: every character, including the player's, ages and dies; play continues through a designated heir who inherits the guild with passive leveling bonuses tied to the late leader's strengths.
- Goods movement is simulated backend-only; map NPCs visualize activity but are not the transport mechanism.

**Decision 2 — combat engine models the ability loadout from M0:** beyond basic actions (attack, use item, move), a character has exactly 4 equipped ability slots. Loadouts are immutable inside a dungeon or combat. M0's hardcoded party ships with hardcoded loadouts, but the engine's action interface distinguishes basic actions from equipped abilities from the first commit, and ability definitions are data-driven (files loaded by `Sim.Tactics`), not per-class code.

**Rejected alternatives:**
- *Keep the vision in conversation memory only* — doesn't survive sessions; docs beat memory.
- *A fifth "VISION.md" doc* — §8's four-file limit; identity facts belong in §2, deferred features in `BACKLOG.md`.
- *Retrofit the 4-slot loadout after M0* — the loadout shape defines the combat action interface; retrofitting it means reworking every ability and its tests. Modeling it now costs ~0 extra.

**Open items (need developer answers before their systems are specced):** time model (game-days per real minute; does time pass in dungeons); heir-less death handling; whether classes are switchable/multiclassable; generational bonus compounding.

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
