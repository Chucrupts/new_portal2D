using System;
using Microsoft.Xna.Framework;
using Portal2D.Models;
using Microsoft.Xna.Framework.Input;
using Portal2D.Util;
using New_portal2D.Content;

namespace Portal2D.Controller
{
    class PortalController
    {
        public void CollisionWithPlayer(Player player, Portal entryPortal, Portal exitPortal)

        {
            Rectangle rectangle1, rectangle2, rectangle3;

            rectangle1 = player.Bounds;
            rectangle2 = entryPortal.Bounds;
            rectangle3 = exitPortal.Bounds;

            // Se estiver colidindo com o portal de entrada
            if (rectangle1.Intersects(rectangle2) && exitPortal.GetPortalMoved == true)
            {
                player.Position = exitPortal.GetPortalPosition /* + new Vector2(
                                         player.GetPlayerXspeed, player.GetPlayerYspeed)*/;

            }

            // Se estiver colidindo com o portal de saida
            if (rectangle1.Intersects(rectangle3) && entryPortal.GetPortalMoved == true)
            {
                player.Position = entryPortal.GetPortalPosition /* + new Vector2(
                                         player.GetPlayerXspeed, player.GetPlayerYspeed)*/;

            } //Nessa parte da some de vetores talvez seja melhor somar o resultado da mutiplicação
              //entre o sinal da velocidade do player com o tamanho da largura, acho que vai evitar bug

        }

        /* A função abaixo cria a reta entre o centro do player e o ponto onde ele clicou e****
        ** posteriormente checa se esta reta colide com alguma parede, para instaciar o portal*/
        public void CollisionWithWall(Player player, Wall[] wall, Portal portal)

        {

            // Instancia objeto de others collisions
            OthersCollisions oc = new OthersCollisions();
            
            // Reserva espaço na memória para tantos retangulos quanto necessário
            Rectangle[] myRectWall = new Rectangle[wall.Length];

            // Atribuindo retangulos no vetor

            for (int i = 0; i < myRectWall.Length; i++)

            {
                myRectWall[i] = new Rectangle((int)wall[i].GetWallPosition.X,
                    (int)wall[i].GetWallPosition.Y,
                    wall[i].GetWallWidth,
                    wall[i].GetWallHeight);
            }

            // x1 e y1 são as coordenadas de um dos pontos da reta
            float x1 = player.Position.X + player.Texture.Width/2;
            float y1 = player.Position.Y + player.Texture.Height/2;

            // x2 e y2 São as coordenadas do segundo ponto
            float x2 = Mouse.GetState().X;
            float y2 = Mouse.GetState().Y;

            // m é a inclinação da reta
            float  m = (y2 - y1) / (x2 - x1);

            // k é uma constante que será utilizada no cálculo da posição Y para cada valor
            // de X substituido na equação da reta.
            // A equação da reta é obtida a partir da fórmula:  Y - Y1 = m . (X - X1)
            // De onde:  Y = mX - mX1 -(-Y1) --> Y = mX -mX1 + Y1    
            // logo, Y = mX + k, onde k = -mX1 + Y1
            float k = -m * x1 + y1;

            // Seta o ponto de teste que será utilizado para saber se colide com alguma parede
            Point testPoint = new Point(0,0);

            // Descobre para qual lado o player esta atirando. Isso serve para mandar o for
            // para o lado certo.

            // Chama aqui
            int count = oc.RectangleContainsStraight(x1 - x2, x1, player, testPoint, m, k, myRectWall);
            if ( count > 0)
            {
                portal.SetPortalPosition(wall[count].GetWallPosition);
                portal.SetPortalMoved(true);
            }
        }

        public void UpdatePortal(GameTime gameTime, Player player, Wall[] wall, Portal entryPortal, Portal exitPortal)
        {
            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                CollisionWithWall(player, wall, entryPortal);
                // Alterar a posição do portal de entrada
            }

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                CollisionWithWall(player, wall, exitPortal);
                    // Alterar a posição do portal de saída
            }
        }

    }
}

