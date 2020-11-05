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
    /// Logika interakcji dla klasy Modify.xaml
    /// </summary>
    public partial class Modify : Window
    {
        public User user { get; private set; }
        public Modify()
        {
            InitializeComponent();
            Title = "Dodaj nowego użytkownika";
        }
        public Modify(User user)
        {
            InitializeComponent();
            this.user = user;

            NameTextbox.Text = user.Name;
            SurnameTextbox.Text = user.Surname;
            EmailTextbox.Text = user.Email;

            Title = "Modyfikuj użytkownika";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if(user == null)
                user = new User();

            user.Name = NameTextbox.Text;
            user.Surname = SurnameTextbox.Text;
            user.Email = EmailTextbox.Text;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
