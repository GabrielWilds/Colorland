using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using WPFCanvas = System.Windows.Controls.Canvas;
using System.Windows.Shapes;

namespace ColorLand
{
    public class Board
    {
        public Tile[] Tiles
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public WPFCanvas Canvas
        {
            get;
            private set;
        }

        public int TileHeight
        {
            get;
            set;
        }

        public int TileWidth
        {
            get;
            set;
        }

        public Board(int height, int width)
        {
            Height = height;
            Width = width;        
            Tiles = BoardGeneration.GenerateBoard(Height, Width);
        }

        public void DrawBoard(WPFCanvas canvas)
        {
            Canvas = canvas;
            TileHeight = (int)(Canvas.Height / Height);
            TileWidth = (int)(Canvas.Width / Width);

            for (int i = 0; i < Tiles.Length; i++)
            {
                int drawStartHeight = (int)(TileHeight * Tiles[i].GridY);
                int drawStartWidth = (int)(TileWidth * Tiles[i].GridX);
                Rectangle rect = new Rectangle();
                rect.Height = TileHeight;
                rect.Width = TileWidth;
                rect.Fill = GetColorFromGameColors(Tiles[i].Color);
                WPFCanvas.SetTop(rect, drawStartHeight);
                WPFCanvas.SetLeft(rect, drawStartWidth);
                Tiles[i].Rectangle = rect;
                Canvas.Children.Add(Tiles[i].Rectangle);
            }
        }

        public void DrawPlayer(Player player)
        {
            LocateSprite(player);
            Canvas.Children.Add(player.Sprite);
        }

        public void LocateSprite(Player player)
        {
            int startHeight = (int)(TileHeight * Tiles[player.Position].GridY);
            int startWidth = (int)(TileWidth * Tiles[player.Position].GridX);
            WPFCanvas.SetTop(player.Sprite, startHeight + 1);
            WPFCanvas.SetLeft(player.Sprite, startWidth + 1);
        }

        public int GetMoveDistance(Player player, Card card)
        {
            bool foundDestination = false;
            int spacesMoved = 1;
            while (!foundDestination)
            {
                if (Tiles[player.Position + spacesMoved].Color == card.Color || player.Position + spacesMoved == Tiles.Length - 1)
                    foundDestination = true;
                else
                    spacesMoved++;
            }

            return spacesMoved;
        }

        public Brush GetColorFromGameColors(GameColors color)
        {
            switch (color)
            {
                case GameColors.Blue:
                    return Brushes.Blue;
                case GameColors.Brown:
                    return Brushes.Brown;
                case GameColors.Green:
                    return Brushes.Green;
                case GameColors.Purple:
                    return Brushes.Purple;
                case GameColors.Red:
                    return Brushes.Red;
                case GameColors.Yellow:
                    return Brushes.Yellow;
                default:
                    throw new ArgumentException("Invalid color " + color.ToString());
            }
        }

    }
}
