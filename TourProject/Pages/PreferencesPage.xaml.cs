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
        private ListViewItem _draggedItem;
        public PreferencesPage()
        {
            InitializeComponent();
        }

        private void SourceListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draggedItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
            if (_draggedItem != null)
            {
                DragDrop.DoDragDrop(sourceListView, _draggedItem, DragDropEffects.Move);
            }
        }

        private void targetListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                if (targetListView.Items.Contains(item))
                {
                    targetListView.Items.Remove(item);
                }
                else
                {
                    if (sourceListView.Items.Contains(item))
                    {
                        sourceListView.Items.Remove(item);
                    }
                }

                var targetItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                int index = targetListView.Items.IndexOf(targetItem);

                if (index < 0)
                {
                    targetListView.Items.Add(new ListViewItem { Content = item.Content });
                }
                else
                {
                    targetListView.Items.Insert(index, new ListViewItem { Content = item.Content });
                }
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

        private void targetListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draggedItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
            if (_draggedItem != null)
            {
                DragDrop.DoDragDrop(targetListView, _draggedItem, DragDropEffects.Move);
            }
        }
    }
}
