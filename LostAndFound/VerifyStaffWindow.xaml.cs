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

namespace LostAndFound
{
    /// <summary>
    /// Interaction logic for VerifyStaffWindow.xaml
    /// </summary>
    public partial class VerifyStaffWindow : Window
    {
        public VerifyStaffWindow()
        {
            InitializeComponent();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (pass_Textbox.Text == StaticClass.currentStaffpass)
            {
                StaticClass.verifyStaff = true;
                MessageBox.Show("Edit Access Allowed.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong password.\nEdit Access Denied.");
            }
        }
        private void VerifyStaffWindow_Closed(object sender, EventArgs e)
        {

        }
    }
}
