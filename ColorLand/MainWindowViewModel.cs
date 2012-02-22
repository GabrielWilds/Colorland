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

        public int CanvasHeight
        {
            get;
            set;
        }

        public int CanvasWidth
        {
            get;
            set;
        }

        public int WindowHeight
        {
            get { return CanvasHeight + 150; }
        }

        public int WindowWidth
        {
            get { return CanvasWidth + 200; }
        }

        public MainWindowViewModel(Game game, int canvasHeight, int canvasWidth)
        {
            _game = game;
            CanvasHeight = canvasHeight;
            CanvasWidth = canvasWidth;
        }

        public void TakeTurn(MainWindow window)
        {
            ColorLandGame.TakeTurn(window);
            OnPropertyChanged("ColorLandGame");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
