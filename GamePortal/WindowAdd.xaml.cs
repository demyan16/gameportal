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

namespace GamePortal
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
        }

        private Game _newGame;

        public Game NewGame
        {
            get
            {
                return _newGame;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int year;
            if (int.TryParse(inputYear.Text, out year) && !string.IsNullOrEmpty(inputName.Text))
            {
                string name = inputName.Text;
                string description = inputDescription.Text;
                _newGame = new Game(name, description, year);
                DialogResult = true;
            }
            else
                MessageBox.Show("Неправильно введен год или имя!");
        }
    }
}