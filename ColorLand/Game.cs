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
    class Game
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

        public Game(Board _board, Deck _deck)
        {
            Board = _board;
            Deck = _deck;
        }
        
        public int CurTurn
        {
            get { return _curTurn; }
            private set { _curTurn = value; }
        }

        public void AddHuman(string name)
        {

            DrawingBrush brush = new DrawingBrush();
            Players.Add(new LocalPlayer(name, Players.Count, MakePlayerSprite(Players.Count + 1)));
        }

        public void AddBot(string name)
        {
            Players.Add(new BotPlayer(name, Players.Count, MakePlayerSprite(Players.Count + 1)));
        }

        public void PopulateDemoGame()
        {
            AddHuman("Player One");
            AddHuman("Player Two");
        }

        public void Start()
        {
        }

        public void MakeTurn()
        {
            Card card = Deck.DrawCard();
            MessageBox.Show("Your Card is: " + card.Color.ToString());
            bool foundDestination = false;
            int spacesMoved = 1;
            while (!foundDestination)
            {
                if (Board.Tiles[Players[CurTurn].Position + spacesMoved].Color == card.Color || Players[CurTurn].Position + spacesMoved == Board.Tiles.Length)
                    foundDestination = true;
                else
                    spacesMoved++;
            }
            Players[CurTurn].Position = Players[CurTurn].Position + spacesMoved;
            Board.LocateSprite(Players[CurTurn]);
            CurTurn++;
            if (CurTurn == Players.Count)
                CurTurn = 0;
            if (Players[CurTurn] is BotPlayer)
                MakeTurn();
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
            for(int i = 0; i < Players.Count; i++)
                Board.DrawPlayer(Players[i]);
        }
    }
}