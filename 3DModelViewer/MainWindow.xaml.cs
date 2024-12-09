using Microsoft.Win32;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DModelViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentScale = 1.0; // Scale value to apply to transformations

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoadModelClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "3D Model Files|*.obj;*.stl"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Use ObjReader to read the model
                    var reader = new ObjReader();
                    var model = reader.Read(openFileDialog.FileName);

                    // Clear the viewport and load new model
                    MainViewport.Children.Clear();
                    MainViewport.Children.Add(new ModelVisual3D { Content = model });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading the model: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OnResetViewClick(object sender, RoutedEventArgs e)
        {
            MainViewport.Camera.Transform = Transform3D.Identity;
        }

        private void OnScaleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                double scaleFactor = e.NewValue;

                // Apply scale transformation to the viewport camera or viewport content
                MainViewport.Camera.Transform = new ScaleTransform3D(scaleFactor, scaleFactor, scaleFactor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scaling the view: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
