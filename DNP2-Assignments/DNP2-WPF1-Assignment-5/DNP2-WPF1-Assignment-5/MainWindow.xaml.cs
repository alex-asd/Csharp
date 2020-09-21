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

namespace DNP2_WPF1_Ass5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MultiMediaList list;
        public MainWindow()
        {
            InitializeComponent();
            list = new MultiMediaList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomInputDialog dialog = new CustomInputDialog();
            dialog.ShowDialog();
            if (CustomInputDialog._Type == null)
                return;
            var type = CustomInputDialog._Type == 0 ? Multimedia.MediaType.CD : Multimedia.MediaType.DVD;
            var media = new Multimedia(CustomInputDialog._Title, CustomInputDialog._Artist, CustomInputDialog._Genre, type);
            list.Add(media);
            CustomInputDialog.Reset();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = list;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (sender as ListBox);
            var media = (Multimedia)lb.SelectedItem;
            title_label.Content = media.Title;
            artist_label.Content = media.Artist;
            genre_label.Content = media.Genre;
            type_label.Content = media.Type;
        }
    }
}
