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

namespace TourProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasicInfoPage.xaml
    /// </summary>
    public partial class BasicInfoPage : Page
    {
        public BasicInfoPage()
        {
            InitializeComponent();
        }

        private void CountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == null)
                return;

            var originalText = textBox.Text;

            var filteredText = new string(originalText.Where(char.IsDigit).ToArray());

            if (filteredText.Length > 3)
            {
                filteredText = filteredText.Substring(0, 3);
            }

            if (originalText != filteredText)
            {
                textBox.Text = filteredText;

                textBox.SelectionStart = filteredText.Length;
            }
        }
    }
}
