# Project status
I will be working on this but at a snails pace for the next few months. Plans are to have this fully developped by the end of the year. 

# RpgHBAnnals
The Rpg Home Brew Annals is an MVC were users who make an account can store and share their home made RPG creations that they use in their table top games. 
Over all it is rather simple in its style and how it works. There are games, weapons, and npc's that can be made by users. In an effort to keep things simple
I did try to make the creating process as simple yet customizable as possible. Each weapon and npc is tied to a game via a foreign keys, the relationship is one
game to many weapons and or npc's this also allowed me to bypass the need for a joining table for version 1.0.

## Notes for consideration
I made this in microsoft VS community 2022 edition. I am unaware if it will work in other applications.
I have not seeded any content for this project and will update the README when I do. 

## Future Plans for v2.0
I do plan on adding an Items and Monsters table, as well as a random picker from each DB so a player or DM can pick items, monsters, weapons, and npc's on the fly 
while they play. Additionally a loot function is in the works which will be in effect a joining table so if a player(s) kill a monster or npc they will have 
loot available. 




