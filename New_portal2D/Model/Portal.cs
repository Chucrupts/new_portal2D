using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using New_portal2D;

namespace Portal2D.Models
{
    class Portal : Sprite
    {
        // Parâmetros   public Vector2 Movement { get; set; }
        private Vector2 portalPosition;
        // Sprite do portal
        private Texture2D portalTexture;
        // É portal de saida? Foi movido?
        private Boolean exit, moved;

        public Portal(Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        { }

        // setters and getters
        // Altera a posição do portal
        public void SetPortalPosition(Vector2 portalPosition)
        {
            this.portalPosition = portalPosition;
        }
        // Altera a sprite do portal
        public void SetPortalTexture(Texture2D portalTexture)
        {
            this.portalTexture = portalTexture;
        }

        // Retorna a posição do portal
        public Vector2 GetPortalPosition => portalPosition;
        // Altera a condição de entrada ou saída do portal
        public void SetPortalExit(Boolean exit)
        {
            this.exit = exit;
        }
        // Retorna a condição de entrada ou saída do portal
        public Boolean GetPortalExit => exit;
        // Altera a condição de Movido
        public void SetPortalMoved(Boolean moved)
        {
            this.moved = moved;
        }
        // Retorna a condição de movido do portal
        public Boolean GetPortalMoved => moved;
        // Retorna a largura da sprite do portal
        public int GetPortalWidth => portalTexture.Width;
        // Retorna a sprite do portal
        public Texture2D GetPortalTexture => portalTexture;
        // Retorna a altura da sprite do portal
        public int GetPortalHeight => portalTexture.Height;

        // Métodos para tempo de jogo.

        public void Initialize(Boolean exit)
        {
            SetPortalExit(exit);
            SetPortalMoved(false);
        }



        public void Update()
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(portalTexture, portalPosition, null, Color.White, 0f, Vector2.Zero, 1f,
                SpriteEffects.None, 0f);
        }

    }
}
