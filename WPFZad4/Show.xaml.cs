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

namespace WPFZad4
{
    /// <summary>
    /// Logika interakcji dla klasy Show.xaml
    /// </summary>
    public partial class Show : Window
    {
        public User user { get; private set; }
        public Show(User User)
        {
            InitializeComponent();
            user = User;
            NameTextbox.Text = user.Name;
            SurnameTextbox.Text = user.Surname;
            EmailTextbox.Text = user.Email;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Name = NameTextbox.Text;
            (Owner as MainWindow)?.Refresh();
        }

        private void SurnameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Surname = SurnameTextbox.Text;
            (Owner as MainWindow)?.Refresh();
        }

        private void EmailTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Email = EmailTextbox.Text;
            (Owner as MainWindow)?.Refresh();
        }
        public void updateUser(User User)
        {
            if (User == null)
            {
                Close();
                return;
            }

            user = User;

            NameTextbox.Text = user.Name;
            SurnameTextbox.Text = user.Surname;
            EmailTextbox.Text = user.Email;
        }
    }
}
