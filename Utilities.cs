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
        //public static char pattern = '#';
        public static char pattern = (char)230;

        public static void gotoXY(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

    }
}
