using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace New_portal2D
{
    class Sprite
    {
        // Váriaveis de textura e posição
        public Vector2 Position { get; set; }
        public Texture2D Texture { set; get; }
        public SpriteBatch SpriteBatch { get; set; }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }

        public Sprite(Texture2D texture, Vector2 position, SpriteBatch batch)
        {
            Texture = texture;
            Position = position;
            SpriteBatch = batch;
        }

        public virtual void Draw()
        {
            SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
