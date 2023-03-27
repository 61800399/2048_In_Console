using Console_2048;
using System;

public class Twenty48
{
    #region Fields
    private string[,] _board = new string[4,4]
	{
		{ " ", " ", " ", " " },
		{ " ", " ", " ", " " },
		{ " ", " ", " ", " " },
		{ " ", " ", " ", " " },
	};
    #endregion
    #region Properties
    public string[,] Board 
	{ 
		get { return _board; } 
		set { _board = value; } 
	}
    #endregion
	private void Print() // Test code please remove later!
	{
		int count = 0;
		foreach (var Square in _board)
		{
			
			if (count % 4 == 0)
			{
				Console.WriteLine();
			}
            count++;
            Console.Write(Square + ", ");
		}
		Console.WriteLine("Done!");
	}
	/// <summary>
	/// Creates an new block in a random null square
	/// 10% chance of producing a 4, otherwise always produces a value of 2
	/// </summary>
	private void New_Block()
	{
		int x;
		int y;
		int FourChance;
        while (true)
		{
            Random Rnd = new Random();
            x = Rnd.Next(4);
            y = Rnd.Next(4);
			FourChance = Rnd.Next(0, 11);
            if (Board[x, y] == " ")
            {
				if (FourChance <= 1)
				{
					Board[x, y] = "4";
					break;
				}
				else
				{

				}
				Board[x, y] = "2";
                break;
            }
        }
	}
	
	private void Shift_Blocks(int Key)
	{
        #region Shift Right
        if (Key == 100) // Char D, Shifts all blocks to the Right
		{
			for (int Quad_Check = 0;  Quad_Check < 4; Quad_Check++)
			{
				for (int Y = 0; Y < 4; Y++)
				{
                    for (int Square = 2; Square >= 0; Square--)
                    {
                        if (_board[Y, Square + 1] == " " && _board[Y, Square] != " ")
                        {
                            _board[Y, Square + 1] = _board[Y, Square];
                            _board[Y, Square] = " ";
                            Print();
                        }
                    }
                }
                
            }
		}
        #endregion
        if (Key == 97) // Char A
		{

		}
	}
	/// <summary>
	/// Occurs when the player moves the blocks 
	/// Checks for WASD
	/// </summary>
	/// <param name="Key">ASCII value of the first key entered</param>
	public void Move(int Key)
	{
		if (Key == 100 || Key == 97 || Key == 115 || Key == 119) // only accepting D, A, S, W, (in that order)
		{
			Shift_Blocks(Key);
			New_Block();
		}
		
	}
}
