using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;

namespace ColorLand
{
    class MenuWindowViewModel : ViewModelBase
    {
        private bool _randomSeed = true;
        private ObservableCollection<NewPlayer> _players = new ObservableCollection<NewPlayer>();
        public int _height = 0;
        public int _width = 0;

        public ObservableCollection<NewPlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private int BoardHeight
        {
            get { return _height; }
            set { _height = value; }
        }

        private int BoardWidth
        {
            get { return _width; }
            set { _width = value; }
        }

        public bool IsRandomSeed
        {
            get { return _randomSeed; }
            set { _randomSeed = value; RaisePropertyChanged("IsRandomSeed"); RaisePropertyChanged("IsCustomSeed"); }
        }

        public bool IsCustomSeed
        {
            get
            {
                if (!IsRandomSeed)
                    return true;
                else
                    return false;
            }
        }

        public int Seed
        {
            get;
            set;
        }

        public MenuWindowViewModel()
        {
            AddNewPlayer();
        }

        public void AddNewPlayer()
        {
            Players.Add(new NewPlayer());
        }

        public void SetBoardToSmall()
        {
            BoardHeight = 15;
            BoardWidth = 20;
        }

        public void SetBoardToNormal()
        {
            BoardHeight = 20;
            BoardWidth = 30;
        }

        public void SetBoardToLarge()
        {
            BoardHeight = 30;
            BoardWidth = 45;
        }

        public void SetBoardToHuge()
        {
            BoardHeight = 40;
            BoardWidth = 60;
        }

        public void StartGameCheck(MenuWindow window)
        {
            if (Players.Count < 2)
                MessageBox.Show("You need at least two players.");
            else if (BoardWidth == 0)
                MessageBox.Show("You need to select a board size");
            else
                StartGame(window);
        }

        public void StartGame(MenuWindow window)
        {
            if(!IsRandomSeed)
                Randomizer.SetSeed(Seed);

            Game game = new Game(new Board(BoardHeight, BoardWidth, (BoardHeight * 20), (BoardWidth * 20)));

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == null)
                    Players[i].Name = GetRandomName(Players[i].IsBot);

                if (Players[i].IsBot)
                    game.AddBot(Players[i].Name);
                else
                    game.AddHuman(Players[i].Name);
            }

            MainWindow mainWindow = new MainWindow(game, (BoardHeight * 20), (BoardWidth * 20));
            mainWindow.Show();
            window.Close();
        }

        public string GetRandomName(bool IsBot)
        {
            string[] names = new string[] { "John", "Joan", "Jake", "Jackson", "Johnny", "Julie", "Julia", "Janet", "James", "Johnathan", "Jackie", "Jorge", "Joe" };
            string name = names[Randomizer.GetRandomNumber(names.Length - 1)];
            if (IsBot)
                name = "Bot_" + name;

            return name;
        }
    }
}
