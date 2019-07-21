using BLL;
using BLL.Model;
using System.Windows;

namespace BookLibraryProject
{
    public partial class MainWindow : Window
    {
        DataBase dataBase = DataBase.Instance;
        public MainWindow()
        {
            dataBase.ReadItemData();
            dataBase.ReadUsersData();
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if ((_IDBox.Text.ToLower() != null) && (_password.Password != null) && (_IDBox.Text != "") && (_password.Password != ""))
            {
                for (int i = 0; i < DataBase.Users.Count; i++)
                {
                    if (_IDBox.Text.ToLower() == DataBase.Users[i].UserName.ToLower())
                    {
                        if (_password.Password.ToLower() == DataBase.Users[i].Password.ToLower())
                        {
                            User.isLoged = true;
                            Admin adminWin = new Admin();
                            adminWin.Show();
                            this.Close();
                        }
                    }
                }
                return;
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            AllBooksPage newWin = new AllBooksPage();
            newWin.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage newWin = new RegisterPage();
            newWin.Show();
            this.Close();
        }
    }
}
