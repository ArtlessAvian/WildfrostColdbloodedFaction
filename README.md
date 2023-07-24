# WildfrostReptileFaction
A faction focusing on effects when snowed and longshot.

(Alternatively, Coldblooded Faction. TODO: decide. internal name is fine.)

## Units

### Gates
Triggers on hit and scales quickly, at the cost of player turns and opportunities.

### Reggie
Has a slow start when deployed, but hits hard.

### Scorpy
"Get over here!" Deals good damage, but makes it hard to focus unit hits.

### Colbo
Steals money. Not a team player.

# Development

## First Time Setup
1. Create profile in r2modman.
2. Download BepInEx and Wildfrost_API
3. Setup plugin directory.
4. Change all paths in Makefile. (TODO: Make more ergonomic.)
5. Run `make copy-lib-from-bepinex` and `make copy-lib-from-miya`
6. Run `make`.