namespace Hanoi
{

    /*
     * Class to describe single plate/disk that is part of a tower.
     */
    public partial class Disk
    {
        private int _id;

        public Disk(int id)
        {
            _id = id;
        }

        public int Width
        //Width of a disk depends on its place in the initial tower.
        //This place is determined by the constructor during building of the first tower
        //and equals _id (which is preserved through the entire game).
        {
            get { return Utilities.SzerPdst - 2 * _id; }
        }

        public void Print(char pattern)
        {
            for (int i = 0; i < Width; i++)
                Console.Write(pattern);
        }

    }


}
