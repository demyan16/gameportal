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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GamePortal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> _allGames = new List<Game>();
        string file = "../../games.txt";

        public MainWindow()
        {
            InitializeComponent();
            _allGames = Load();
            gamesList.ItemsSource = _allGames;
        }
        
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd window = new WindowAdd();
            if (window.ShowDialog().Value)
            {
                _allGames.Add(window.NewGame);
                Save();
                gamesList.Items.Refresh();
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex != -1)
            {
                if (gamesList.SelectedItem is Game)
                {
                    Game selected = (Game)gamesList.SelectedItem;
                    WindowEdit windowEdit = new WindowEdit(selected);
                    if (windowEdit.ShowDialog().Value)
                    {
                        Save();
                        gamesList.Items.Refresh();
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex != -1)
            {
                if (gamesList.SelectedItem is Game)
                {
                    Game selected = (Game)gamesList.SelectedItem;
                    if (MessageBox.Show(
                        "Вы уверены, что хотите удалить данную игру?",
                        "Удаление",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        _allGames.Remove(selected);
                        Save();
                        gamesList.Items.Refresh();
                    }
                }
            }
        }

        private void gamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = gamesList.SelectedIndex != -1;
            buttonEdit.IsEnabled = isSelected;
            buttonDelete.IsEnabled = isSelected;
        }

        private void Save()
        {
            StreamWriter sw = new StreamWriter(file);
            foreach (Game game in _allGames)
            {
                sw.WriteLine($"{game.Name}թ{game.Year}թ{game.Description}");
            }
            sw.Close();
        }

        private List<Game> Load()
        {
            List<Game> gamesFromFile = new List<Game>();

            try
            {
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string[] parts = sr.ReadLine().Split('թ');
                        Game game = new Game(parts[0], parts[2], int.Parse(parts[1]));
                        gamesFromFile.Add(game);
                    }
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return gamesFromFile;
        }

        private void inputSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Game> search = new List<Game>();

            if (inputSearch.Text == "")
            {
                search = _allGames;
            }
            else
            {
                foreach (Game game in _allGames)
                {
                    if (game.Name.Contains(inputSearch.Text))
                    {
                        search.Add(game);
                    }
                }
            }

            gamesList.ItemsSource = search;
        }
    }
}
