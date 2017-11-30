using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using New_Portal2D.Models;

namespace New_Portal2D.Controller
{
    class PlayerController
    {

        private void CheckKeyboardAndUpdateMovement(Player player)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A)) { player.Movement -= Vector2.UnitX; }
            if (keyboardState.IsKeyDown(Keys.D)) { player.Movement += Vector2.UnitX; }
            if (keyboardState.IsKeyDown(Keys.Space) && IsOnFirmGround(player)) { player.Movement = -Vector2.UnitY * 20; }
        }

        private void AffectWithGravity(Player player)
        {
            player.Movement += Vector2.UnitY * .65f;
        }


        private void SimulateFriction(Player player)
        {
            if (IsOnFirmGround(player)) { player.Movement -= player.Movement * Vector2.One * .08f; }
            else { player.Movement -= player.Movement * Vector2.One * .02f; }
        }

        private void MoveAsFarAsPossible(GameTime gameTime, Player player)
        {
            player.oldPosition = player.Position;
            UpdatePositionBasedOnMovement(gameTime, player);
            player.Position = Board.CurrentBoard.WherePlayerCanGetTo(player.oldPosition, player.Position, player.Bounds);
        }

        private void UpdatePositionBasedOnMovement(GameTime gameTime, Player player)
        {
            player.Position += player.Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
        }

        public bool IsOnFirmGround(Player player)
        {
            Rectangle onePixelLower = player.Bounds;
            onePixelLower.Offset(0, 1);
            return !Board.CurrentBoard.HasRoomForRectangle(onePixelLower);
        }

        private void StopMovingIfBlocked(Player player)
        {
            Vector2 lastMovement = player.Position - player.oldPosition;
            if (lastMovement.X == 0) { player.Movement *= Vector2.UnitY; }
            if (lastMovement.Y == 0) { player.Movement *= Vector2.UnitX; }
        }

        public void Update(GameTime gameTime, Player player)
        {
            CheckKeyboardAndUpdateMovement(player);
            AffectWithGravity(player);
            SimulateFriction(player);
            MoveAsFarAsPossible(gameTime, player);
            StopMovingIfBlocked(player);
        }


    }
}
