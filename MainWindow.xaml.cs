using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;

namespace omrokMultimediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool userIsDraggingSlider = false;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            omrokMedia.Volume = 100;
            //omrokMedia.Play();
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (omrokMedia.Source != null && omrokMedia.NaturalDuration.HasTimeSpan && !userIsDraggingSlider)
            {
                lblStatus.Content=string.Format("{0}/{0}/{1}",omrokMedia.Position.ToString(@"hh\:mm\:ss"),omrokMedia.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
                omrokMediaSlider.Minimum = 0;
                omrokMediaSlider.Maximum = omrokMedia.NaturalDuration.TimeSpan.TotalSeconds;
                omrokMediaSlider.Value = omrokMedia.Position.TotalSeconds;
            }
            else
            {
                lblStatus.Content="--:--:--";
            }
        }

        private void omrokMediaSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void omrokMediaSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            omrokMedia.Position = TimeSpan.FromSeconds(omrokMediaSlider.Value);
        }

        private void omrokMediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblStatus.Content = TimeSpan.FromSeconds(omrokMediaSlider.Value).ToString(@"hh\:mm\:ss");
        }
        void OmrokMediaPlay(object sender, RoutedEventArgs e)
        {
            try
            {
                omrokMedia.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void omrokMediaPause(object sender, RoutedEventArgs e)
        {
            try
            {
                omrokMedia.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void omrokMeddiaMuteSound(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (omrokMedia.Volume == 100)
                {
                    omrokMedia.Volume = 0;
                }
                else
                {
                    omrokMedia.Volume = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void omrokGraph(object sender, RoutedEventArgs e)
        {
            try
            {
                omrokGraphics omrokgraphics = new omrokGraphics();
                omrokgraphics.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void omrokMediaStop(object sender, RoutedEventArgs e)
        {
            try
            {
                omrokMedia.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void omrokMediaOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openomrokFile = new OpenFileDialog();
            openomrokFile.Filter = "Media Files(*.mp3;*.mp4;*.mpg;*.mpeg)|*.mp3;*.mp4*.mpg;*.mpeg;|All files (*.*)|*.*";
            if (openomrokFile.ShowDialog() == true)
                omrokMedia.Source = new Uri(openomrokFile.FileName);
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            omrokMedia.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }
    }
}
