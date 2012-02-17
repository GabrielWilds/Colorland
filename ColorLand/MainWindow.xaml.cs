using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorLand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Canvas GameCanvas
        {
            get { return BoardCanvas; }
            set { BoardCanvas = value; }
        }

        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel(20, 30);
            InitializeComponent();
            ((MainWindowViewModel)this.DataContext).ColorLandGame.Board.DrawBoard(GameCanvas);
            ((MainWindowViewModel)this.DataContext).ColorLandGame.Start(this);
            ((MainWindowViewModel)this.DataContext).ColorLandGame.DrawPlayers();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Board board = new Board(10, 15, BoardCanvas);
            
        }

        public void DrawBoard(Board board, Canvas canvas)
        {
            int tilePixelHeight = (int)(canvas.Height / board.Height);
            int tilePixelWidth = (int)(canvas.Width / board.Width);
            for (int i = 0; i < board.Tiles.Length; i++)
            {
                int drawStartHeight = (int)(tilePixelHeight * board.Tiles[i].GridY);
                int drawStartWidth = (int)(tilePixelWidth * board.Tiles[i].GridX);
                Rectangle rect = new Rectangle();
                rect.Height = tilePixelHeight;
                rect.Width = tilePixelWidth;
                rect.Fill = GetColorFromGameColors(board.Tiles[i].Color);
                Canvas.SetTop(rect, drawStartHeight);
                Canvas.SetLeft(rect, drawStartWidth);
                board.Tiles[i].Rectangle = rect;
                canvas.Children.Add(board.Tiles[i].Rectangle);
            }
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

        private void DrawCard(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)this.DataContext).ColorLandGame.TakeTurn(this);
        }
    }
}
