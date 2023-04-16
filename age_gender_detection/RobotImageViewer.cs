using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace age_gender_detection
{
    public partial class RobotImageViewer : UserControl
    {
        public RobotImageViewer()
        {
            InitializeComponent();
            String searchFolder = Application.StartupPath + "/images";
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            files = GetFilesFrom(searchFolder, filters, false);
            Thread ImageChanger = new Thread(() => ShowPictures());
            ImageChanger.IsBackground = true;
            ImageChanger.Start();
        }

        private void ShowPictures()
        {
            while (true)
            {
                foreach (string picturePath in files)
                {
                    Thread.Sleep(2000);
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    this.BackgroundImage = Image.FromFile(picturePath);
                }
            }
        }

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        String[] files;
    }
}
