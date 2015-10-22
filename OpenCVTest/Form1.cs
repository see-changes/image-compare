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
            var src1 = new Mat(comboBox1.SelectedItem.ToString(), ImreadModes.GrayScale);
            var src2 = new Mat(comboBox2.SelectedItem.ToString(), ImreadModes.GrayScale);
            var output = new Mat();

            Cv2.Absdiff(src1, src2, output);

            using (new Window("output of abs diff", WindowMode.KeepRatio, output))
            {
                Cv2.WaitKey();
            }
        }

        // grey scale comparison of translated image
        private void button4_Click(object sender, EventArgs e)
        {
            var src = new Mat(comboBox1.SelectedItem.ToString());

            using (new Window("image", WindowMode.KeepRatio, src))
            {
                Cv2.WaitKey();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var src = new Mat(comboBox2.SelectedItem.ToString());

            using (new Window("image", WindowMode.KeepRatio, src))
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
            Constants.ImageD2_7,
            Constants.Trailer_Close_1,
            Constants.Trailer_Open_1,
            Constants.Trailer_Close_2,
            Constants.Trailer_Open_2,
        };
    }
}   
