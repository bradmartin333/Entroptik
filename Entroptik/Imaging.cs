using System.Drawing;

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
