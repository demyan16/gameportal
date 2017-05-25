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
    /// Логика взаимодействия для WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        private Game _game;

        public WindowEdit(Game game)
        {
            InitializeComponent();

            _game = game;
            inputName.Text = _game.Name;
            inputDescription.Text = _game.Description;
            inputYear.Text = _game.Year.ToString();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            int year;
            if (int.TryParse(inputYear.Text, out year) && !string.IsNullOrEmpty(inputName.Text))
            {
                string name = inputName.Text;
                string description = inputDescription.Text;

                _game.Name = name;
                _game.Year = year;
                _game.Description = description;

                DialogResult = true;
            }
            else
                MessageBox.Show("Неправильно введен год или имя!");
        }
    }
}