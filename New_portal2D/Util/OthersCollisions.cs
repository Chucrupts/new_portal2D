using Microsoft.Xna.Framework;
using New_portal2D.Content;

namespace Portal2D.Util
{
    class OthersCollisions
    {

        public int RectangleContainsStraight(float sense, float x1, Player player,
            Point testPoint, float m, float k, Rectangle[] myRectWall)
        {

            int limit, increase;

            if (sense < 0)
            {
                limit = 960;
                increase = player.Texture.Width;
            }
            else
            {
                limit = 0;
                increase = -1 * player.Texture.Width;
            }
                

            {

                for (int i = (int)x1; i < limit; i += increase)
                {

                    testPoint.X = i;
                    testPoint.Y = (int)(m * (x1 + i) + k);

                    for (int count = 0; count < myRectWall.Length; count++)
                    {

                        if (myRectWall[count].Contains(testPoint))
                        {                            
                            return count;
                        }

                    }

                }
                
            }
            return -10;
        }        

    }
}
