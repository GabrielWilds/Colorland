﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace ColorLand
{
    public class Game
    {
        private List<Player> _players = new List<Player>();
        public int _curTurn = 0;

        public Board Board
        {
            get;
            private set;
        }

        public Deck Deck
        {
            get;
            private set;
        }

        public List<Player> Players
        {
            get { return _players; }
            private set { _players = value; }
        }

        public Game(Board _board)
        {
            Board = _board;
            Deck = new Deck();
        }

        public int CurTurn
        {
            get { return _curTurn; }
            private set { _curTurn = value; }
        }

        public void AddHuman(string name)
        {
            Players.Add(new LocalPlayer(name, Players.Count, MakePlayerSprite(Players.Count + 1)));
        }

        public void AddBot(string name)
        {
            Players.Add(new BotPlayer(name, Players.Count, MakePlayerSprite(Players.Count + 1)));
        }

        public void PopulateDemoGame()
        {
            AddHuman("Player One");
            AddBot("Player Two");
        }

        public void Start(MainWindow window)
        {
            //PopulateDemoGame();
            if (Players[CurTurn] is BotPlayer)
                TakeTurn(window);
        }

        public void TakeTurn(MainWindow window)
        {
            while (true)
            {
                MakeTurn(Players[CurTurn]);
                CheckVictory(Players[CurTurn], window);
                Players[CurTurn].CurPlayer = "";

                CurTurn++;
                if (CurTurn == Players.Count)
                    CurTurn = 0;

                Players[CurTurn].CurPlayer = "<";

                if (!(Players[CurTurn] is BotPlayer))
                    break;
            }
        }

        public void CheckVictory(Player player, MainWindow window)
        {
            if (player.Position == Board.Tiles.Length - 1)
            {
                MessageBox.Show("Player " + player.Name + " has won the game!", "GAME OVER");
                window.Close();
            }
        }

        public void MakeTurn(Player player)
        {
            Board.LocateSprite(player);
            Card card = Deck.DrawCard();
            if(player is LocalPlayer)
                MessageBox.Show("Your Card is: " + card.Color.ToString());

            player.Position = player.Position + Board.GetMoveDistance(player, card);
            Board.LocateSprite(player);
        }

        protected Rectangle MakePlayerSprite(int index)
        {
            GeometryDrawing aDrawing = new GeometryDrawing();
            EllipseGeometry ellipse = new EllipseGeometry();
            ellipse.RadiusX = Board.TileHeight - 2;
            ellipse.RadiusY = Board.TileWidth - 2;
            aDrawing.Geometry = ellipse;
            aDrawing.Brush = Brushes.White;

            DrawingBrush brush = new DrawingBrush(aDrawing);
            StackPanel panel = new StackPanel();
            TextBlock text = new TextBlock();
            text.Text = index.ToString();
            text.TextAlignment = System.Windows.TextAlignment.Center;
            //FontSizeConverter fSizeConverter = new FontSizeConverter();
            //text.FontSize = (double)fSizeConverter.ConvertFromString("6pt");
            panel.Background = brush;
            panel.Children.Add(text);

            VisualBrush vbrush = new VisualBrush();
            vbrush.Visual = panel;
            Rectangle rect = new Rectangle();
            rect.Height = Board.TileHeight - 2;
            rect.Width = Board.TileWidth - 2;
            rect.Fill = vbrush;
            return rect;
        }

        public void DrawPlayers()
        {
            for (int i = 0; i < Players.Count; i++)
                Board.DrawPlayer(Players[i]);
        }
    }
}
