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

namespace LostAndFound
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        LostAndFoundDataContext _lfDC = null;
        public Window2(string username)
        {
            InitializeComponent();
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
            WelcomeAdmin.Text = $"Welcome {username}!";
            tbdate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            populateListbox();
        }
        /// <summary>
        /// this method will populate the listbox
        /// </summary>
        private void populateListbox()
        {
            var getAllItems = (from i in _lfDC.Items
                              select i).ToList();
            Items_Listbox.ItemsSource = getAllItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Items_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
