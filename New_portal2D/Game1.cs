using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using New_Portal2D.Models;
using New_Portal2D.Controller;

namespace New_portal2D
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _wallTexture, _playerTexture, _backTexture, _portal_1Texture, _portal_2Texture;
        private Board _board, _back;
        private Player _player;
        private Portal entryPortal, exitPortal;
        private PortalController pc;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Define o tamanho da tela
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 640;
            // Tenta centralizar a tela
            this.Window.Position = new Point(200, 20);
        }

        // === LOAD ===
        protected override void LoadContent()
        {
            MouseState mouseState = Mouse.GetState();
            // Cria novo SpriteBatch, para desenhar texturas
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Desenha texturas do player e parede
            _wallTexture = Content.Load<Texture2D>("wall_2");
            _playerTexture = Content.Load<Texture2D>("player_2");
            _backTexture = Content.Load<Texture2D>("back");
            _portal_2Texture = Content.Load<Texture2D>("portal_2");
            _portal_1Texture = Content.Load<Texture2D>("portal_1");
            //_sprite = new Sprite(_playerTexture, new Vector2(mouseState.X, mouseState.Y), _spriteBatch);
            _back = new Board(_spriteBatch, _backTexture, 15, 10, true);
            _board = new Board(_spriteBatch, _wallTexture, 15, 10);
            entryPortal = new Portal(_portal_2Texture, new Vector2(192, 512), _spriteBatch, false);
            exitPortal = new Portal(_portal_1Texture, new Vector2(640, 64), _spriteBatch, true);
            _player = new Player(_playerTexture, new Vector2(80, 80), _spriteBatch);
            pc = new PortalController();
        }

        // === UPDATE ===
        protected override void Update(GameTime gameTime)
        {
            // Player update
            _player.Update(gameTime);
            pc.CollisionWithPlayer(gameTime, _player, entryPortal, exitPortal);
            base.Update(gameTime);
            CheckKeyboard();
        }

        // Atalhos do teclado
        private void CheckKeyboard()
        {
            KeyboardState state = Keyboard.GetState();
            IsMouseVisible = true;
            if (state.IsKeyDown(Keys.R)) { RestartGame(); }
            if (state.IsKeyDown(Keys.Escape)) { Exit(); }
        }

        // RestartGame
        private void RestartGame()
        {
            Board.CurrentBoard.CreateNewBoard();
            PutPlayerInTopLeftCorner();
        }

        // Colocar jogador no canto
        private void PutPlayerInTopLeftCorner()
        {
            _player.Position = Vector2.One * 80;
            _player.Movement = Vector2.Zero;
        }

        // === DRAW ===
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            base.Draw(gameTime);
            //_sprite.Draw();
            _back.Draw();
            _board.Draw();
            entryPortal.Draw();
            exitPortal.Draw();
            _player.Draw();
            _spriteBatch.End();
        }
    }
}
