# BACKLOG.md

Deferred ideas. Developer's original wording is preserved verbatim; the orchestrator adds the cost estimate. Entries are appended at deferral time (`ORCHESTRATOR.md` §7), before any further discussion. Costs are pessimistic dev-days and assume the M0 foundation (grid combat, transition, determinism harness) already exists.

---

## B-001 — Living economy (production, consumption, pricing, backend trade)

- **Deferred:** 2026-07-09
- **Developer's wording:** "the world reacts organically to supply and demand of goods" … "The economy will run on common goods like different kinds of food, clothing, raw goods like iron, wood, copper, etc., but also have more luxury goods that affect quality of life and happiness of settlements. Each good gets consumed at a rate proportional to the settlements population, standard of living, and average price of the good. Settlements will produce goods based on the local resources in the area and the workshops they have. They then trade the goods to buy other they dont have from nearby. This will all be simulated and the movement of goods will happen slowly and carefully but can just happen on the back end and doesn't need physicalized NPCs on the world map to move them"
- **Cost (pessimistic):** 20–30 dev-days
- **Notes:** Opus 4.8 work (§4: economy tick, determinism). The price↔consumption feedback loop needs convergence tests — closed economic loops oscillate or run away unless damped; seeded-replay tests must assert stability over long horizons. Backend-only goods movement confirmed as a §2 fact (ADR-0002).

## B-002 — Map NPCs visualizing settlement activity

- **Deferred:** 2026-07-09
- **Developer's wording:** "though their will be NPCs on the map that are moving between settlements to show to the player that something is happening"
- **Cost (pessimistic):** 4–6 dev-days
- **Notes:** Pure presentation (`Game` assembly) reading economy state; depends on B-001. Already a §2 fact.

## B-003 — Technology/magic advancement driven by goods distribution and threats

- **Deferred:** 2026-07-09
- **Developer's wording:** "the advancement of technology or magic which is based on distribution of certain goods/items or threats"
- **Cost (pessimistic):** 10–15 dev-days
- **Notes:** Needs a design pass before costing firms up: what concretely advances (recipes? workshop tiers? available abilities?), per-settlement vs. global, and whether "threats" means dungeon proximity or something else. Depends on B-001.

## B-004 — Guild management (failing guild, hiring, wages, travel supplies)

- **Deferred:** 2026-07-09
- **Developer's wording:** "The player is a single character who takes on the leadership of a failing guild and must restore it and keep it afloat." … "They hire characters and can equip them and level them up in what ever class they want. The player has to take into account supplies when traveling and money costs for employed guild members."
- **Cost (pessimistic):** 12–18 dev-days
- **Notes:** Promoted to a §2 game pillar (ADR-0002). Supersets the existing §2 roster/reserve fact. Wage upkeep + travel supplies are the money sinks that make quest income and trading meaningful — should land in the same milestone as the first income sources.

## B-005 — Player character as optional combatant

- **Deferred:** 2026-07-09
- **Developer's wording:** "The player character is capable of taking part in combat but doesnt need to."
- **Cost (pessimistic):** 2–4 dev-days
- **Notes:** Cheap once deployment/roster exists (B-004): the leader is just a deployable unit that may be benched. Implies the deployed party of 6–8 does not require the leader.

## B-006 — Class system (large variety, level any class)

- **Deferred:** 2026-07-09
- **Developer's wording:** "There will be a large variety of classes to allow for creativity and experimentation."
- **Cost (pessimistic):** 15–25 dev-days for the framework; each class after that is content, ~1–2 days apiece
- **Notes:** "Large variety" is a content multiplier — classes and abilities must be data definitions loaded by `Sim.Tactics`, never per-class code. The M0 combat engine spec will require data-driven ability definitions from the start so this stays content work. Design settled by ADR-0003: 1 class per character, switchable, with a progression tree of classes that unlock as prerequisites are leveled — the tree structure (prereq graph) should be part of the class data format from day one.

## B-007 — World-map ability loadout swapping (UI)

