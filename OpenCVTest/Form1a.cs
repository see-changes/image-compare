using System;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
namespace OpenCVTest
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Keypoint detection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            using (var src = new Mat(@"Images\IMG_20151020_155508729.jpg", ImreadModes.GrayScale))
            using (var dst = new Mat(@"Images\IMG_20151020_155508729.jpg", ImreadModes.GrayScale))
            {
                // find íntersting corners
                var corners = src.GoodFeaturesToTrack(100, 0.01, 100, null, 15, true, 1);

                var keypoints = corners.Select(s => new KeyPoint(s, 100));

                if (keypoints != null)
                {
                    int thickness = 5;
                    foreach (var kp in keypoints)
                    {
                        var r = kp.Size/2;
                        Cv2.Circle(dst, kp.Pt, (int)r, Scalar.Red, thickness);
                        Cv2.Line(dst,
                            new Point2f(kp.Pt.X + r, kp.Pt.Y + r),
                            new Point2f(kp.Pt.X - r, kp.Pt.Y - r),
                            Scalar.Red, thickness);
                        Cv2.Line(dst,
                            new Point2f(kp.Pt.X - r, kp.Pt.Y - r),
                            new Point2f(kp.Pt.X + r, kp.Pt.Y + r),
                            Scalar.Red, thickness);
                    }
                }

                //Cv2.DrawKeypoints(src, keypoints, dst, Scalar.Red);

                using (new Window("src w. keypoints", WindowMode.FreeRatio, dst))
                {
                    Cv2.WaitKey();
                }
        }
        }
    }
}
