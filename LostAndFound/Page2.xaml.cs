using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace LostAndFound
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        //this page is for adding an item record thru the system
        public FilterInfoCollection _videoDevices;
        public VideoCaptureDevice _videoDevice;
        private string picPath = null;
        public string picfileName = "";
        BitmapImage _default = new BitmapImage();
        public Page2()
        {
            InitializeComponent();
            LoadVideoDevices();
            picPath = @"C:\All Items\";
            _default.UriSource = new Uri(picPath + "No photo.jpg");
        }
        #region camera_taking_stuff
        private void LoadVideoDevices()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in _videoDevices)
            {
                cmbCamera.Items.Add(device.Name);
            }
            if (cmbCamera.Items.Count > 0)
            {
                cmbCamera.SelectedIndex = 0;
            }
        }
        private void cmbCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_videoDevice != null)
            {
                _videoDevice.SignalToStop();
                _videoDevice.WaitForStop();
            }

            _videoDevice = new VideoCaptureDevice(_videoDevices[cmbCamera.SelectedIndex].MonikerString);
            _videoDevice.NewFrame += VideoDevice_NewFrame;
        }
        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Dispatcher.Invoke(() =>
            {
                pic.Source = BitmapToImageSource(eventArgs.Frame.Clone() as Bitmap);
            });
        }
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if(tbAddItem_Name.Text.Length < 1)
            {
                MessageBox.Show("Fill out Item Name field first.");
            }
            else
            {
                if (_videoDevice != null)
                {
                    _videoDevice.Start();
                }
            }
        }
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            if (_videoDevice != null && _videoDevice.IsRunning)
            {
                _videoDevice.SignalToStop();
                _videoDevice.WaitForStop();
            }

            picfileName = picPath + tbAddItem_Name.Text + ".jpg";

            if (pic.Source is BitmapSource bitmapSource)
            {
                SaveBitmapSourceToFile(bitmapSource, picfileName);
            }
        }
        private void SaveBitmapSourceToFile(BitmapSource bitmapSource, string filePath)
        {
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
        #endregion
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearPage2();
        }
        public void clearPage2()
        {
            tbAddItem_Name.Clear();
            tbAddItem_Status.Clear();
            cbAddItem_Color.SelectedIndex = -1;
            tbAddItem_Desc.Clear();
            tbAddItem_Location.Clear();
            tbAddSurrender_FirstName.Clear();
            tbAddSurrender_LastName.Clear();
            cbAddSurrender_Role.SelectedIndex = -1;
            tbAddSurrender_Date.Text = "";
            tbAddSurrenderStaff_ID.Clear();
            pic.Source = new BitmapImage(new Uri("No photo.jpg", UriKind.RelativeOrAbsolute));
        }
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            cmbCamera.Visibility = Visibility.Collapsed;
            tbSelectedpic.Visibility = Visibility.Visible;
            btnCapture.Visibility = Visibility.Collapsed;
            btnConfirm.IsEnabled = false;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Browse Photos. . .";
            fileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*)";

            fileDialog.ShowDialog();

            if (fileDialog.FileName.Length > 0)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tbSelectedpic.Clear();
                tbSelectedpic.Visibility = Visibility.Collapsed;
                cmbCamera.Visibility = Visibility.Visible;
                btnCapture.Visibility = Visibility.Visible;
                btnStart.IsEnabled = true;
                btnConfirm.IsEnabled = false;
            }
        }
    }
}
