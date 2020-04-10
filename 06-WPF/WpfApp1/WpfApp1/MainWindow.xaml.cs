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
            InitializeComponent();
            MyListView.ItemsSource = BooksCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BooksCollection.Add(new Book());
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == DetailsUserControl.DeleteButton)
                BooksCollection.Remove((Book)MyListView.SelectedItem);
        }

        public static RoutedCommand MyCommand = new RoutedCommand();

        void CustomRoutedCommand_Loaded(object sender, RoutedEventArgs e)
        {
            MyCommand.InputGestures.Add(new KeyGesture(Key.Delete));
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BooksCollection.Remove((Book)MyListView.SelectedItem);
        }
    }
}
