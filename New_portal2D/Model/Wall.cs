using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Portal2D.Models
{
    class Wall
    {
        // Parâmetros
        //Posição do bloco iniciada no canto superior esquerdo da tela
        private Vector2 wallPosition;
        // Sprite do bloco
        private Texture2D wallTexture;
        private Boolean portable;
        private Boolean solid;


        // Getters and Setters

        // Altera a posição do bloco
        public void SetWallPosition(Vector2 wallPosition)
        {
            this.wallPosition = wallPosition;
        }
        // Altera a posição do bloco
        public void SetWallTexture(Texture2D wallTexture)
        {
            this.wallTexture = wallTexture;
        }
        // Altera se a parede é ou não portável
        public void SetWallPortable(Boolean portable)
        {
            this.portable = portable;
        }
        // Altera o atributo sólido da parede
        public void SetWallSolid(Boolean solid)
        {
            this.solid = solid;
        }

        // Retorna a posição do bloco
        public Vector2 GetWallPosition => wallPosition;
        // Retorna a largura da sprite do bloco
        public int GetWallWidth => wallTexture.Width;
        // Retorna a sprite do bloco
        public Texture2D GetWallTexture => wallTexture;
        // Retorna a altura da sprite do bloco
        public int GetWallHeight => wallTexture.Height;
        // Retorna a portabilidade do bloco
        public Boolean GetWallPortable => portable;
        // Retorna o atributo sólido do bloco
        public Boolean GetWallSolid => solid;

        public Wall(Texture2D wallTexture)
        {
            SetWallTexture(wallTexture);
            SetWallPosition(Vector2.Zero);
            SetWallPortable(true);
            SetWallSolid(true);
        }


        public void Initialize(Vector2 wallPosition,Boolean portable, Boolean solid)

        {
            SetWallPosition(wallPosition);
            SetWallPortable(portable);
            SetWallSolid(solid);
        }



        public void Update()
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wallTexture, wallPosition, null, Color.White, 0f, Vector2.Zero, 1f,
               SpriteEffects.None, 0f);
        }



    }
}
