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
using TourProject.Pages;

namespace TourProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentWindowIndex = 0;

        public MainWindow()
        {
            InitializeComponent();

            UpdateWindow();
        }

        private void UpdateWindow()
        {
            for (int i = 0; i < 4; i++)
            {
                GetCircle(i).Fill = (i < currentWindowIndex) ? Brushes.Gray : Brushes.White;
            }
            if (currentWindowIndex < 4)
            {
                GetCircle(currentWindowIndex).Fill = Brushes.Green;
            }
            if (currentWindowIndex == 0)
            {
                MainFrame.Navigate(new BasicInfoPage());
                NameLabel.Content = "Основная информация";
            }
            if (currentWindowIndex == 1)
            {
                MainFrame.Navigate(new PreferencesPage());
                NameLabel.Content = "Предпочтения";
            }
            if (currentWindowIndex == 2)
            {
                MainFrame.Navigate(new HotelConditionsPage());
                NameLabel.Content = "Условия отеля";
            }
            if (currentWindowIndex == 3)
            {
                MainFrame.Navigate(new TourOffersPage());
                NameLabel.Content = "Предложения туров";
            }
        }

        private Ellipse GetCircle(int index)
        {
            switch (index)
            {
                case 0: return Circle1;
                case 1: return Circle2;
                case 2: return Circle3;
                case 3: return Circle4;
                default: return null;
            }
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindowIndex < 3)
            {
                currentWindowIndex++;
                UpdateWindow();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindowIndex < 3)
            {
                currentWindowIndex++;
                UpdateWindow();
            }
        }
    }
}