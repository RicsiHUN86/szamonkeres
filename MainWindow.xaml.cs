using System.Windows;
using szamonkeres;

namespace szamonkeres
{
    public partial class MainWindow : Window
    {
        int selectedId = -1;

        Read read = new Read();
        Create create = new Create();
        Update update = new Update();
        Delete delete = new Delete();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgBooks.ItemsSource = null;
            dgBooks.ItemsSource = read.GetBooks();
        }

        private void dgBooks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem is Books book)
            {
                selectedId = book.Id;

                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtYear.Text = book.Year.ToString();
                txtPrice.Text = book.Price.ToString();
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            create.CreateBook(
                txtTitle.Text,
                txtAuthor.Text,
                int.Parse(txtYear.Text),
                int.Parse(txtPrice.Text)
            );

            LoadData();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != -1)
            {
                update.UpdateBook(
                    selectedId,
                    txtTitle.Text,
                    txtAuthor.Text,
                    int.Parse(txtYear.Text),
                    int.Parse(txtPrice.Text)
                );

                LoadData();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != -1)
            {
                delete.DeleteBook(selectedId);
                LoadData();
            }
        }
    }
}