using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace DNP2_ASYNC_Ass7
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Stopwatch sw;
        public DispatcherTimer dispatcherTimer;
        private Random m_Random = new Random();
        

        public MainWindow()
        {
            InitializeComponent();
            sw = new Stopwatch();
        }

        public void HeavyWork()
        {
            double secondsToSleep = m_Random.NextDouble() * 10;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(secondsToSleep));
        }

        public Task HeavyWorkAsync()
        {
            return Task.Run(() => HeavyWork());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1)
            };
            dispatcherTimer.Tick += DTick;
            dispatcherTimer.Start();
            label.Content = "Work started";
            sw.Start();
            DoWork();
        }

        private void DTick(object sender, object e)
        {
            if (sw.ElapsedMilliseconds >= 8000)
                label.Content = "still working";
        }

            private async void DoWork()
            {   
                await Task.Factory.StartNew(async () => {
                    Task t1 = HeavyWorkAsync();
                    Task t2 = HeavyWorkAsync();
                    Task t3 = HeavyWorkAsync();
                    await Task.WhenAll(t1, t2, t3);
                    await Dispatcher.BeginInvoke((Action)(() =>
                     {
                         sw.Stop();
                         label.Content = $"work finished after {sw.ElapsedMilliseconds} miliseconds";
                         dispatcherTimer.Stop();
                     }));
                });
            }
    }
}
