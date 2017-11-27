using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using New_portal2D.Content;

namespace New_portal2D
{ 
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _wallTexture, _playerTexture;
        private Board _board;
        private Player _player;
        private Random _rnd = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 640;
        }

        protected override void LoadContent()
        {
            // Cria novo SpriteBatch, para desenhar texturas.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _wallTexture = Content.Load<Texture2D>("wall_2");
            _playerTexture = Content.Load<Texture2D>("player_2");

            _board = new Board(_spriteBatch, _wallTexture, 15, 10);
            _player = new Player(_playerTexture, new Vector2(80, 80), _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            base.Update(gameTime);
            CheckKeyboardAndReact();
        }

        private void CheckKeyboardAndReact()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F5)) { RestartGame(); }
            if (state.IsKeyDown(Keys.Escape)) { Exit(); }
        }

        private void RestartGame()
        {
            Board.CurrentBoard.CreateNewBoard();
            PutJumperInTopLeftCorner();
        }

        private void PutJumperInTopLeftCorner()
        {
            _player.Position = Vector2.One * 80;
            _player.Movement = Vector2.Zero;
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            base.Draw(gameTime);
            _board.Draw();
            _player.Draw();

            _spriteBatch.End();
        }
    }
}
