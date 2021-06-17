using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Entroptik
{
    public static class Imaging
    {

        public static void ShowImage(string filePath)
        {
            Bitmap img = new Bitmap(filePath);
            FileHandler.PictureBox.Image = img;
        }
    }
}
