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

namespace WPFZad4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            UsersList.Items.Refresh();
            foreach (var window in OwnedWindows)
            {
                Show s = window as Show;
                if (s != null)
                    s.updateUser(UsersList.SelectedItem as User);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Modify modifyWindow = new Modify();
            if (modifyWindow.ShowDialog() == true)
            {
                UsersList.Items.Add(modifyWindow.user);
                UsersList.Items.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć obiekt?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                UsersList.Items.Remove(UsersList.SelectedItem);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Modify modifyWindow = new Modify(UsersList.SelectedItem as User);
            if (modifyWindow.ShowDialog() == true)
            {
                UsersList.Items.Refresh();
                Refresh();
            }
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Show showWindow = new Show(UsersList.SelectedItem as User);
            showWindow.Owner = this;
            showWindow.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var window in OwnedWindows)
            {
                Show s = window as Show;
                if (s != null)
                    s.updateUser(UsersList.SelectedItem as User);
            }
            if (UsersList.SelectedIndex != -1)
            {
                EditButton.IsEnabled = true;
                RemoveButton.IsEnabled = true;
                ShowButton.IsEnabled = true;
            }
            else
            {
                EditButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
                ShowButton.IsEnabled = false;
            }
        }
    }
}
