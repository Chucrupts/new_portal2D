using System;
using Microsoft.Xna.Framework;
using Portal2D.Models;

namespace Portal2D.Controller
{
    class WallController
    {

        public Boolean CollisionWithPlayer(Player player, Wall[] wall)

        {
            Rectangle rectangle1, rectangle2;

            rectangle1 = new Rectangle((int)player.GetPlayerPosition.X,
                (int)player.GetPlayerPosition.Y,
                player.GetPlayerWidth,
                player.GetPlayerHeight);


            for (int i = 0; i < wall.Length; i++)

            {
                rectangle2 = new Rectangle((int)wall[i].GetWallPosition.X,
                    (int)wall[i].GetWallPosition.Y,
                    wall[i].GetWallWidth,
                    wall[i].GetWallHeight);


                if (rectangle1.Intersects(rectangle2))
                {
                    return true;

                }

            }
            return false;
        }

        
    }
}
