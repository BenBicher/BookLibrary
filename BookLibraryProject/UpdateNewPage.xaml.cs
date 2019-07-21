using BLL;
using BLL.Model;
using System;
using System.Windows;

namespace BookLibraryProject
{
    public partial class UpdateNewPage : Window
    {
        DataBase dataBase = DataBase.Instance;
        public UpdateNewPage()
        {
            InitializeComponent();
            CategoryList.ItemsSource = Enum.GetValues(typeof(BaseCategory));
            SubCategoryList.ItemsSource = Enum.GetValues(typeof(InnerCategory));
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bool? isBook = _BookRadio.IsChecked;
            bool? isJournal = _JournalRadio.IsChecked;
            string title = TitleBox.Text;
            string author = AuthorBox.Text;

            DateTime? Date = ConvertStringsToDate(ReleaseDateBox_Day.Text, ReleaseDateBox_Month.Text, ReleaseDateBox_Year.Text);
            if (Date == null)
            {
                //TODO need to show Error message
            }
            int inStock = 0;
            if (InStockBox.Text != null && InStockBox.Text != "")
            {
                bool isParsed = int.TryParse(InStockBox.Text, out inStock);
                if (isParsed != true) return;
            }

            BaseCategory category = (BaseCategory)CategoryList.SelectedItem;
            InnerCategory subCategory = (InnerCategory)SubCategoryList.SelectedItem;
            string edition = EditionBox.Text;
            Item item = null;
            if (isBook.Value)
            {
                item = new Book(title, author, inStock, Date.Value, category, subCategory);
            }
            else if (isJournal.Value)
            {
                item = new Jouranl(title, inStock, Date.Value, edition);
            }

            dataBase.AddItem(item);

            AllBooksPage allBooksPage = new AllBooksPage();
            allBooksPage.Show();
            this.Close();
        }

        private DateTime? ConvertStringsToDate(string day, string month, string year)
        {
            if (day == null || month == null || year == null) return null;
            if (day == "" || month == "" || year == "") return null;
            int dateDay, dateMonth, dateYear;

            if (!int.TryParse(day, out dateDay) ||
               !int.TryParse(month, out dateMonth) ||
               !int.TryParse(year, out dateYear))
                return null;

            DateTime date = new DateTime(dateYear, dateMonth, dateDay);
            return date;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Admin newWin = new Admin();
            newWin.Show();
            this.Close();
        }

        private void _JournalRadio_Checked(object sender, RoutedEventArgs e)
        {
            AuthorBlok.Visibility = Visibility.Hidden;
            AuthorBox.Visibility = Visibility.Hidden;

            EditionBlock.Visibility = Visibility.Visible;
            EditionBox.Visibility = Visibility.Visible;
        }

        private void _BookRadio_Checked(object sender, RoutedEventArgs e)
        {
            AuthorBlok.Visibility = Visibility.Visible;
            AuthorBox.Visibility = Visibility.Visible;

            EditionBlock.Visibility = Visibility.Hidden;
            EditionBox.Visibility = Visibility.Hidden;
        }
    }
}

