using HelixToolkit.Wpf;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DModelViewerWithObjectManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model3DGroup _loadedModel;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnLoadModelClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "3D Model Files (*.obj;*.stl)|*.obj;*.stl"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var reader = new ObjReader();
                    var model = reader.Read(openFileDialog.FileName);

                    if (_loadedModel != null)
                        MainViewport.Children.Clear();

                    _loadedModel = new Model3DGroup();
                    _loadedModel.Children.Add(model);

                    var visual = new ModelVisual3D { Content = _loadedModel };
                    MainViewport.Children.Add(visual);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Error loading model: {ex.Message}");
                }
            }
        }

        private void OnRotateClick(object sender, RoutedEventArgs e)
        {
            if (_loadedModel != null)
            {
                var transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 45));
                _loadedModel.Transform = transform;
            }
        }

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            if (_loadedModel != null)
            {
                _loadedModel.Transform = Transform3D.Identity;
            }
        }

        private void OnScaleChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (_loadedModel != null)
            {
                var scale = e.NewValue;
                _loadedModel.Transform = new ScaleTransform3D(scale, scale, scale);
            }
        }
    }
}