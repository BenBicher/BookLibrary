using BLL;
using BLL.Model;
using System.Windows;

namespace BookLibraryProject
{
    public partial class RegisterPage : Window
    {
        DataBase dataBase = DataBase.Instance;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterNewButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = RegisterFirstNameBox.Text;
            string lastName = RegisterLastNameBox.Text;
            string userName = RegisterUserNameBox.Text.ToLower();
            string password = RegisterPasswordBox.Password.ToLower();
            string confirmPassword = RegisterConfirmPasswordBox.Password.ToLower();
            //validate that the passwords are equals
            if (password != confirmPassword) return;

            User user = new User(firstName, lastName, userName, password);

            //Save The User To Data
            dataBase.AddUser(user);

            MainWindow newWin = new MainWindow();
            newWin.Show();
            this.Close();
        }
    }
}
