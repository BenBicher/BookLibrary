using BLL;
using System.Windows;

namespace BookLibraryProject
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void UpdateNewButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateNewPage newWin = new UpdateNewPage();
            newWin.Show();
            this.Close();
        }

        private void FindBookButton_Click(object sender, RoutedEventArgs e)
        {
            AllBooksPage newWin = new AllBooksPage();
            newWin.Show();
            this.Close();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            User.isLoged = false;
            MainWindow newWin = new MainWindow();
            newWin.Show();
            this.Close();
        }
    }
}
