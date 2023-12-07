using System.Threading.Channels;
using static Hanoi.Utilities;


namespace Hanoi
{
    /* 
     * Class to describe the current state of each stack:
     * how many disks are on the stack and which ones they are.
     * There will be 3 instances of the class,
     * as there are 3 stacks in Hanoi puzzle.
    */
    public class Stack
    {
        //maximum acceptable number of disks
        private const byte MaxKr = 12;

        //'physical' placement of the Stack:
        private int column;

        //How many disks is currently on the stack:
        private int ileSztuk = 0;
        
        //member `disks[]` - the ids of the disks on the stack.
        //The ids are given just before the game starts.
        //The ids determine disks's width (later used in drawing).
        //disks[] is in fact a stack itself, with this.ileSztuk-1 pointing at its top.
        private int[] disks = new int[MaxKr];

        public Stack(int column)
        {
            this.column = column;
        }

        public int GetStackHeight() 
        { 
            return this.ileSztuk;
        }

        public void PrintTopDisk(char pattern)
         /* Printing disk, that is on the top of the stack */
        {
            int row   = Utilities.Wd - this.GetStackHeight() + 1;
            int width = Utilities.SzerPdst - 2 * GetTopDiskID();

            gotoXY(this.column - (width / 2), row);
            for (int i = 1; i <= width; i++)
            {
                Console.ForegroundColor = Utilities.GetDiskColor(this.GetTopDiskID());
                Console.Write(pattern);
                Console.ForegroundColor = ConsoleColor.White; //restoring
            }
        }

        public void Przenies(Stack Destination)
        /*Graphical representation of the move*/
        {
            //Console.WriteLine(Sk + " -> " + Dk);

            int diskID = this.GetTopDiskID(); //we always move the top disk only
            this.RemoveDisk();
            Destination.PutDisk(diskID);
        }

        public void PutDisk(int diskID)
        {
            this.disks[ileSztuk] = diskID; //disk lands on the top of the stack (the table has 0-based idx, so ileSztuk points "higher" then the current top)
            this.ileSztuk++;
            this.PrintTopDisk(Utilities.segment);
        }

        private void RemoveDisk()
        {
            this.PrintTopDisk(' ');
            this.ileSztuk--;
        }

        private int GetTopDiskID()
        {
            return this.disks[ileSztuk-1];
        }

    }
}

