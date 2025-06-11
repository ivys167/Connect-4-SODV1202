using System;

namespace ConnectFour
{
  public class Game
  {
    // Properties
    public Player CurrentPlayer { get; set; }
    public Board GameBoard { get; set; }
    public int Turn { get; set; }
    
    // Methods
    public void Start()
    {
      // Initialize the game (this method also acts as a constructor)

      // Initialize the board array
      Cell[,] initialCells = new Cell[7, 6];

      for (int i = 0; i < 7; i++)
      {
        for (int j = 0; j < 6; j++)
        {
          initialCells[i, j] = new Cell(i, j, false);    // Iterate all the elements of intialCells to be empty
        }
      }

      // Initialize the board using initialCells
      Board initialGameBoard = new Board(initialCells);
      this.GameBoard = initialGameBoard;

      // Initialize the players
      Player playerX = new HumanPlayer("Human Player", "X");
      Player playerO = new AIPlayer("AI Player", "O");

      // Set the current player to be the human player
      this.CurrentPlayer = playerX;

      // Set the current turn to be turn 1
      this.Turn = 1;
    }

    public bool CheckWinner()     // ignore the error, function is under construction
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

      // Diagnol top right to bottom left check

      // If it fails all checks return false and increment Turn by +1
    }

    public void Reset()
    {
      // Reset the game
    }

    public void End()
    {
      // End the game
    }
  }

  public abstract class Player
  {
    // Properties
    public string Name { get; set; }
    public string PlayerType { get; set; }

    // Methods
    public virtual void PlaceChip()
    {
      // Place a chip on the board
    }
  }

  public class HumanPlayer : Player
  {
    // Properties
    public string Name { get; set; }
    public string PlayerType { get; set; }

    // Constructor
    public HumanPlayer(string name, string playerType)
    {
      this.Name = name;
      this.PlayerType = playerType;
    }

    // Methods
    public override void PlaceChip()
    {
      // Place a chip on the board taking in a user input in the main function
      // Check if the column is full
      // If full, ask for a new column
      // If not full, place the chip in the lowest available row

      
    }
  }

  public class AIPlayer : Player
  {
    // Properties
    public string Name { get; set; }
    public string PlayerType { get; set; }

    // Constructor
    public AIPlayer(string name, string playerType)
    {
      this.Name = name;
      this.PlayerType = playerType;
    }
    
    // Methods
    public override void PlaceChip()
    {
      // Place a chip on the board using an algorithm
    }
  }

  public class Board
  {
    // Properties
    public Cell[ , ] cells = new Cell[7, 6];

    // Constructor
    public Board(Cell[,] cells)
    {
      this.cells = cells;
    }
    
    // Methods
    public void DisplayBoard()
    {
      // Display the board
    }

    public void ResetBoard()
    {
      // Reset the board
    }
  }

  public class Cell
  {
    // Properties
    public int Row { get; set; }
    public int Column { get; set; }
    public bool ChipInCell { get; set; }

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
    }

    public void RemoveChip()
    {
      // Remove a chip from the cell
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
    public static void Main (string[] args) 
    {
      
    }
  }
}
