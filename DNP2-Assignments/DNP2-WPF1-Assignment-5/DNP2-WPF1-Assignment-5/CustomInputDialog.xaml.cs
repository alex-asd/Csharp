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
using System.Windows.Shapes;

namespace DNP2_WPF1_Ass5
{
    public partial class CustomInputDialog : Window
    {
        public static string _Title { get; set; }
        public static string _Artist { get; set; }
        public static string _Genre { get; set; }
        public static int? _Type { get; set; }

        public CustomInputDialog()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _Title = title.Text;
            _Artist = artist.Text;
            _Genre = genre.Text;
            _Type = (bool)Cd.IsChecked ? 0 : 1;
            this.Close();
        }

        public static void Reset()
        {
            _Title = null;
            _Artist = null;
            _Genre = null;
            _Type = null;
        }
    }
}
