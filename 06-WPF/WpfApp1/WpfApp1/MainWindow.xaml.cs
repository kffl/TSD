using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    public class MyClass
    {

    }
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private ObservableCollection<Book> BooksCollection = new ObservableCollection<Book>(MyBookCollection.GetMyCollection());

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            InitializeComponent();
            MyListView.ItemsSource = BooksCollection;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FormatComboBox.ItemsSource = Enum.GetValues(typeof(BookFormat)).Cast<BookFormat>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BooksCollection.Add(new Book());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete selected book?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == DeleteButton)
                BooksCollection.Remove((Book)MyListView.SelectedItem);
        }
    }
}
