using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ColorLand
{
    class MenuWindowViewModel : ViewModelBase
    {
        private bool _randomSeed = true;
        private ObservableCollection<NewPlayer> _players = new ObservableCollection<NewPlayer>();

        public ObservableCollection<NewPlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private int BoardHeight
        {
            get;
            set;
        }

        private int BoardWidth
        {
            get;
            set;
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

        public string Seed
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
    }
}
