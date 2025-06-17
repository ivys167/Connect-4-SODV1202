using System;

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

        public bool CheckWinner(Player currentPlayer)     //    update function to include the chip type in the different checks
        {
            // Check for a winner
            // Vertical check
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // if the chip in cell property is true for 4 vertical cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i, j + 1].ChipInCell && this.GameBoard.cells[i, j + 2].ChipInCell && this.GameBoard.cells[i, j + 3].ChipInCell)
                    {
                        return true;
                    }
                }
            }

            // Horizontal check
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    // if the chip in cell property is true for 4 horizontal cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i + 1, j].ChipInCell && this.GameBoard.cells[i + 2, j].ChipInCell && this.GameBoard.cells[i + 3, j].ChipInCell)
                    {
                        return true;
                    }
                }
            }

            // Diagnol top left to bottom right check
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // if the chip in cell property is true for 4 diagnol (top left to bottom right) cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i + 1, j - 1].ChipInCell && this.GameBoard.cells[i + 2, j - 2].ChipInCell && this.GameBoard.cells[i + 3, j - 3].ChipInCell)
                    {
                        return true;
                    }
                }
            }

            // Diagonal top right to bottom left check
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // if the chip in cell property is true for 4 diagnol (top right to bottom left) cells, return true
                    if (this.GameBoard.cells[i, j].ChipInCell && this.GameBoard.cells[i + 1, j + 1].ChipInCell && this.GameBoard.cells[i + 2, j + 2].ChipInCell && this.GameBoard.cells[i + 3, j + 3].ChipInCell)
                    {
                        return true;
                    }
                }
            }

            // If it fails all checks return false, increment Turn by +1, and set the current player to be the other player
            this.Turn += 1;
            return false;
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
            for (int i = 0; i < 6; i++)
            {
                if (gameBoardForCheck.cells[column, i].ChipInCell == true)
                {
                    Console.WriteLine("The selected column is full, please choose another column");
                }
                else if (gameBoardForCheck.cells[column, 5].ChipInCell == false)
                {
                    // Place the chip in the lowest available row
                    gameBoardForCheck.cells[column, 5].ChipInCell = true;
                    gameBoardForCheck.cells[column, 5].ChipType.XorO = humanPlayer;
                    game.GameBoard = gameBoardForCheck;
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
            for (int i = 0; i < 6; i++)
            {
                if (gameBoardForCheck.cells[column, i].ChipInCell == true)
                {
                    Console.WriteLine("The selected column is full, please choose another column");
                }
                else if (gameBoardForCheck.cells[column, 5].ChipInCell == false)
                {
                    // Place the chip in the lowest available row
                    gameBoardForCheck.cells[column, 5].ChipInCell = true;
                    game.GameBoard = gameBoardForCheck;
                }
            }
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
            // Display the board using X and O to represent the chips belonging to their respective players
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
                Console.WriteLine();
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("*  ");
                }
            }

            // Reset the value of the cells in the board to be empty
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.cells[i, j].ChipInCell = false;
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
                        int selectedColumn = Convert.ToInt32(Console.ReadLine());

                        if (selectedColumn == 0)    // if the player wants to exit the game
                        {
                            gameOver = true;
                            nonvalidInputFlag = false;
                            break;
                        }
                        if (selectedColumn < 0 && selectedColumn > 7)    // if the player selects an invalid column
                        {
                            Console.WriteLine("Invalid column, please select a column between 1 and 7");
                        }
                        if (selectedColumn > 1 && selectedColumn < 7)
                        {
                            playerX.PlaceChip(selectedColumn, ref connectFour, playerX);
                            nonvalidInputFlag = false;
                            // for later: find a way to make the flag true if the column is full within the method
                        }
                    }
                    if (connectFour.CheckWinner(playerX))
                    {
                        // display winning message
                        gameOver = true;
                        break;
                    }
                    // AI player stuff goes here
                }
            }
            while (!gameOver);
        }
    }
}
