using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorLand
{
    public static class BoardGeneration
    {
        public static Tile[] GenerateBoard(int height, int width)
        {
            List<Tile> tiles = new List<Tile>();

            int curY = 0;
            while (curY < height)
            {
                for (int x = 0; x < width; x++)
                    tiles.Add(GenerateTile(x, curY, tiles));

                for (int i = 0; i < 2; i++)
                {
                    curY++;
                    tiles.Add(GenerateTile(width - 1, curY, tiles));
                }

                for (int x = width - 1; x > -1; x--)
                    tiles.Add(GenerateTile(x, curY, tiles));

                for (int i = 0; i < 2; i++)
                {
                    curY++;
                    tiles.Add(GenerateTile(0, curY, tiles));
                }
            }

            return tiles.ToArray();
        }

        public static Tile GenerateTile(int x, int y, List<Tile> tiles)
        {
            Tile tile = new Tile(x, y, Randomizer.GetRandomColor());
            if(tiles.Count > 1)
                if (tile.Color == tiles[tiles.Count - 1].Color)
                    tile.Color = Randomizer.GetRandomColor();
            return tile;
        }
    }
}
