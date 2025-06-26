using System;
using System.Collections.Generic;

// Some code in this project was made with assistance from AI

/*
  ************************************************************

  CONNECT FOUR GAME

  By Ivy Strukoff and Kabin Katuwal

  SODV1202 Final Project Group L

  ************************************************************
*/

namespace ConnectFour
{
    public class Game
    {
        // Properties
        public Player CurrentPlayer { get; set; }
        public Board GameBoard { get; set; }
        public int Turn { get; set; }

        // Methods
        public void Start(Player startingPlayer)
        {
            // Initialize the game (this method also acts as a constructor)

            // Initialize the board array
            Cell[,] initialCells = new Cell[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    initialCells[i, j] = new Cell(i, j, false);  // Iterate all the elements of intialCells to be empty
                }
            }

            // Initialize the board using initialCells
            Board initialGameBoard = new Board(initialCells);
            this.GameBoard = initialGameBoard;

            // Set the current player to be the human player
            this.CurrentPlayer = startingPlayer;

            // Set the current turn to be turn 1
            this.Turn = 1;
        }

        public bool CheckWinner(Player currentPlayer)
        {
            // Check for a winner
            // Vertical check
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    // if the chip in cell property is true for 4 vertical cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell 
                        && this.GameBoard.cells[i + 1, j].ChipInCell 
                        && this.GameBoard.cells[i  +2, j].ChipInCell 
                        && this.GameBoard.cells[i + 3, j].ChipInCell
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 1, j ].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 2, j ].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 3, j ].ChipType.XorO)
                    {
                        return true;
                    }
                }
            }

            // Horizontal check
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // if the chip in cell property is true for 4 horizontal cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i , j + 1].ChipInCell && this.GameBoard.cells[i , j + 2].ChipInCell && this.GameBoard.cells[i , j + 3].ChipInCell
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i , j + 1].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i , j + 2].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i , j + 3].ChipType.XorO)
                    {
                        return true;
                    }
                }
            }

            // Diagnol top left to bottom right check
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // if the chip in cell property is true for 4 diagnol (top left to bottom right) cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i + 1, j + 1].ChipInCell && this.GameBoard.cells[i + 2, j + 2].ChipInCell && this.GameBoard.cells[i + 3, j + 3].ChipInCell
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 1, j + 1].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 2, j + 2].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 3, j + 3].ChipType.XorO)
                    {
                        return true;
                    }
                }
            }

            // Diagonal top right to bottom left check
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    // if the chip in cell property is true for 4 diagnol (top right to bottom left) cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i + 1, j - 1].ChipInCell && this.GameBoard.cells[i + 2, j - 2].ChipInCell && this.GameBoard.cells[i + 3, j - 3].ChipInCell
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 1, j - 1].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 2, j - 2].ChipType.XorO
                        && this.GameBoard.cells[i, j].ChipType.XorO == this.GameBoard.cells[i + 3, j - 3].ChipType.XorO)
                    {
                        return true;
                    }
                }
            }

            // If it fails all checks return false, increment Turn by +1, and set the current player to be the other player
            return false;
        }
        public bool IsBoardFull()
        {
            for (int j = 0; j < 7; j++)
            {
                if (!GameBoard.cells[0, j].ChipInCell)
                {
                    return false;
                }
               
            }
            return true;
        }
    }
    

    public abstract class Player
    {
        // Properties
        public string Name { get; set; }
        public string PlayerType { get; set; }

        public Player(string name, string playerType)
        {
            this.Name = name;
            this.PlayerType = playerType;
        }

        // Methods
        public virtual void PlaceChip(int column, ref Game game, Player Player)
        {
            // Place a chip on the board
        }
    }

    public class HumanPlayer : Player
    {
        // Constructor
        public HumanPlayer(string name, string playerType) : base(name, playerType)
        {

        }

        // Methods
        public override void PlaceChip(int column, ref Game game, Player humanPlayer)
        {
            // Place a chip on the board taking in a user input in the main function
            // Check if the column is full
            // If full, ask for a new column
            // If not full, place the chip in the lowest available row

            // Check if the column is full
            Board gameBoardForCheck = game.GameBoard;
            for (int i = 5; i >= 0; i--)
            {
                if (gameBoardForCheck.cells[i, column].ChipInCell == false)
                {
                    // Place the chip in the lowest available row
                    gameBoardForCheck.cells[i, column].ChipInCell = true;
                    gameBoardForCheck.cells[i, column].ChipType = new Chip { 
                        XorO = humanPlayer,
                        Position = gameBoardForCheck.cells[i,column]
                    };
                    game.GameBoard = gameBoardForCheck;
                    break;
                }
            }
        }
    }

    public class AIPlayer : Player
    {
        // Constructor
        public AIPlayer(string name, string playerType) : base(name, playerType)
        {

        }

        // Methods
        public override void PlaceChip(int column, ref Game game, Player AIPlayer)
        {
            // Place a chip on the board using an algorithm
            Board gameBoardForCheck = game.GameBoard;
            for (int i = 5; i >= 0; i--)
            {
                if (gameBoardForCheck.cells[i, column].ChipInCell == false)
                {
                    // Place the chip in the lowest available row
                    gameBoardForCheck.cells[i, column].ChipInCell = true;
                    gameBoardForCheck.cells[i, column].ChipType = new Chip 
                    {
                        XorO = AIPlayer,
                        Position = gameBoardForCheck.cells[i,column]
                    };
                    game.GameBoard = gameBoardForCheck;
                    break;
                }
            }
        }

        // Make a method to determine the best column to place the chip in
        public int DetermineBestColumn(Game game, Player AIPlayer, Player humanPlayer)
        {
            Random rnd = new Random();     // create a random number generator
            if (game.Turn == 2)
            {
                return rnd.Next(0,7);     // if it is the first turn, place the chip in a random column
            }
            else
            {
                int bestColumn = -1;
                int bestScore = int.MinValue;

                for (int col = 0; col < 7; col++)
                {
                    if (IsColumnFull(col, game)) continue;

                    int row = GetNextAvailableRow(col, game);
                    if (row == -1) continue;
                    game.GameBoard.cells[row, col].ChipInCell = true;
                    game.GameBoard.cells[row, col].ChipType.XorO = AIPlayer;

                    // evaluate the score for this move
                    int score = EvaluateBoard(game, AIPlayer, humanPlayer);

                    // undo the move
                    game.GameBoard.cells[row, col].ChipInCell = false;
                    game.GameBoard.cells[row, col].ChipType = null;

                    // update the best column if this move has a higher score
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestColumn = col;
                    }
                }
                if(bestColumn == -1)
                {
                    List<int> availableColumns = new List<int>();
                    for(int col = 0; col < 7; col++)
                    {
                        if (!IsColumnFull(col, game)) availableColumns.Add(col);
                    }
                    return availableColumns.Count > 0 ? availableColumns[rnd.Next(availableColumns.Count)] : -1;
                }
                return bestColumn;
            }
        }

        // Private method to check if a column is full
        private bool IsColumnFull(int column, Game game)
        {
            // if the column is full return true, if not return false
            return game.GameBoard.cells[0, column].ChipInCell;
        }

        // Private method to get the next avaliable row
        private int GetNextAvailableRow(int column, Game game)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (!game.GameBoard.cells[row, column].ChipInCell)
                {
                    return row;
                }
            }
            return -1;     // should not reach here if the column is not full
        }

        // private method to check if a move is in bounds
        private bool IsInBounds(int row, int column)
        {
            return row >= 0 && row < 6 && column >= 0 && column < 7;
        }

        // private method to count consecutive pieces
        private int CountConsecutivePieces(int startRow, int startColumn, int rowIncrement, int columnIncrement, Game game, Player AIPlayer)
        {
            int count = 0;
            int row = startRow + rowIncrement;
            int column = startColumn + columnIncrement;

            while (IsInBounds(row, column) && game.GameBoard.cells[row, column].ChipType.XorO == AIPlayer)
            {
                count++;
                row += rowIncrement;
                column += columnIncrement;
            }

            return count;
        }

        // private method to evaluate the direction
        private int EvaluateDirection(int row, int column, int rowIncrement, int columnIncrement, Game game, Player Player)
        {
            int score = 0;

            for (int i = 0; i < 6; i++)
            {
                // check if the current position is valid
                if (game.GameBoard.cells[row, column].ChipType.XorO == Player)
                {
                    // count consecutive pieces in the specified direction
                    int count = 1;

                    // check in positive direction
                    count += CountConsecutivePieces(row, column, rowIncrement, columnIncrement, game, Player);
                    // check in negative direction
                    count += CountConsecutivePieces(row, column, -rowIncrement, -columnIncrement, game, Player);

                    // score based on the count of consecutive pieces
                    if (count == 4)
                    {
                        score += 1000;     // winning move
                    }

                    else if (count == 3)
                    {
                        score += 5;        // potential winning move
                    }

                    else if (count == 2)
                    {
                        score += 2;        // good move
                    }
                }
            }

            return score;
        }

        // private method to evaluate the board
        private int EvaluateBoard(Game game, Player AIPlayer, Player humanPlayer)
        {
            Player opponent = humanPlayer;
            int score = 0;

            // check all possible winning conditions
            score += EvaluateDirection(0, 0, 1, 0, game, AIPlayer);     // vertical
            score += EvaluateDirection(0, 0, 0, 1, game, AIPlayer);     // horizontal
            score += EvaluateDirection(0, 0, 1, 1, game, AIPlayer);     // diagonal (top left to bottom right)
            score += EvaluateDirection(0, 0, 1, -1, game, AIPlayer);    // diagonal (top right to bottom left)

            // check opponent's winning conditions and subtract from score
            score -= EvaluateDirection(0, 0, 1, 0, game, opponent);     // vertical
            score -= EvaluateDirection(0, 0, 0, 1, game, opponent);     // horizontal
            score -= EvaluateDirection(0, 0, 1, 1, game, opponent);     // diagonal (top left to bottom right)
            score -= EvaluateDirection(0, 0, 1, -1, game, opponent);    // diagonal (top right to bottom left)

            return score;
        }


    }

    public class Board
    {
        // Properties
        public Cell[,] cells = new Cell[6, 7];

        // Constructor
        public Board(Cell[,] cells)
        {
            this.cells = cells;
        }

        // Methods
        public void DisplayBoard(Player Xplayer, Player Oplayer)
        {
            // Display the board using X and O to represent the chips belonging to their respective players, * represents an empty space
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 7; j++)
                {
                    if (this.cells[i, j].ChipType.XorO == Xplayer)
                    {
                        Console.Write("X  ");
                    }
                    else if (this.cells[i, j].ChipType.XorO == Oplayer)
                    {
                        Console.Write("O  ");
                    }
                    else if (this.cells[i, j].ChipInCell == false)
                    {
                        Console.Write("*  ");
                    }
                }
            }
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 6; i++)
            {
              for(int j=0; j< 7; j++)
                {
                    cells[i, j].ChipInCell = false;
                    cells[i, j].ChipType = null;
                }
            }
        }
    }

    public class Cell
    {
        // Properties
        public int Row { get; set; }
        public int Column { get; set; }
        public bool ChipInCell { get; set; }
        public Chip ChipType { get; set; }

        // Constructor
        public Cell(int row, int column, bool chipInCell)
        {
            this.Row = row;
            this.Column = column;
            this.ChipInCell = chipInCell;
        }

        // Methods
        public void DropChip()
        {
            // Drop a chip into the cell
            this.ChipInCell = true;
        }

        public void RemoveChip()
        {
            // Remove a chip from the cell
            this.ChipInCell = false;
        }
    }

    public class Chip
    {
        // Properties
        public Cell Position { get; set; }
        public Player XorO { get; set; }

        // Methods
    }

    class Program
    {
        public static void Main(string[] args)
        {
            do
            {


                // Create a new game
                Game connectFour = new Game();

                // Start the game
                Player playerX = new HumanPlayer("Human Player", "X");
                Player playerO = new AIPlayer("AI Player", "O");
                bool gameOver = false;
                connectFour.Start(playerX);

                // Display the board
                Console.WriteLine("Welcome to Connect Four!\n");
                do
                {
                    Console.Clear();
                    Console.WriteLine("Turn: {0}  Current Player, {1}", connectFour.Turn, connectFour.CurrentPlayer);
                    connectFour.GameBoard.DisplayBoard(playerX, playerO);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("1  2  3  4  5  6  7");
                    if (connectFour.CurrentPlayer == playerX)
                    {
                        bool nonvalidInputFlag = true;
                        while (nonvalidInputFlag)
                        {
                            Console.WriteLine("Select a column to place your X chip (between 1 and 7 or type 0 to exit): ");
                            string input = Console.ReadLine();

                            if (input == "0")    // if the player wants to exit the game
                            {
                                gameOver = true;
                                nonvalidInputFlag = false;
                                break;
                            }
                            if (!int.TryParse(input, out int selectedColumn) || selectedColumn < 1 || selectedColumn > 7)
                            {
                                Console.WriteLine("Invalid input. Please enter a number between 1 and 7");
                                continue;
                            }
                            selectedColumn--;
                            if (connectFour.GameBoard.cells[0, selectedColumn].ChipInCell)
                            {
                                Console.WriteLine("Column {0} is full. Please choose another column.", selectedColumn + 1);
                                continue;
                            }
                            playerX.PlaceChip(selectedColumn, ref connectFour, playerX);
                            nonvalidInputFlag = false;

                            Console.Clear();
                            connectFour.GameBoard.DisplayBoard(playerX, playerO);
                            Console.WriteLine("\n\n1 2 3 4 5 6 7");
                        }
                        if (gameOver) break;
                        // check for winner
                        if (connectFour.CheckWinner(playerX))
                        {
                            // display winning message

                            Console.WriteLine("Congratulations {0}, you have won the game!", playerX.Name);
                            gameOver = true;

                        }
                        else if (connectFour.IsBoardFull())
                        {


                            Console.WriteLine("\nThe board is full. It's a draw!");
                            gameOver = true;
                        }
                        else
                        {
                            connectFour.Turn++;
                            connectFour.CurrentPlayer = playerO;
                        }
                    }
                    else if (connectFour.CurrentPlayer == playerO)
                    {
                        int bestColumn = ((AIPlayer)playerO).DetermineBestColumn(connectFour, playerO, playerX);
                        if (bestColumn == -1)
                        {
                            Console.Clear();
                            connectFour.GameBoard.DisplayBoard(playerX, playerO);
                            Console.WriteLine("\nNo valid moves left. It's a draw!");
                            gameOver = true;
                        }
                        else
                        {
                            playerO.PlaceChip(bestColumn, ref connectFour, playerO);
                            Console.Clear();
                            connectFour.GameBoard.DisplayBoard(playerX, playerO);
                            Console.WriteLine("\n\n 1 2 3 4 5 6 7");
                            Console.WriteLine("\nAI placed chip in column {0}", bestColumn + 1);
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadKey();

                            if (connectFour.CheckWinner(playerO))
                            {
                                Console.WriteLine("Congratulations {0}, you have won  the game!", playerO.Name);
                                gameOver = true;
                            }
                            else if (connectFour.IsBoardFull())
                            {
                                Console.WriteLine("\nThe board is full. It's a draw!");
                                gameOver = true;
                            }
                            else
                            {
                                connectFour.Turn++;
                                connectFour.CurrentPlayer = playerX;
                            }
                        }
                    }
                } while (!gameOver);

                Console.WriteLine("\nGame Over! Press any key to exit.");

            } while (true);
        }
     }
 }

