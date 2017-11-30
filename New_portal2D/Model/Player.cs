using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace New_Portal2D.Models
{
    class Player : Sprite
    {
        public Vector2 Movement { get; set; }
        public Vector2 oldPosition {get; set;}


        public Player(Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        { }
        
    }
}
