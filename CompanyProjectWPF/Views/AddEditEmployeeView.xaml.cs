using System.Windows;
using System.Windows.Controls;
using CompanyProjectWPF.ViewModels;

namespace CompanyProjectWPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : UserControl
    {
        public AddEditEmployee()
        {
            InitializeComponent();
        }

        private void UploadPhoto(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            var dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                //tb6.Text = filename;
            }
        }

    }
}
