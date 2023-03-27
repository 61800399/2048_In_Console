namespace Console_2048
{
    internal class Program
    {
        private static Twenty48 Game = new Twenty48();
        static void Main(string[] args)
        {
            Print(Game.Board);
            while (true)
            {
                New_Turn();
            }
            
        }
        private static void Print(string[,] Board)
        {
            string output = null;
            short count = 0;
            foreach (var x in Board)
            {
                output += x + ", ";
                
                count++;
                if (count % 4 == 0)
                {
                    output += "\n";
                }
            }
            Console.WriteLine("\n" + output);
        }
        private static void New_Turn()
        {
            int x = Console.Read();
            while (true)
            {
                if (x >= 97) // Eliminates reading of invalid value types, Valid type conditional
                {
                    Console.Clear();
                    Game.Move(x);
                    Console.WriteLine(x);
                    Print(Game.Board);
                    break;
                }
                else // invalid type condidtional, does not progress the game
                {
                    Console.Clear();
                    Print(Game.Board);
                    return;
                }
            }
            
            
        }
    
    }
}