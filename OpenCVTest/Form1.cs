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

        private void button1_Click(object sender, EventArgs e)
        {
            Mat src = new Mat(@"Images\IMG_20151020_155508729.jpg", ImreadModes.GrayScale);
            Mat dst = new Mat();

            Cv2.Canny(src, dst, 50, 200);

            using (new Window("src image", src)) // grey scale representation original method
            {
                Cv2.WaitKey();
            }

            using (new Window("dst image", dst)) // matrix representation of Canny method
            {
                Cv2.WaitKey();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var src1 = new Mat(@"C:\workspace\github\image-compare\OpenCVTest\Images\IMG_20151020_155510557.jpg");
            var src2 = new Mat(@"C:\workspace\github\image-compare\OpenCVTest\Images\IMG_20151020_155508729.jpg");
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

    }
}
