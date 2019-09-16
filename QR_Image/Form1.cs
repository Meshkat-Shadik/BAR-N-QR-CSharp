using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace QR_Image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            BarcodeWriter bar = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            };
            pictureBox2.Image = bar.Write(textBox4.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(new Bitmap(pictureBox2.Image));
            if (result != null)
            {
                textBox3.Text = result.Text;
            }
        }

        private void BtnGenerate_Click_1(object sender, EventArgs e)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 500,
                Height = 500,
                Margin = 0,
                PureBarcode = false
            };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(textBox1.Text);
            Bitmap logo = new Bitmap($"I:/Programming/C#/QR_Image/pstu.png");
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            this.pictureBox1.Image = bitmap;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            BarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(new Bitmap(pictureBox1.Image));
            if (result != null)
            {
                textBox2.Text = result.Text;
            }
        }
    }
}
