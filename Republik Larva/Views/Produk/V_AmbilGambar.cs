using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Republik_Larva.Controller;

namespace Republik_Larva.Views.Produk
{
    public partial class V_AmbilGambar : UserControl
    {
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice videoSource;
        private Bitmap capturedImage;
        private C_Produk c_Produk;

        public V_AmbilGambar(C_Produk controller)
        {
            InitializeComponent();
            c_Produk = controller;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            InitializeCamera();
        }

        // Inisialisasi kamera
        private void InitializeCamera()
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo deviceList in captureDevice)
            {
                comboBox1.Items.Add(deviceList.Name);
            }
            comboBox1.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
        }

        // Mulai kamera
        private void StartCamera()
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
            videoSource = new VideoCaptureDevice(captureDevice[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        // Event ketika frame baru diterima
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // Capture gambar dari video
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                capturedImage = (Bitmap)pictureBox1.Image.Clone();
                MessageBox.Show("Gambar berhasil di-capture!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tidak ada frame yang dapat di-capture.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Simpan gambar ke file
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (capturedImage != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Simpan Gambar",
                    Filter = "Image files (*.jpg, *.png)|*.jpg;*.png"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(saveFileDialog.FileName);
                    ImageFormat imageFormat = ImageFormat.Png;

                    if (ext == ".jpg") imageFormat = ImageFormat.Jpeg;

                    capturedImage.Save(saveFileDialog.FileName, imageFormat);
                    MessageBox.Show("Gambar berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Tidak ada gambar untuk disimpan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCamera();
        }
    }
}
