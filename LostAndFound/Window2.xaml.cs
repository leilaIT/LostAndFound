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
using AForge.Video;
using AForge.Video.DirectShow;

namespace LostAndFound
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        LostAndFoundDataContext _lfDC = null;
        public string itemID = null;
        public string claimID = null;
        public string searchTerm = null;
        public static Page1 page1 = new Page1();
        public static Page2 page2 = new Page2();
        private string checkcurrentClaimID = null;
        public Window2(string username)
        {
            InitializeComponent();
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
            WelcomeAdmin.Text = $"Welcome {username}!";
            tbdate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            MainFrame.Navigate(page1);
            populateListbox();
            page1.FalseHitTest();
            page1.pic.Source = new BitmapImage(new Uri("No photo.jpg", UriKind.RelativeOrAbsolute));
        }
        /// <summary>
        /// this method will populate the listbox
        /// </summary>
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            page1.clearPage1();
            this.Close();
        }
        private void populateListbox()
        {
            var getAllItems = (from i in _lfDC.Items
                              select i).ToList();
            Items_Listbox.ItemsSource = getAllItems;
        }
        private void tbSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchTerm = tbSearchBar.Text;
            var searchQuery = _lfDC.Procedure_SearchItems(searchTerm).ToList();
            Items_Listbox.ItemsSource = searchQuery;
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
                            page1.pic.Source = new BitmapImage(new Uri(item.Item_Photo, UriKind.RelativeOrAbsolute));
                            page1.btnItemID.Content = item.Item_ID;
                            page1.tbItem_Name.Text = item.Item_Name;
                            page1.tbItem_Status.Text = item.Item_Status;
                            page1.tbItem_Location.Text = item.Item_Location;
                            page1.cbItem_Color.Text = item.Item_Color;
                            page1.tbItem_Desc.Text = item.Item_Desc;
                            page1.tbSurrender_FirstName.Text = item.Surrender_FirstName;
                            page1.tbSurrender_LastName.Text = item.Surrender_LastName;
                            page1.cbSurrender_Role.Text = item.Surrender_Role;
                            page1.tbSurrender_Date.Text = item.Surrender_Date.ToString();
                            page1.tbSurrenderStaff_ID.Text = item.Staff_ID;

                            var getClaim = from c in _lfDC.Claims
                                           where c.Claim_ID == item.Claim_ID
                                           select c;

                            foreach(var claim in getClaim)
                            {
                                page1.btnClaimID.Content = claim.Claim_ID;
                                if(btnEdit.Visibility == Visibility.Collapsed)
                                {
                                    if (claim.Claim_ID == "NO-CLM")
                                        btnUpdateClaim.IsEnabled = true;
                                    else
                                        btnUpdateClaim.IsEnabled = false;
                                }
                                page1.tbClaim_FirstName.Text = claim.Claim_FirstName;
                                page1.tbClaim_LastName.Text = claim.Claim_LastName;
                                page1.cbClaim_Role.Text = claim.Claim_Role;
                                page1.tbClaim_Date.Text = claim.Claim_Date.ToString();
                                page1.tbClaimStaff_ID.Text = claim.Staff_ID;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region report_a_lost_item
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            //clear everything first
            page2.clearPage2();
            MainFrame.Navigate(page2);
            Items_Listbox.IsEnabled = false;
            page1.gridDisplay.Visibility = Visibility.Collapsed;
            
            page2.gridAdd.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            btnAddItem.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
            page2.tbAddItem_Status.Text = "Missing";

            page2.tbAddSurrender_Date.Text = DateTime.Now.ToString();
            page2.tbAddSurrenderStaff_ID.Text = StaticClass.currentStaffid;
            page2.cbAddItem_Color.SelectedIndex = -1;
            page2.cbAddSurrender_Role.SelectedIndex = -1;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            backToView();
        }
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if(page2.tbAddItem_Name.Text != "" && page2.tbAddItem_Location.Text != "" && page2.cbAddItem_Color.SelectedIndex != -1 && 
               page2.tbAddItem_Desc.Text != "" && page2.tbAddSurrender_FirstName.Text != "" && page2.tbAddSurrender_LastName.Text != "" && 
               page2.cbAddSurrender_Role.SelectedIndex != -1 && page2.picfileName != "")
            {
                _lfDC.Procedure_AddMissingItem(itemID
                                              , page2.tbAddItem_Name.Text
                                              , page2.cbAddItem_Color.Text
                                              , page2.tbAddItem_Desc.Text
                                              , page2.tbAddItem_Location.Text
                                              , page2.tbAddSurrender_FirstName.Text
                                              , page2.tbAddSurrender_LastName.Text
                                              , page2.cbAddSurrender_Role.Text
                                              , null
                                              , page2.tbAddSurrenderStaff_ID.Text
                                              , claimID
                                              , null
                                              , page2.picfileName);
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

        #region edit_info_stuff
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            VerifyStaffWindow vsw = new VerifyStaffWindow();
            vsw.Closed += VerifyStaffWindow_Closed;
            btnReport.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnLogout.IsEnabled = false;
            Items_Listbox.IsEnabled = false;
            page1.btnItemID.IsEnabled = false;
            page1.btnClaimID.IsEnabled = false;
            vsw.Show();
        }
        private void VerifyStaffWindow_Closed(object sender, EventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnReport.IsEnabled = true;
            btnLogout.IsEnabled = true;
            Items_Listbox.IsEnabled = true;
            page1.btnItemID.IsEnabled = true;
            page1.btnClaimID.IsEnabled = true;
            if (StaticClass.verifyStaff)
            {
                Items_Listbox.IsEnabled = false;
                page1.btnItemID.IsEnabled = false;
                page1.btnClaimID.IsEnabled = false;
                page1.TrueHitTest();
                checkcurrentClaimID = page1.btnClaimID.Content.ToString();
                if (page1.tbClaim_FirstName.Visibility == Visibility.Visible)
                {
                    if (checkcurrentClaimID == "NO-CLM")
                    {
                        btnUpdateClaim.Visibility = Visibility.Visible;
                        page1.tbClaim_Date.Text = DateTime.Now.ToString();
                        page1.tbClaimStaff_ID.IsEnabled = false;
                        page1.tbClaimStaff_ID.Text = StaticClass.currentStaffid;
                        page1.btnClear.Visibility = Visibility.Collapsed;
                    }
                    else
                        btnSave.Visibility = Visibility.Visible;
                }
                else
                {
                    page1.btnUpload.Visibility = Visibility.Visible;
                    page1.btnConfirm.Visibility = Visibility.Visible;
                    btnSave.Visibility = Visibility.Visible;
                    page1.tbSelectedpic.Visibility = Visibility.Visible;
                }

                btnEdit.Visibility = Visibility.Collapsed;
                btnReport.Visibility = Visibility.Collapsed;
                btnBack.Visibility = Visibility.Visible;

                StaticClass.verifyStaff = false;
                page1.gridDisplay.IsHitTestVisible = true;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (page1.tbSurrender_FirstName.Visibility == Visibility.Visible)
            {
                _lfDC.Procedure_UpdateMissingItem(page1.btnItemID.Content.ToString()
                                                 , page1.tbItem_Name.Text
                                                 , page1.cbItem_Color.Text
                                                 , page1.tbItem_Desc.Text
                                                 , page1.tbItem_Location.Text
                                                 , page1.tbSurrender_FirstName.Text
                                                 , page1.tbSurrender_LastName.Text
                                                 , page1.cbSurrender_Role.Text
                                                 , page1.picfileName);
                MessageBox.Show("Missing item information was updated successfully!");
            }
            else
            {
                _lfDC.Procedure_UpdateClaimedItem(page1.btnClaimID.Content.ToString()
                                                 , page1.tbClaim_FirstName.Text
                                                 , page1.tbClaim_LastName.Text
                                                 , page1.cbClaim_Role.Text
                                                 );
                MessageBox.Show("Claimed item information was updated successfully!");
            }
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
            page1.btnUpload.Visibility = Visibility.Collapsed;
            page1.btnConfirm.Visibility = Visibility.Collapsed;
            populateListbox();
            backToView();
        }
        #endregion

        #region recording_a_claimed_item
        private void btnUpdateClaim_Click(object sender, RoutedEventArgs e)
        {
            if (page1.tbClaim_FirstName.Text != "None" && page1.tbClaim_LastName.Text != "None" && page1.cbSurrender_Role.SelectedIndex != -1)
            {
                _lfDC.Procedure_AddClaimedItem(page1.btnItemID.Content.ToString()
                                              , claimID
                                              , page1.tbClaim_FirstName.Text
                                              , page1.tbClaim_LastName.Text
                                              , page1.cbClaim_Role.Text
                                              , null
                                              , StaticClass.currentStaffid
                                              , null);
                MessageBox.Show("Item recorded as CLAIMED successfully.");

                _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_DatabaseConnectionString);
                populateListbox();
                backToView();
            }
            else
            {
                MessageBox.Show("Please fill out all fields with appropriate claim information!");
            }
        }
        #endregion
        private void backToView()
        {
            page1.clearPage1();
            page1.FalseHitTest();
            Items_Listbox.IsEnabled = true;
            page1.btnItemID.IsEnabled = true;
            page1.btnClaimID.IsEnabled = true;
            Items_Listbox.SelectedIndex = -1;
            MainFrame.Navigate(page1);
            page2.gridAdd.Visibility = Visibility.Collapsed;
            page1.gridDisplay.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            btnUpdateClaim.Visibility = Visibility.Collapsed;
            btnAddItem.Visibility = Visibility.Collapsed;
            btnReport.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Visible;
            page1.btnClear.Visibility = Visibility.Visible;
            page1.tbSelectedpic.Visibility = Visibility.Collapsed;
            page1.btnUpload.Visibility = Visibility.Collapsed;
            page1.btnConfirm.Visibility = Visibility.Collapsed;
            if (page2._videoDevice != null && page2._videoDevice.IsRunning)
            {
                page2._videoDevice.SignalToStop();
                page2._videoDevice.WaitForStop();
            }
        }

        #region filter stuff
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterBox_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void FilterItems()
        {
            var filteredItems = _lfDC.Items.ToList();

            if (cbRed.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Red").ToList();
            }

            if (cbOrange.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Orange").ToList();
            }

            if (cbYellow.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Yellow").ToList();
            }

            if (cbGreen.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Green").ToList();
            }

            if (cbBlue.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Blue").ToList();
            }

            if (cbViolet.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Violet").ToList();
            }

            if (cbPink.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Pink").ToList();
            }

            if (cbBlack.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Black").ToList();
            }

            if (cbWhite.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "White").ToList();
            }

            if (cbGray.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Gray").ToList();
            }

            if (cbBrown.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Brown").ToList();
            }

            if (cbBeige.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Beige").ToList();
            }

            if (cbMultiColor.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Multi-color").ToList();
            }

            if (cbTransparent.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Color == "Transparent").ToList();
            }

            if (cbStudent.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Surrender_Role == "Student").ToList();
            }

            if (cbEmployee.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Surrender_Role == "Employee").ToList();
            }

            if (cbSTFF01.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Staff_ID == "STFF-01").ToList();
            }

            if (cbSTFF03.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Staff_ID == "STFF-03").ToList();
            }

            if (cbSTFF04.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Staff_ID == "STFF-04").ToList();
            }

            if (cbMissing.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Status == "Missing").ToList();
            }

            if (cbClaimed.IsChecked == true)
            {
                filteredItems = filteredItems.Where(p => p.Item_Status == "Claimed").ToList();
            }

            Items_Listbox.ItemsSource = filteredItems.ToList();
        }

        private void cbRed_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbOrange_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbYellow_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbGreen_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBlue_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbViolet_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbPink_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBlack_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbWhite_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbGray_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBrown_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBeige_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbMultiColor_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbTransparent_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbStudent_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbEmployee_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF01_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF03_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF04_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbMissing_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbClaimed_Checked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbRed_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbOrange_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbYellow_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbGreen_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBlue_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbViolet_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbPink_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBlack_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbWhite_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbGray_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBrown_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbBeige_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbMultiColor_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbTransparent_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbStudent_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbEmployee_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF01_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF03_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbSTFF04_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbMissing_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        private void cbClaimed_UnChecked(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }
        #endregion
    }
}
