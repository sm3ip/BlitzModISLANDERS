# BlitzModISLANDERS
We're developping a mod for the game Islanders by Coatsink.
Ever wanted to add a stress-inducing mechanic to a chill/ relaxing game ? Lemme introduce you to the "Blitz" gamemode.
A "Blitz" game will be similar to a "Highscore" game but you'll be rewarded for building faster by getting a better multiplier the faster you get (obviously the amount of points needed to get your next building pack/ island will be reworked to still be challenging).

## developpement state :
The mod is still at its early stage and I'm working on it on my free time so don't expect it to be ready too soon.
### TODO :
- [x] Create a Countdown system which can go up through functions as well 
- [x] Make a system to associate stages of said CountDown with a multiplier
- [ ] Link the multiplier with the scoring function
- [ ] modify building pack/ new island requirements to fit the gamemode
- [ ] create a button to be able to choose this gamemode over the game's original ones
- [ ] store original building pack/ new island requirements somewhere in the code
    - [ ] set the correct variable set when choosing the gamemode
- [ ] handle gamestate behaviors
    - [ ] how to handle pause/unpause
    - [ ] gameover when countdown at 0 and next island not available
    - [ ] store the countdown values at application.quit 
    - [ ] recreate the countdown at mod initialisation
    - [ ] freeze countdown when choosing a new building pack, unfreeze it at next mouse click
    - [ ] create a new countdown when island transition is done

