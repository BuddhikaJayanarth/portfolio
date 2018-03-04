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
using System.Windows.Shapes;
using TrueMarbleBiz;

namespace TrueMarbleGUI
{
    /// <summary>
    /// Interaction logic for DisplayHistory.xaml
    /// </summary>
    public partial class DisplayHistory : Window
    {
        BrowseHistory m_history;
        public DisplayHistory(BrowseHistory History)
        {
            InitializeComponent();
            m_history = History;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvwHistory.ItemsSource = m_history.History;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
