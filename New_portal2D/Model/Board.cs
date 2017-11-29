using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using New_portal2D.Util;

namespace New_Portal2D.Models
{
    class Board
    {
        public Tile[,] Tiles { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D TileTexture { get; set; }
        private SpriteBatch SpriteBatch { get; set; }
        private Random _rnd = new Random();
        public static Board CurrentBoard { get; private set; }

        public Board(SpriteBatch spritebatch, Texture2D tileTexture, int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            TileTexture = tileTexture;
            SpriteBatch = spritebatch;
            Tiles = new Tile[Columns, Rows];
            CreateNewBoard();
            Board.CurrentBoard = this;
        }

        // Construtor do background a otimizar
        public Board(SpriteBatch spritebatch, Texture2D tileTexture, int columns, int rows, Boolean isBack)
        {
            Columns = columns;
            Rows = rows;
            TileTexture = tileTexture;
            SpriteBatch = spritebatch;
            Tiles = new Tile[Columns, Rows];
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Vector2 tilePosition =
                        new Vector2(x * tileTexture.Width, y * tileTexture.Height);
                    Tiles[x, y] =
                        new Tile(tileTexture, tilePosition, spritebatch, true);
                }
            }
        }

        // Cria novo board
        public void CreateNewBoard()
        {
            TilesAndBlocksRandom();
            SetBorder();
            SetTilesUnblocked();
        }

        // Cria tiles vazios
        private void SetTilesUnblocked()
        {
            //Tile Player
            Tiles[1, 1].IsBlocked = false;
            Tiles[2, 1].IsBlocked = false;
            Tiles[1, 2].IsBlocked = false;
            Tiles[2, 2].IsBlocked = false;

            Tiles[3, 8].IsBlocked = false; // Tile entryPortal
            Tiles[10, 1].IsBlocked = false; // Tile exitPortal
            Tiles[2, 7].IsBlocked = false;  // 5 Tiles em volta do entryPortal
            Tiles[2, 8].IsBlocked = false;
            Tiles[3, 7].IsBlocked = false;
            Tiles[4, 7].IsBlocked = false;
            Tiles[4, 8].IsBlocked = false;
            Tiles[9, 1].IsBlocked = false; //5 Tiles em volta do exitPortal
            Tiles[9, 2].IsBlocked = false;
            Tiles[10, 2].IsBlocked = false;
            Tiles[11, 1].IsBlocked = false;
            Tiles[11, 2].IsBlocked = false;
        }

        // Randomizando
        private void TilesAndBlocksRandom()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Vector2 tilePosition = new Vector2(x * TileTexture.Width, y * TileTexture.Height);
                    Tiles[x, y] = new Tile(TileTexture, tilePosition, SpriteBatch, _rnd.Next(5) == 0);
                }
            }
        }

        // Setando bordas
        private void SetBorder()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    if (x == 0 || x == Columns - 1 || y == 0 || y == Rows - 1)
                    { Tiles[x, y].IsBlocked = true; }
                }
            }
        }
        // === DRAW ===
        public void Draw()
        {
            foreach (var tile in Tiles)
            {
                tile.Draw();
            }
        }

        // Retorna falso se existe colisão entre obj parametro e tiles.isblocked=true
        public bool HasRoomForRectangle(Rectangle rectangleToCheck)
        {
            foreach (var tile in Tiles)
            {
                if (tile.IsBlocked && tile.Bounds.Intersects(rectangleToCheck))
                {
                    return false;
                }
            }
            return true;
        }

        // Até onde o player pode ir
        public Vector2 WherePlayerCanGetTo(Vector2 originalPosition, Vector2 destination, Rectangle boundingRectangle)
        {
            MovementWrapper move = new MovementWrapper(originalPosition, destination, boundingRectangle);

            for (int i = 1; i <= move.NumberOfStepsToBreakMovementInto; i++)
            {
                Vector2 positionToTry = originalPosition + move.OneStep * i;
                Rectangle newBoundary = CreateRectangleAtPosition(positionToTry, boundingRectangle.Width, boundingRectangle.Height);
                if (HasRoomForRectangle(newBoundary)) { move.FurthestAvailableLocationSoFar = positionToTry; }
                else
                {
                    if (move.IsDiagonalMove)
                    {
                        move.FurthestAvailableLocationSoFar = CheckPossibleNonDiagonalMovement(move, i);
                    }
                    break;
                }
            }
            return move.FurthestAvailableLocationSoFar;
        }

        private Rectangle CreateRectangleAtPosition(Vector2 positionToTry, int width, int height)
        {
            return new Rectangle((int)positionToTry.X, (int)positionToTry.Y, width, height);
        }

        private Vector2 CheckPossibleNonDiagonalMovement(MovementWrapper wrapper, int i)
        {
            if (wrapper.IsDiagonalMove)
            {
                int stepsLeft = wrapper.NumberOfStepsToBreakMovementInto - (i - 1);

                Vector2 remainingHorizontalMovement = wrapper.OneStep.X * Vector2.UnitX * stepsLeft;
                wrapper.FurthestAvailableLocationSoFar =
                    WherePlayerCanGetTo(wrapper.FurthestAvailableLocationSoFar, wrapper.FurthestAvailableLocationSoFar + remainingHorizontalMovement, wrapper.BoundingRectangle);

                Vector2 remainingVerticalMovement = wrapper.OneStep.Y * Vector2.UnitY * stepsLeft;
                wrapper.FurthestAvailableLocationSoFar =
                    WherePlayerCanGetTo(wrapper.FurthestAvailableLocationSoFar, wrapper.FurthestAvailableLocationSoFar + remainingVerticalMovement, wrapper.BoundingRectangle);
            }

            return wrapper.FurthestAvailableLocationSoFar;
        }
    }
}

