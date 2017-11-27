using Microsoft.Xna.Framework;
using Portal2D.Models;
using System;


namespace Portal2D.Util
{
    class AxisCollision
    {

        public Boolean CollisionWithPlayerInAxisX(Player player, Wall[] wall, int plusInAxisX)

        {
            Rectangle rectangle1, rectangle2;

            rectangle1 = new Rectangle((int)player.GetPlayerPosition.X,
                (int)player.GetPlayerPosition.Y,
                player.GetPlayerWidth + plusInAxisX,
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



        public Boolean CollisionWithPlayerInAxisY(Player player, Wall[] wall, int plusInAxisY)

        {
            Rectangle rectangle1, rectangle2;

            rectangle1 = new Rectangle((int)player.GetPlayerPosition.X,
                (int)player.GetPlayerPosition.Y,
                player.GetPlayerWidth,
                player.GetPlayerHeight + plusInAxisY);


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
