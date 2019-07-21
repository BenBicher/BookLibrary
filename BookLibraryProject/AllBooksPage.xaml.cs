using BLL;
using BLL.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookLibraryProject
{
    public partial class AllBooksPage : Window
    {
        public static Item Row = null;
        DataBase dataBase = DataBase.Instance;
        public AllBooksPage()
        {
            InitializeComponent();
            BooksDataGrid.ItemsSource = DataBase.Items;
        }

        private void BooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem == null) return;
            Row = (Item)BooksDataGrid.SelectedItem;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchData = SearchBox.Text;
            BooksDataGrid.ItemsSource = DataBase.Items.Where(i => i.Title.Contains(searchData));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowBookDetailsPage newWin = new ShowBookDetailsPage();
            newWin.Show();
            this.Close();
        }
    }
}
