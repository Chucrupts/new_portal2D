using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace New_Portal2D.Models
{
    class Tile : Sprite
    {
        public bool IsBlocked { get; set; }

        public Tile(Texture2D texture, Vector2 position, SpriteBatch batch, bool isBlocked)
            : base(texture, position, batch)
        {
            IsBlocked = isBlocked;
        }

        public override void Draw()
        {
            if (IsBlocked)
            {
                base.Draw();
            }
        }
    }
}
