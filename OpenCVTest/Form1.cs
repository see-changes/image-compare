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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // color comparison of translated image
        private void button1_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(@"Images\IMG_20151020_155510557.jpg");
            var src2 = new Mat(@"Images\IMG_20151020_155508729.jpg");
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
            var src1 = new Mat(@"Images\IMG_20151020_155510557.jpg", ImreadModes.GrayScale);
            var src2 = new Mat(@"Images\IMG_20151020_155508729.jpg", ImreadModes.GrayScale);
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
            var src1 = new Mat(@"Images\IMG_20151020_155510557.jpg");
            var src2 = new Mat(@"Images\IMG_20151020_155516713.jpg");
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
            var src1 = new Mat(@"Images\IMG_20151020_155510557.jpg", ImreadModes.GrayScale);
            var src2 = new Mat(@"Images\IMG_20151020_155516713.jpg", ImreadModes.GrayScale);
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
    }
}
