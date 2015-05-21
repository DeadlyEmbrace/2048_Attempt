namespace _2048_Attempt
{
    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        #region Constructor

        public Position(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        #endregion  
    }
}