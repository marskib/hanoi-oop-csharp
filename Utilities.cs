namespace Hanoi
{
    public partial class Utilities
    {
        //Columns to place the stacks A,B,C
        public static byte kA = 15;
        public static byte kB = 40;
        public static byte kC = 65;
        //
        public static byte Wd = 20; //Wiersz dolny
        public static byte SzerPdst = 24; //width of the widest disk; should be even
        public static char segment = '#';

        public static void gotoXY(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        public static ConsoleColor GetDiskColor(int diskID)
        {
            switch (diskID) {
                case  0: return ConsoleColor.Green; break;
                case  1: return ConsoleColor.Red; break;
                case  2: return ConsoleColor.White; break;
                case  3: return ConsoleColor.Blue; break;
                case  4: return ConsoleColor.Yellow; break;
                case  5: return ConsoleColor.DarkRed; break;
                case  6: return ConsoleColor.DarkGreen; break;
                case  8: return ConsoleColor.Green; break;
                case  9: return ConsoleColor.DarkBlue; break;
                case 10: return ConsoleColor.Yellow; break;
                case 11: return ConsoleColor.Red; break;
                default: return ConsoleColor.White;
            }
        }

        
    }
}
