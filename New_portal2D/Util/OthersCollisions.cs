using Microsoft.Xna.Framework;
using Portal2D.Models;

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
                increase = player.GetPlayerWidth;
            }
            else
            {
                limit = 0;
                increase = -1 * player.GetPlayerWidth;
            }
                

            {

                for (int i = (int)x1; i < limit; i += player.GetPlayerWidth)
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
