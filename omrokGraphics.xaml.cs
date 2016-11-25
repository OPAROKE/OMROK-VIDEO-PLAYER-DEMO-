using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace omrokMultimediaPlayer
{
    /// <summary>
    /// Interaction logic for omrokGraphics.xaml
    /// </summary>
    public partial class omrokGraphics : Window
    {
        public omrokGraphics()
        {
            InitializeComponent();
        }

        //WHEN USER SELECTS RADIO, SET AXIS OF ROTATION 
        private void xRadio_Checked(object sender, RoutedEventArgs e)
        {
            
            rotation.Axis = new Vector3D(1, 0, 0); //SET ROTATION AXIS
            camera.Position = new Point3D(6, 0, 0);   //SET CAMERA POSITION
        }

        private void yRadio_Checked(object sender, RoutedEventArgs e)
        {
            rotation.Axis = new Vector3D(0, 1, 0); //SET ROTATION AXIS
            camera.Position = new Point3D(6, 0, 0);   //SET CAMERA POSITION
        }

        private void zRadio_Checked(object sender, RoutedEventArgs e)
        {
            rotation.Axis = new Vector3D(0, 0, 1); //SET ROTATION AXIS
            camera.Position = new Point3D(6, 0, 1);   //SET CAMERA POSITION
        }
    }
}
