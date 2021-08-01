# Battleship

## Interface
### Boards
Each board is 10x10 grid with x axis labeled as numbers (0-9) and y axis labeled as characters (A-J). Each field is labeled with it's coordinates. The color of a single field indicates it's state (hit, miss, boat, free). When a new board is created, boats are placed randomly (avoiding colissions and crossing the board limits) using `PlaceBoat()` method. It takes two arguments: boat size and boat color, then finds suitable place for placing this boat. Board also has a `CheckHit()` method to check if enemy's shot was hit or miss depending on given coordinates.

### Buttons
#### New game
Reinitializes players state and generates new boards.
#### Start
Starts simulation of gameplay between two players. 
#### Manual shot
Allows to perform a shot manually, so the user can control when the next shot is fired.

### Status window
After each shot, a message is logged into this window. It is an information about active player and selected field. If player wins, the message shows which one is the winner and how many moves were performed.

## Game logic
After set interval, next player is set as active, then the shot is performed and status window is updated. Next, the player score is checked. If the score is 17 (sum of boats size: 5, 4, 3, 3, 2), game ends and the winner is shown in the status window. If there is no winner yet, selected player is changed and the cycle continues.

## Targeting algorithm
The cycle is based on the timer. After each interval next player performs a shot. Player shots at random fields. As soon as player hits an enemy boat, the algorithm focuses on nearby fields (N. E, W, S ) to find next target. When target is found, the boat orientation can be defined (vertical or horizontal) and player keeps shooting in defined direction. When there is no more "boat fields" in the line, algorithm switches back to generating random targets. To avoid shooting twice at the same field, the `availableMoves` list was created. At startup it is populated with every field coordinates (from A0 to J9). After each shot, generated target is removed from list of available moves. If generated target is not in this list, then a new target must be created. If neither target is on this list, random one is generated.
