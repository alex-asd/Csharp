using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LAB12
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        System.Windows.Forms.OpenFileDialog aDialog = new System.Windows.Forms.OpenFileDialog();
        DispatcherTimer _timer = new DispatcherTimer();
        public Window1()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(Tick);
            _timer.Start();
        }

        void Tick(object sender, EventArgs e)
        {
            timeline.Value = MediaElement1.Position.TotalSeconds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aDialog.ShowDialog();
            if (aDialog.FileName == "")
                return;
            MediaElement1.Source = new Uri(aDialog.FileName);
            MediaElement1.Play();
            indicator.Content = "Playing..";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaElement1.Play();
            indicator.Content = "Playing..";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MediaElement1.Pause();
            indicator.Content = "Poused";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MediaElement1.Stop();
            indicator.Content = "Stopped";
        }

        private void MediaElement1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media loading unsuccessful. " + e.ErrorException.Message);
        }

        private void MediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            timeline.Maximum = MediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
        }
    }
}
