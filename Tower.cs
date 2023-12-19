using System.Threading.Channels;
using static Hanoi.Utilities;


namespace Hanoi
{
    /* 
     * Class to describe the current state of each stack/tower:
     * how many disks are on the stack and which ones they are.
     * There will be 3 instances of the class,
     * as there are 3 stacks in Hanoi puzzle.
    */
    public class Tower
    {
        //maximum acceptable number of disks
        private const byte MaxKr = 12;

        //'physical' placement of the Tower:
        private int column;

        //How many disks is currently on the stack:
        private int ileSztuk = 0;

        //member `disks[]` - the ids of the disks on the stack.
        //The ids are given just before the game starts.
        //The ids determine disks's width (later used in drawing).
        //disks[] is in fact a stack itself, with this.ileSztuk-1 pointing at its top.
        private Disk[] disks = new Disk[MaxKr];

        public Tower(int column)
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
            int row = Utilities.Wd - this.GetStackHeight() + 1;
            var disk = GetTopDisk();
            //where to place the cursor to start printing:
            int width = disk.GetWidth();
            gotoXY(this.column - (width / 2), row);
            //
            disk.Print(pattern);
        }

        public void Przenies(Tower Destination)
        /*Graphical representation of the move*/
        {
            //Console.WriteLine(Sk + " -> " + Dk);

            Disk disk = GetTopDisk(); //we always move the top disk only
            RemoveTopDisk();
            Destination.PutDisk(disk);
        }

        public void PutDisk(Disk disk)
        {
            this.disks[ileSztuk] = disk; //disk lands on the top of the stack/tower (the table has 0-based idx, so ileSztuk points "higher" then the current top)
            this.ileSztuk++;
            this.PrintTopDisk(Utilities.pattern);
        }

        private void RemoveTopDisk()
        {
            this.PrintTopDisk(' '); //erasing/clearin top disk (only visually)
            this.ileSztuk--;        //"real" remove
        }

        private Disk GetTopDisk()
        {
            return this.disks[ileSztuk - 1];
        }

    }
}

