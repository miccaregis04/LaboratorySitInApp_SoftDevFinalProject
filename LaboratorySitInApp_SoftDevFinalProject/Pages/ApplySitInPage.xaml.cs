using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaboratorySitInApp_SoftDevFinalProject
{
    public partial class ApplySitInPage : Window
    {
        private readonly string _placeholderText = "e.g. Finishing Java Project Assignment";
        public ApplySitInPage()
        {
            InitializeComponent();
        }
        private void PurposeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PurposeTextBox.Text == _placeholderText)
            {
                PurposeTextBox.Text = "";
                PurposeTextBox.Foreground = new SolidColorBrush(Color.FromRgb(26, 26, 46));
            }
        }

        private void PurposeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PurposeTextBox.Text))
            {
                PurposeTextBox.Text = _placeholderText;
                PurposeTextBox.Foreground = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            }
        }

        private void DurationTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Only allow numbers
            e.Handled = !IsNumeric(e.Text);
        }

        private void DurationTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsNumeric(text)) e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool IsNumeric(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, "^[0-9]+$");
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PurposeTextBox.Text) || PurposeTextBox.Text == _placeholderText)
            {
                MessageBox.Show("Please enter the purpose of your sit-in request.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Request Submitted");
        }
    }
}
