using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCVTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(ImageNames.ToArray());
            comboBox2.Items.AddRange(ImageNames.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // color comparison of translated image
        private void button1_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(comboBox1.SelectedItem.ToString());
            var src2 = new Mat(comboBox2.SelectedItem.ToString());
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // grey scale comparison of translated image
        private void button2_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(Constants.ImageD2_1, ImreadModes.GrayScale);
            var src2 = new Mat(Constants.ImageD2_2, ImreadModes.GrayScale);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // color comparison of translated image
        private void button4_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(Constants.ImageD2_3);
            var src2 = new Mat(Constants.ImageD2_4);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // color comparison of translated image
        private void button5_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(Constants.ImageD2_3, ImreadModes.GrayScale);
            var src2 = new Mat(Constants.ImageD2_4, ImreadModes.GrayScale);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // std dev
        private void button6_Click(object sender, EventArgs e)
        {
            var srcA = new Mat(@"Images\IMG_20151020_155510557.jpg", ImreadModes.GrayScale);
            var srcB = new Mat(@"Images\IMG_20151020_155516713.jpg", ImreadModes.GrayScale);

            var srcC = new Mat(@"Images\IMG_20151020_155510557.jpg", ImreadModes.GrayScale);
            var srcD = new Mat(@"Images\IMG_20151020_155508729.jpg", ImreadModes.GrayScale);
        }

        // color comparison of translated image
        private void button8_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(Constants.ImageD2_5);
            var src2 = new Mat(Constants.ImageD2_6);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // color comparison of translated image
        private void button9_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(Constants.ImageD2_5, ImreadModes.GrayScale);
            var src2 = new Mat(Constants.ImageD2_6, ImreadModes.GrayScale);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        public List<String> ImageNames
        {
            get { return _imageNames; }
            set { }
        }
        private static List<String> _imageNames = new List<string>
        {
            Constants.ImageControl1,
            Constants.ImageControl2,
            Constants.ImageTongsMoved,
            Constants.ImageTongsGone,
            Constants.ImageSpoonsMoved,
            Constants.ImageD2_1,
            Constants.ImageD2_2,
            Constants.ImageD2_3,
            Constants.ImageD2_4,
            Constants.ImageD2_5,
            Constants.ImageD2_6,
            Constants.ImageD2_7
        };
    }
}   
