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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;
            FormatComboBox.ItemsSource = Enum.GetValues(typeof(BookFormat)).Cast<BookFormat>();
        }

        public static readonly DependencyProperty StateProperty =
        DependencyProperty.Register("State", typeof(Book), typeof(UserControl1),
        new PropertyMetadata(default(Book)));

        public Book State
        {
            get { return (Book)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (State != null)
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
        }
    }
}
