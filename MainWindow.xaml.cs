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

namespace Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            btnSubmit.IsEnabled = false;
            var input = tbInput.Text;
            var output = tbOutput.Text;
            //ClearTextBox();

            try
            {
                var result = await Task.Run(() => { return ConvertManager.Convert(input, output); });
                tblConvertedOutpt.Text += result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnSubmit.IsEnabled = true;
        }

        private void ClearTextBox()
        {
            tbInput.Clear();
            tbOutput.Clear();
        }
    }
}
