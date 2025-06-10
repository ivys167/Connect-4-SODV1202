using System;

namespace ConnectFour
{
  public class Game
  {
    // Properties
    public Player CurrentPlayer { get; set; }
    public Board GameBoard { get; set; }

    // Methods
    public void Start()
    {
      // Initialize the game

      Cell[ , ] initialCells = new Cell[7, 6];
      Board gameBoard = new Board(initialCells);
    }

    public void CheckWinner()
    {
      // Check for a winner
      // Vertical check

      // Horizontal check

      // Diagnol top left to bottom right check

      // Diagnol top right to bottom left check

      // If no winner, switch players
      // If winner, end game
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

      // Methods
      public override void PlaceChip()
    {
      // Place a chip on the board taking in a user input in the main function
    }
  }

  public class AIPlayer : Player
  {
    // Properties
    public string Name { get; set; }
    public string PlayerType { get; set; }

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
    public Chip ChipInCell { get; set; }

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
