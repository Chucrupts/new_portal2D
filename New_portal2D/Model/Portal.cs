using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace New_Portal2D.Models
{
    class Portal : Sprite
    {

        public Vector2 _portalPosition { get; set; }
        public Texture2D _portalTexture { get; set; }
        public Boolean _exit { get; set; }
        public Boolean _moved { get; set; }

        public Portal(Texture2D texture, Vector2 position, SpriteBatch spritebatch, Boolean exit)
            : base(texture, position, spritebatch)
        {
            _exit = exit;
            _moved = false;
        }
        
    }
}
