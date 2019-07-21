using BLL;
using BLL.Model;
using System.Windows;

namespace BookLibraryProject
{
    public partial class ShowBookDetailsPage : Window
    {
        DataBase dataBase = DataBase.Instance;
        Item ChosenItem = DataBase.GetItem(AllBooksPage.Row.Title.ToString());

        public ShowBookDetailsPage()
        {
            InitializeComponent();
            TitleBlock.Text = "Title: " + ChosenItem.Title;
            AuthorBlock.Text = "Author: " + ChosenItem.GetAuthor();
            InStockBlock.Text = "In Stock: " + ChosenItem.NumInStok;
            ReleaseDateBlock.Text = "Release Date: " + ChosenItem.ReleaseDate;
            CategoryBlock.Text = "Category: " + ChosenItem.BaseCat;
            SubCategoryBlock.Text = "Sub Category: " + ChosenItem.InnerCat;
            EditionBlock.Text = "Edition: " + ChosenItem.GetEdition();
            if (User.isLoged == true)
            {
                LeaseButton.Visibility = Visibility.Visible;
                RemoveButton.Visibility = Visibility.Visible;
            }
        }

        private void LeaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChosenItem.NumInStok > 1)
            {
                ChosenItem.NumInStok--;
            }
            else return;

            dataBase.SaveItemData();

            AllBooksPage newWin = new AllBooksPage();
            newWin.Show();
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AllBooksPage newWin = new AllBooksPage();
            newWin.Show();
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.deleteItem(ChosenItem);

            dataBase.SaveItemData();

            AllBooksPage newWin = new AllBooksPage();
            newWin.Show();
            this.Close();
        }
    }
}