- **Deferred:** 2026-07-09
- **Developer's wording:** "can change them out on the world map at anytime"
- **Cost (pessimistic):** 2–3 dev-days
- **Notes:** The 4-slot loadout + dungeon lock itself is **not** deferred — it's modeled in the M0 combat engine (ADR-0002). Only the world-map swap UI waits for the world map to exist.

## B-008 — Character aging and death

- **Deferred:** 2026-07-09
- **Developer's wording:** "Each character will have an age and can grow old and die eventually."
- **Cost (pessimistic):** 5–8 dev-days
- **Notes:** Time-model direction set by ADR-0003: ~300 in-game years ≈ ~50 real hours; time passes mainly during travel and deliberate waiting in town (which also wears off injuries/exhaustion). Dungeon time is effectively paused (ADR-0004) — the clock only advances on the world map. §5 already directs stubbing age as a data field in M0.

## B-009 — Inheritance / heir system

- **Deferred:** 2026-07-09
- **Developer's wording:** "The player's initial character will eventually die in a playthrough, whether through age or combat and there will be an inheritance system to allow them to keep playing. The player can choose a member of the guild to inherit the guild. This heir gains passive bonuses to leveling skills the current owner of the guild is good with."
- **Cost (pessimistic):** 8–12 dev-days
- **Notes:** Promoted to a §2 pillar (ADR-0002) — it's the game's namesake. Design settled by ADR-0003: there is always an heir (defaulted, changeable anytime); game over only on total loss (e.g., full deployed party wiped in a dungeon); dynasties getting objectively stronger across generations is intended — compounding bonuses are a tuning problem, not a design flaw.

## B-010 — Leveled encounters + non-linear lifetime leveling

- **Deferred:** 2026-07-09
- **Developer's wording:** "Battles are leveled and the player may not be high enough level to fight certain threats. Leveling up isnt linear and getting to the highest levels can take an entire character's life."
- **Cost (pessimistic):** 6–10 dev-days (design-heavy, code-light)
- **Notes:** The XP curve is entangled with lifespan (B-008) and inheritance bonuses (B-009) — the three must be tuned as one system. M0 stubs a flat level field.

## B-011 — Quest system (trade missions → dungeon clears), player trading, freeroam discovery

- **Deferred:** 2026-07-09
- **Developer's wording:** "taking on quests that range from safer trade missions to more dangerous dungeon clearing, or they can do trading themselves and hope that they can find profitable trades, or they can even freeroam and look for dungeons themselves"
- **Cost (pessimistic):** 15–25 dev-days
- **Notes:** Player-driven trading falls out of B-001 nearly free (buy low, travel, sell high against real sim prices) — a good early milestone reward. Quest generation reading economy state (escort a real shortage, clear a real threat) is what makes the world feel alive; a separate design pass when scheduled.

## B-012 — Dungeon archetype variety (caves, forts, labyrinths, automaton factories, pocket dimensions)

- **Deferred:** 2026-07-09
- **Developer's wording:** "Dungeons can range from small caves, abandoned forts, deep labyrinths, huge automaton factories or pocket dimensions of extraplanar creatures like demons, devils, angels, abominations, or even eldritch horrors."
- **Cost (pessimistic):** 3–8 dev-days per archetype (tileset, hand-authored layouts, enemy roster, one gimmick each)
- **Notes:** §5 bans procgen and M0 proves exactly one hand-authored dungeon first. Ordering suggestion when scheduled: cheapest-to-read archetypes first (cave, fort), exotic ones (pocket dimensions) after the dungeon toolchain is proven.

## B-013 — Revival services (temple, mage casting, revival window)

- **Deferred:** 2026-07-09
- **Developer's wording:** "death is permanent but characters have a limited window of time be revived using a large city's temple services for a cost or a sufficiently highly leveled mage with the right spell and the right material that gets consumed."
- **Cost (pessimistic):** 5–8 dev-days
- **Notes:** The in-combat half of this rule (0 HP = knocked out; death if not healed up before combat drags on too long) is **not** deferred — it's an M0 combat-engine rule per ADR-0003. This entry covers only the post-combat services: the revival time window, temple pricing, the revival spell + consumed material, and how a dead character travels with the party during the window. Ties into the economy (temple costs, rare materials) and the class system (which classes get the spell).
