using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            AddCards();
        }

        public void AddCards()
        {
            int rows = Mechanics.GetDifficultyint()+1;

            for (int c=0; c < 4; c++)
            {
                ColumnDefinition column = new ColumnDefinition();
                table.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < rows; i++)
            {
                RowDefinition row = new RowDefinition();
                table.RowDefinitions.Add(row);
                for (int c = 0; c < 4; c++)
                {
                    CardButton crd = new CardButton(c, i);
                    table.Children.Add(crd);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
