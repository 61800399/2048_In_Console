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
	/// <summary>
	/// Shifts all of the blocks to the players correct side
	/// W shifts Up
	/// A shifts Left
	/// S shifts Down
	/// D shifts Right
	/// </summary>
	/// <param name="Key">The key pressed by the player</param>
	private void Shift_Blocks(int Key)
	{
        #region Shift Right
        if (Key == 100) // Char D, Shifts all blocks to the Right
		{
			for (int Y = 0; Y < 4; Y++)
			{
                for (int X = 3; X >= 0; X--)
                {
					int max = 3;
					while (max > 0)
					{
                        if (_board[Y, max] == " " && _board[Y, X] != " ")
                        {
                            _board[Y, max] = _board[Y, X];
                            _board[Y, X] = " ";
                        }
						else
						{
							max--;
						}
                    }
					

                }
            }
		}
        #endregion
        #region Shift Left
        if (Key == 97) // Char A Shifts all blocks to the left
		{
            for (int Y = 0; Y < 4; Y++)
            {
                for (int X = 0; X < 4;  X++)
				{
					int max = 0;
					while (max < 4)
					{
                        if (_board[Y, max] == _board[Y, X] && _board[Y, X] != " ")
                        {
                            int.TryParse(_board[Y, max], out int num);
                            _board[Y, max] = (num * 2).ToString();
                        }
                        else if (_board[Y, max] == " " && _board[Y, X] != " ")
						{
							_board[Y, max] = _board[Y, X];
							_board[Y, X] = " ";
						}
						else
						{
							max++;
						}
					}
				}
            }
        }
        #endregion
        #region Shift Down
        if (Key == 115) // Char S Shifts all blocks down
		{
			for (int X = 0; X < 4; X++)
			{
				for (int Y = 3; Y > -1; Y--)
				{
					int max = 3;
					while (max >= 0)
					{
                        if (_board[max, X] == _board[Y, X] && _board[max, X] != " " & max != Y)
                        {
                            int.TryParse(_board[max, X], out int num);
                            _board[max, X] = (num * 2).ToString();
							_board[Y, X] = " ";
							max--;
                        }
                        else if (_board[max, X] == " " && _board[Y, X] != " " && max > Y)
                        {
                            _board[max, X] = _board[Y, X];
                            _board[Y, X] = " ";
                        }
						else
						{
							max--;
						}
                    }
					
				}
			}
		}
        #endregion
        #region Shift Up !!Fully Functional!!
		if (Key == 119)
		{
			for (int X = 0; X < 4; X++)
			{
				for (int Y = 1; Y < 4; Y++)
				{
					int max = 0; //  sets the maximum it can move
                    while (max < 4)
                    {
                        if (_board[max, X] == _board[Y, X] && _board[max, X] != " " && max != Y)
                        {
                            int.TryParse(_board[max, X], out int num);
                            _board[max, X] = (num * 2).ToString();
                            _board[Y, X] = " ";
                            max++;
                        }
                        else if (_board[max, X] == " " && _board[Y, X] != " " && max < Y)
                        {

                            _board[max, X] = _board[Y, X];
                            _board[Y, X] = " ";
                        }
                        else
                        {
                            max++;
                        }
                    }
                }
			}
		}
        #endregion
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
