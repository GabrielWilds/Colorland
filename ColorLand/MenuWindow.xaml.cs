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
using System.Windows.Shapes;

namespace ColorLand
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            this.DataContext = new MenuWindowViewModel();
            InitializeComponent();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            ((MenuWindowViewModel)this.DataContext).AddNewPlayer();
        }

        private void SmallBoard(object sender, RoutedEventArgs e)
        {
            ((MenuWindowViewModel)this.DataContext).SetBoardToSmall();
        }

        private void NormalBoard(object sender, RoutedEventArgs e)
        {
            ((MenuWindowViewModel)this.DataContext).SetBoardToNormal();
        }

        private void LargeBoard(object sender, RoutedEventArgs e)
        {
            ((MenuWindowViewModel)this.DataContext).SetBoardToLarge();
        }

        private void HugeBoard(object sender, RoutedEventArgs e)
        {
            ((MenuWindowViewModel)this.DataContext).SetBoardToHuge();
        }
    }
}
