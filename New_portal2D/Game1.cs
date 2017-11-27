using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using New_portal2D.Content;
using Portal2D.Models;

namespace New_portal2D
{ 
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _wallTexture, _playerTexture, _portalTexture;
        private Board _board;
        private Player _player;
        private Portal entryPortal, exitPortal;
        //private Random _rnd = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Define o tamanho da tela
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 640;
            // Tenta centralizar a tela
            this.Window.Position = new Point(800, 400);
        }

        // === LOAD ===
        protected override void LoadContent()
        {
            // Cria novo SpriteBatch, para desenhar texturas
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Desenha texturas do player, parede e portal
            _wallTexture = Content.Load<Texture2D>("wall_2");
            _playerTexture = Content.Load<Texture2D>("player_2");
            _board = new Board(_spriteBatch, _wallTexture, 15, 10);
            _player = new Player(_playerTexture, new Vector2(80, 80), _spriteBatch);
            _portalTexture = Content.Load<Texture2D>("portal");
            entryPortal = new Portal(_portalTexture, new Vector2(-900, -900), _spriteBatch);
            exitPortal = new Portal(_portalTexture, new Vector2(-800, -800), _spriteBatch);
            entryPortal.Initialize(false);
            exitPortal.Initialize(true);
        }

        // === UPDATE ===
        protected override void Update(GameTime gameTime)
        {
            // Player update
            _player.Update(gameTime);
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
            _board.Draw();
            _player.Draw();
            _spriteBatch.End();
        }
    }
}
