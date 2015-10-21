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
            return FindFeatures_ORB(filename);
            //return FindFeatures_HarrisCornerDetector(filename);
        }

        private IEnumerable<KeyPoint> FindFeaturesDescriptors_ORB(string filename, out Mat descriptors)
        {
            using (var gray = new Mat(filename, ImreadModes.GrayScale))
            {
                // ORB
                var orb = ORB.Create(250);
                KeyPoint[] keypoints = orb.Detect(gray);

                descriptors = new Mat();
                orb.Compute(gray, ref keypoints, descriptors);

                return keypoints;
            }
        }

        private IEnumerable<KeyPoint> FindFeatures_ORB(string filename)
        {
            using (var gray = new Mat(filename, ImreadModes.GrayScale))
            {
                // ORB
                var orb = ORB.Create(1000);
                KeyPoint[] keypoints = orb.Detect(gray);
                
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
            var file2 = Constants.ImageTongsMoved;

            using (var img1 = new Mat(file1, ImreadModes.GrayScale))
            using (var img2 = new Mat(file2, ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                // find keypoints
                //var kp1 = FindFeatures(Constants.ImageControl1);
                //var kp2 = FindFeatures(Constants.ImageControl2);

                // find descriptors
                var descriptors1 = new Mat();
                var descriptors2 = new Mat();

                var kp1 = FindFeaturesDescriptors_ORB(file1, out descriptors1);
                var kp2 = FindFeaturesDescriptors_ORB(file2, out descriptors2);

                // find keypoint matches
                var bfMatcher = new BFMatcher(NormTypes.L2, false);
                DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);

                // draw things
                Cv2.DrawMatches(img1, kp1, img2, kp2, bfMatches, dst);
                using (new Window("ORB matching (by BFMatcher)", WindowMode.FreeRatio, dst))
                {
                    Cv2.WaitKey();
                }
            }
        }
    }
}