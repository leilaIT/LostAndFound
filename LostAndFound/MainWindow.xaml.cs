﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LostAndFoundDataContext _lfDC = null;

        private Dictionary<string, string[]> admins = new Dictionary<string, string[]>();
        string[] adminArr = new string[4];
        //0 - staffPass
        //1 - staffFirstname
        //2 - staffLastname
        //3 - staffStatus

        public MainWindow()
        {
            InitializeComponent();
            _lfDC = new LostAndFoundDataContext(Properties.Settings.Default.Lost_Found_Database_2ConnectionString);

            // mga admins
            var getAllUsers = (from s in _lfDC.Staffs
                              select s).ToList();
            foreach (var s in getAllUsers)
            {
                adminArr[0] = s.Staff_Password;
                adminArr[1] = s.Staff_FirstName;
                adminArr[2] = s.Staff_LastName;
                adminArr[3] = s.Staff_Status;
                admins.Add(s.Staff_ID, adminArr);
                adminArr = new string[4];
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = chkShowPassword.IsChecked == true ? txtPasswordShow.Text : txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Content = "Please enter username and password.";
                return;
            }

            if (admins.ContainsKey(username) && admins[username][0] == password)
            {
                if (admins[username][3] != "Inactive")
                {
                    StaticClass.currentStaffid = username;
                    StaticClass.currentStaffname = $"{admins[username][1]} {admins[username][2]}";
                    StaticClass.currentStaffpass = $"{admins[username][0]}";
                    Window2 window2 = new Window2(StaticClass.currentStaffname);
                    window2.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("This staff is currenly inactive.");

            }
            else
            {
                lblMessage.Content = "Invalid username or password.";
            }
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Collapsed;
            txtPasswordShow.Visibility = Visibility.Visible;
            txtPasswordShow.Text = txtPassword.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Visible;
            txtPasswordShow.Visibility = Visibility.Collapsed;
            txtPassword.Password = txtPasswordShow.Text;
        }
    }
}