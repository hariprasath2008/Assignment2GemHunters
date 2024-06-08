# Gem Hunters Game (Console Edition)

## Objective
Develop a console-based 2D game called "Gem Hunters" where players compete to collect the most gems within a set number of turns.

## Game Description
- **Board Size**: A 6x6 square board.
- **Players**: 
  - Player 1 (P1) starts in the top-left corner (0,0).
  - Player 2 (P2) starts in the bottom-right corner (5,5).
- **Gems**: Randomly placed on the board at the start of the game. They do not move once placed.
- **Obstacles**: Random positions on the board (represented by "O") that players cannot pass through.

## Rules
- **Display**: The board will be displayed after every turn. Players will be represented by P1 and P2, gems by G, obstacles by O, and empty spaces by -.
- **Movement**: 
  - Players input their movement through the console: `U` for up, `D` for down, `L` for left, `R` for right.
  - Players can move up, down, left, or right by one square on their turn.
  - Players cannot move diagonally.
  - Players cannot move onto or through squares with obstacles.
- **Collecting Gems**:
  - If a player moves onto a square containing a gem, they collect that gem.
  - The gem is then removed from the board (the square becomes an empty space).
- **Turns**: 
  - Players alternate turns.
  - Each player gets 15 turns. The game ends after 30 moves (15 turns for each player).
- **Winning**:
  - The player with the most gems collected after all turns are exhausted wins.
  - If both players have the same number of gems, it's a tie.

## Class Structure
### Position Class
- **Properties**:
  - `X: int`
  - `Y: int`
- **Constructor**:
  - `Position(int x, int y)`

### Player Class
- **Properties**:
  - `Name: string` (e.g., "P1" or "P2")
  - `Position: Position`
  - `GemCount: int` (Number of gems collected by the player)
- **Methods**:
  - `Move(char direction)`: Updates the player's position based on the input direction (U, D, L, R).

### Cell Class
- **Properties**:
  - `Occupant: string` (Could be "P1", "P2", "G", "O", or "-" for empty)

### Board Class
- **Properties**:
  - `Grid: Cell[,]` (2D array of type Cell)
- **Constructor**:
  - `Board(Player player1, Player player2)`: Initializes the board with players, gems, and obstacles.
- **Methods**:
  - `Display()`: Prints the current state of the board to the console.
  - `IsValidMove(Player player, char direction)`: Checks if the move is valid.
  - `CollectGem(Player player)`: Checks if the player's new position contains a gem and updates the player's GemCount.

### Game Class
- **Properties**:
  - `Board: Board`
  - `Player1: Player`
  - `Player2: Player`
  - `CurrentTurn: Player` (Reference to the player whose turn it is)
  - `TotalTurns: int` (Keeps track of the number of turns that have passed)
- **Constructor**:
  - `Game()`: Initializes the game with a board and two players.
- **Methods**:
  - `Start()`: Begins the game, displays the board, and alternates player turns.
  - `SwitchTurn()`: Switches between Player1 and Player2.
  - `IsGameOver()`: Checks if the game has reached its end condition.
  - `AnnounceWinner()`: Determines and announces the winner based on GemCount of both players.

## How to Play
1. Run the game.
2. The board will be displayed with the initial positions of players, gems, and obstacles.
3. Players will take turns to move by entering `U` (up), `D` (down), `L` (left), or `R` (right).
4. The game continues until each player has taken 15 turns.
5. The player with the most gems collected wins. If both players have the same number of gems, it's a tie.
