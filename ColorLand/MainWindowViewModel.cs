using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;

namespace ColorLand
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Game _game;
        public Game ColorLandGame
        {
            get { return _game; }
            private set { _game = value; OnPropertyChanged("ColorLandGame"); }
        }

        public MainWindowViewModel(int boardHeight, int boardWidth)
        {
            Board board = new Board(boardHeight, boardWidth);
            ColorLandGame = new Game(board, new Deck());
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
