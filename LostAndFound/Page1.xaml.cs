using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Windows.Markup;

namespace LostAndFound
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        LostAndFoundDataContext _lfDC = null;
        private string picPath = null;
        public string picfileName = "";
        BitmapImage _default = new BitmapImage();
        public Page1()
        {
            //this page is for viewing items
            InitializeComponent();
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);

            picPath = @"C:\All Items\";
            _default.UriSource = new Uri(picPath + "No photo.jpg");
        }

        #region itemID and claimID buttons
        private void btnClaimID_Click(object sender, RoutedEventArgs e)
        {
            //visible
            lblClaim_FirstName.Visibility = Visibility.Visible;
            tbClaim_FirstName.Visibility = Visibility.Visible;

            lblClaim_LastName.Visibility = Visibility.Visible;
            tbClaim_LastName.Visibility = Visibility.Visible;

            lblClaim_Role.Visibility = Visibility.Visible;
            cbClaim_Role.Visibility = Visibility.Visible;

            lblClaim_Date.Visibility = Visibility.Visible;
            tbClaim_Date.Visibility = Visibility.Visible;

            tbClaimStaff_ID.Visibility = Visibility.Visible;;

            //collapse
            lblSurrender_FirstName.Visibility = Visibility.Collapsed;
            tbSurrender_FirstName.Visibility = Visibility.Collapsed;

            lblSurrender_LastName.Visibility = Visibility.Collapsed;
            tbSurrender_LastName.Visibility = Visibility.Collapsed;

            lblSurrender_Role.Visibility = Visibility.Collapsed;
            cbSurrender_Role.Visibility = Visibility.Collapsed;

            lblSurrender_Date.Visibility = Visibility.Collapsed;
            tbSurrender_Date.Visibility = Visibility.Collapsed;

            tbSurrenderStaff_ID.Visibility = Visibility.Collapsed;
        }
        private void btnItemID_Click(object sender, RoutedEventArgs e)
        {
            //visible
            lblSurrender_FirstName.Visibility = Visibility.Visible;
            tbSurrender_FirstName.Visibility = Visibility.Visible;

            lblSurrender_LastName.Visibility = Visibility.Visible;
            tbSurrender_LastName.Visibility = Visibility.Visible;

            lblSurrender_Role.Visibility = Visibility.Visible;
            cbSurrender_Role.Visibility = Visibility.Visible;

            lblSurrender_Date.Visibility = Visibility.Visible;
            tbSurrender_Date.Visibility = Visibility.Visible;

            tbSurrenderStaff_ID.Visibility = Visibility.Visible;

            //collapse
            lblClaim_FirstName.Visibility = Visibility.Collapsed;
            tbClaim_FirstName.Visibility = Visibility.Collapsed;

            lblClaim_LastName.Visibility = Visibility.Collapsed;
            tbClaim_LastName.Visibility = Visibility.Collapsed;

            lblClaim_Role.Visibility = Visibility.Collapsed;
            cbClaim_Role.Visibility = Visibility.Collapsed;

            lblClaim_Date.Visibility = Visibility.Collapsed;
            tbClaim_Date.Visibility = Visibility.Collapsed;

            tbClaimStaff_ID.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearPage1();
        }
        public void clearPage1()
        {
            tbItem_Name.Clear();
            tbItem_Status.Clear();
            cbItem_Color.SelectedIndex = -1;
            tbItem_Desc.Text = "";
            tbItem_Location.Clear();
            tbSurrender_FirstName.Clear();
            tbSurrender_LastName.Clear();
            cbSurrender_Role.SelectedIndex = -1;
            tbSurrender_Date.Text = "";
            tbSurrenderStaff_ID.Clear();
            tbClaim_FirstName.Clear();
            tbClaim_LastName.Clear();
            cbClaim_Role.SelectedIndex = -1;
            tbClaim_Date.Text = "";
            tbClaimStaff_ID.Clear();
            pic.Source = new BitmapImage(new Uri("No photo.jpg", UriKind.RelativeOrAbsolute));
            btnItemID.Content = "Item ID";
            btnClaimID.Content = "Claim ID";
        }
        public void TrueHitTest()
        {
            tbItem_Name.IsHitTestVisible = true;
            tbItem_Status.IsHitTestVisible = true;
            cbItem_Color.IsHitTestVisible = true;
            tbItem_Desc.IsHitTestVisible = true;
            tbItem_Location.IsHitTestVisible = true;
            tbSurrender_FirstName.IsHitTestVisible = true;
            tbSurrender_LastName.IsHitTestVisible = true;
            cbSurrender_Role.IsHitTestVisible = true;
            tbClaim_FirstName.IsHitTestVisible = true;
            tbClaim_LastName.IsHitTestVisible = true;
            cbClaim_Role.IsHitTestVisible = true;
        }

        public void FalseHitTest()
        {
            tbItem_Name.IsHitTestVisible = false;
            tbItem_Status.IsHitTestVisible = false;
            cbItem_Color.IsHitTestVisible = false;
            tbItem_Desc.IsHitTestVisible = false;
            tbItem_Location.IsHitTestVisible = false;
            tbSurrender_FirstName.IsHitTestVisible = false;
            tbSurrender_LastName.IsHitTestVisible = false;
            cbSurrender_Role.IsHitTestVisible = false;
            tbSurrender_Date.IsHitTestVisible = false;
            tbSurrenderStaff_ID.IsHitTestVisible = false;
            tbClaim_FirstName.IsHitTestVisible = false;
            tbClaim_LastName.IsHitTestVisible = false;
            cbClaim_Role.IsHitTestVisible = false;
            tbClaim_Date.IsHitTestVisible = false;
            tbClaimStaff_ID.IsHitTestVisible = false;
        }
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            btnConfirm.IsEnabled = false;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Browse Photos. . .";
            fileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*)";

            fileDialog.ShowDialog();

            if(fileDialog.FileName.Length > 0)
            {
                tbSelectedpic.Text = fileDialog.FileName;
                btnConfirm.IsEnabled = true;
            }
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (tbSelectedpic.Text.Length > 0)
            {
                string[] getshortpicpath = tbSelectedpic.Text.Split('\\');
                picfileName = picPath + getshortpicpath[getshortpicpath.Length - 1];
                pic.Source = _default;
                try
                {
                    File.Copy(tbSelectedpic.Text, picPath + getshortpicpath[getshortpicpath.Length - 1], true);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tbSelectedpic.Clear();
                btnConfirm.IsEnabled = false;
            }
        }
    }
}
