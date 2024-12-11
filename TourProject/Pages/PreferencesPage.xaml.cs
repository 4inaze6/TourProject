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
    /// Логика взаимодействия для PreferencesPage.xaml
    /// </summary>
    public partial class PreferencesPage : Page
    {
        public PreferencesPage()
        {
            InitializeComponent();
        }

        private void SourceListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
            if (item != null)
            {
                DragDrop.DoDragDrop(sourceListView, item, DragDropEffects.Move);
            }
        }

        private void targetListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                targetListView.Items.Add(new ListViewItem { Content = item.Content });

                sourceListView.Items.Remove(item);
            }
        }

        private void targetListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
    }
}
