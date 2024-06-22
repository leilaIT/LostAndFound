using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private string itemID = null;
        private string claimID = null;
        public Window2(string username)
        {
            InitializeComponent();
            //Item_Frame.Content = new Page1();
            //Item_Frame.Content = new Page2();
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
            WelcomeAdmin.Text = $"Welcome {username}!";
            tbdate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            populateListbox();
        }
        /// <summary>
        /// this method will populate the listbox
        /// </summary>
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void populateListbox()
        {
            var getAllItems = (from i in _lfDC.Items
                              select i).ToList();
            Items_Listbox.ItemsSource = getAllItems;
        }
        private void searchbar()
        {
            //code for the searchbar
            //not yet added
        }

        #region selecting_item
        private void Items_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Items_Listbox.SelectedItem != null)
            {
                Item selectedItem = (Item)Items_Listbox.SelectedItem;

                if(selectedItem != null)
                {
                    btnEdit.IsEnabled = true;

                    var getItem = from i in _lfDC.Items
                                  where i.Item_ID == selectedItem.Item_ID
                                  select i;

                    if(getItem.Count() == 1)
                    {
                        foreach(var item in getItem)
                        {
                            btnItemID.Content = item.Item_ID;
                            tbItem_Name.Text = item.Item_Name;
                            tbItem_Status.Text = item.Item_Status;
                            tbItem_Location.Text = item.Item_Location;
                            cbItem_Color.Text = item.Item_Color;
                            tbItem_Desc.Text = item.Item_Desc;
                            tbSurrender_FirstName.Text = item.Surrender_FirstName;
                            tbSurrender_LastName.Text = item.Surrender_LastName;
                            cbSurrender_Role.Text = item.Surrender_Role;
                            tbSurrender_Date.Text = item.Surrender_Date.ToString();
                            tbSurrenderStaff_ID.Text = item.Staff_ID;

                            var getClaim = from c in _lfDC.Claims
                                           where c.Claim_ID == item.Claim_ID
                                           select c;

                            foreach(var claim in getClaim)
                            {
                                btnClaimID.Content = claim.Claim_ID;
                                if(btnEdit.Visibility == Visibility.Collapsed)
                                {
                                    if (claim.Claim_ID == "NO-CLM")
                                        btnUpdateClaim.IsEnabled = true;
                                    else
                                        btnUpdateClaim.IsEnabled = false;
                                }
                                tbClaim_FirstName.Text = claim.Claim_FirstName;
                                tbClaim_LastName.Text = claim.Claim_LastName;
                                cbClaim_Role.Text = claim.Claim_Role;
                                tbClaim_Date.Text = claim.Claim_Date.ToString();
                                tbClaimStaff_ID.Text = claim.Staff_ID;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region itemID_claimID_buttons
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

            tbClaimStaff_ID.Visibility = Visibility.Visible;
            if(btnEdit.Visibility == Visibility.Collapsed)
                btnUpdateClaim.Visibility = Visibility.Visible;

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

            btnUpdateClaim.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region edit_info_stuff
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            VerifyStaffWindow vsw = new VerifyStaffWindow();
            vsw.Closed += VerifyStaffWindow_Closed;
            btnReport.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnLogout.IsEnabled = false;
            Items_Listbox.IsEnabled = false;
            vsw.Show();
        }
        private void VerifyStaffWindow_Closed(object sender, EventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnReport.IsEnabled = true;
            btnLogout.IsEnabled = true;
            Items_Listbox.IsEnabled = true;
            if (StaticWindow.verifyStaff)
            {
                if (btnEdit.Visibility == Visibility.Collapsed)
                    btnUpdateClaim.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Visible;
                StaticWindow.verifyStaff = false;

                gridDisplay.IsHitTestVisible = true;
            }
        }
        #endregion

        #region report_a_lost_item
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Items_Listbox.IsEnabled = false;
            gridDisplay.Visibility = Visibility.Collapsed;
            gridAdd.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            btnAddItem.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
            btnItemID.Content = "New Item Reported";
            btnItemID.IsEnabled = false;
            btnClaimID.Content = "Not Claimed Yet";
            btnClaimID.IsEnabled = false;

            tbAddItem_Status.Text = "Missing";
            tbAddSurrender_Date.Text = DateTime.Now.ToString();
            tbAddSurrenderStaff_ID.Text = StaticWindow.currentStaffid;
            cbAddItem_Color.SelectedIndex = -1;
            cbAddSurrender_Role.SelectedIndex = -1;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            backToView();
        }
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if(tbAddItem_Name.Text != "" && tbAddItem_Location.Text != "" && cbAddItem_Color.SelectedIndex != -1 && tbAddItem_Desc.Text != "" &&
               tbAddSurrender_FirstName.Text != "" && tbAddSurrender_LastName.Text != "" && cbAddSurrender_Role.SelectedIndex != -1)
            {
                _lfDC.Procedure_AddMissingItem(itemID
                                              , tbAddItem_Name.Text
                                              , cbItem_Color.Text
                                              , tbAddItem_Desc.Text
                                              , tbAddItem_Location.Text
                                              , tbAddSurrender_FirstName.Text
                                              , tbAddSurrender_LastName.Text
                                              , cbSurrender_Role.Text
                                              , null
                                              , StaticWindow.currentStaffid
                                              , claimID
                                              , null
                                              , "Assets/No Photo.jpg");
                MessageBox.Show("Item added successfully");

                _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
                populateListbox();
                backToView();
            }
            else
            {
                MessageBox.Show("Please fill out all fields!");
            }
        }
        #endregion

        #region recording_a_claimed_item
        private void btnUpdateClaim_Click(object sender, RoutedEventArgs e)
        {
            if (tbClaim_FirstName.Text != "None" && tbClaim_LastName.Text != "None" && cbSurrender_Role.SelectedIndex != -1)
            {
                _lfDC.Procedure_AddClaimedItem(btnItemID.Content.ToString()
                                              , claimID
                                              , tbClaim_FirstName.Text
                                              , tbClaim_LastName.Text
                                              , cbClaim_Role.Text
                                              , null
                                              , StaticWindow.currentStaffid
                                              , null);

                MessageBox.Show("Item added successfully");

                _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
                populateListbox();
                backToView();
            }
            else
            {
                MessageBox.Show("Please fill out all fields \nwith appropriate claim information!");
            }
        }
        #endregion
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            backToView();
        }
        private void backToView()
        {
            Items_Listbox.IsEnabled = true;
            gridAdd.Visibility = Visibility.Collapsed;
            gridDisplay.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            btnAddItem.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnItemID.Content = "Item ID";
            btnClaimID.Content = "Claim ID";
            btnItemID.IsEnabled = true;
            btnClaimID.IsEnabled = true;
            btnUpdateClaim.Visibility = Visibility.Collapsed;
        }
    }
}
