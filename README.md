# WildfrostReptileFaction
A faction focusing on effects when snowed and longshot.
<!-- Design notes in these comments.
Keep in mind this is all theory. No testing yet. -->
<!-- Self-snow is an active tradeoff.
Compared to sacrifice, it should be less linear. -->
<!-- Longshot is fairly incompatible with normal units.
Focusing damage is too important if you don't have the damage output.
Damage is relatively higher to offset? Still hard at low concentrations.
Also allows for a few "fun" gimmicks. -->

(Alternatively, Coldblooded Faction. TODO: decide. internal name is fine.)

## Units

### Gates
Has smackback and scales quickly, at the cost of card turns and opportunities.
<!-- Should be a defensive scaling unit. Limited by health though.
Smackback allows for opportunity cost. Skip some smackback for damage later.
Sometimes the cost is 0 if counters align (aside from taking a card turn).
Snowcake + recall is viable if small deck. -->

<!-- Trigger on hit is also an option. Can hit with junk or something. Too aggressive.
Teeth still hits if snowed, causing 0 opportunity cost which is bad. -->

### Reggie
After a slow start, hits hard when active.
<!-- Very easy to activate offense, and scales ok. Lets you spend your turns defensively. -->
<!-- (Hopefully obvious Pokemon reference.) -->

### Scorpy
"Get over here!" Deals good damage, but makes it hard to focus hits.
<!-- Kind of an unserious pick. By design.
Genuinely good if the fight is small.
Knockback trait exists, but not in the base game. Also this is funnier. -->
<!-- (Not a huge fan of MK. It's entered pop culture.) -->

### Colbo
Frail, but rapidly attacks the backline while taking bling. 
<!-- Almost certain there's a guaranteed bling infinite.
There's one in base game but its luck to set up.
May change to apply status. -->

# Development

## First Time Setup
1. Create profile in r2modman.
2. Download BepInEx and Wildfrost_API
3. Setup plugin directory.
4. Change all paths in Makefile. (TODO: Make more ergonomic.)
5. Run `make copy-lib-from-bepinex` and `make copy-lib-from-miya`
6. Run `make`.