using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;

namespace OpenCVTest
{
    public partial class Form1 : Form
    {
        /// <summary>
        ///     Keypoint detection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string filename;

            filename = Constants.ImageControl1;
            DrawFeatures(filename, FindFeatures(filename));

            filename = Constants.ImageControl2;
            DrawFeatures(filename, FindFeatures(filename));
        }

        private IEnumerable<KeyPoint> FindFeatures(string filename)
        {
            return FindFeatures_FREAK(filename);
            //return FindFeatures_HarrisCornerDetector(filename);
        }

        private IEnumerable<KeyPoint> FindFeatures_FREAK(string filename)
        {
            using (var gray = new Mat(filename, ImreadModes.GrayScale))
            {
                // ORB
                var orb = ORB.Create(1000);
                KeyPoint[] keypoints = orb.Detect(gray);

                // FREAK
                FREAK freak = FREAK.Create();

                Mat freakDescriptors = new Mat();
                freak.Compute(gray, ref keypoints, freakDescriptors);

                return keypoints;
            }
        }

        private IEnumerable<KeyPoint> FindFeatures_HarrisCornerDetector(string filename)
        {
            using (var src = new Mat(filename, ImreadModes.GrayScale))
            {
                // find ínteresting corners
                Point2f[] corners = src.GoodFeaturesToTrack(100, 0.01, 100, null, 15, true, 1);

                IEnumerable<KeyPoint> keypoints = corners.Select(s => new KeyPoint(s, 100));
                return keypoints;
            }
        }

        private void DrawFeatures(string filename, IEnumerable<KeyPoint> keypoints)
        {
            using (var dst = new Mat(filename, ImreadModes.GrayScale))
            {
                int thickness = 2;
                foreach (KeyPoint kp in keypoints)
                {
                    float r = kp.Size/2;
                    Cv2.Circle(dst, kp.Pt, (int) r, Scalar.Red, thickness);
                    Cv2.Line(dst,
                        new Point2f(kp.Pt.X + r, kp.Pt.Y + r),
                        new Point2f(kp.Pt.X - r, kp.Pt.Y - r),
                        Scalar.Red, thickness);
                    Cv2.Line(dst,
                        new Point2f(kp.Pt.X - r, kp.Pt.Y - r),
                        new Point2f(kp.Pt.X + r, kp.Pt.Y + r),
                        Scalar.Red, thickness);
                }

                using (new Window("src w. keypoints", WindowMode.FreeRatio, dst))
                {
                    Cv2.WaitKey();
                }
            }
        }

        private void FindMatchingFeatures_Click(object sender, EventArgs e)
        {
            var file1 = Constants.ImageControl1;
        }
    }
}