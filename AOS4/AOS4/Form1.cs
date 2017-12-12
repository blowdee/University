using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AOS4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap image;
        public static string full_name_of_image = "";
        public static UInt32[,] pixel;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog o = new OpenFileDialog();
                o.ShowDialog();
                Bitmap image = new Bitmap(o.FileName);
                pic.Size = new System.Drawing.Size(640, 480);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.Fixed3D;
                pic.Image = image;
                pixel = new UInt32[image.Height, image.Width];
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                        pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rezk_Click(object sender, EventArgs e)
        {
            if (full_name_of_image != "\0")
            {
                pixel = Filter.matrix_filtration(image.Width, image.Height, pixel, Filter.N1, Filter.sharpness);
                FromPixelToBitmap();
                FromBitmapToScreen();
            }
        }

        private void relief_Click(object sender, EventArgs e)
        {

        }

        public static void FromPixelToBitmap()
        {
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
        }

        public static void FromOnePixelToBitmap(int x, int y, UInt32 pixel)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }

        public void FromBitmapToScreen()
        {
            pic.Image = image;
        }
    }
}
