using System.Drawing;

namespace TestProject.ImageController
{
    public class Image : Frame
    {
        public Image(Bitmap image)
        {
            BitmapImage = image;
            Width = BitmapImage.Width;
            Height = BitmapImage.Height;
        }

        public override void Resize(double value, EdgeType edgeType)
        {
            switch (edgeType)
            {
                case EdgeType.Height:
                    {
                        Width *= value / Height;
                        Height = value;
                        BitmapImage = new Bitmap(BitmapImage, (int)Width, (int)value);
                        break;
                    }
                case EdgeType.Width:
                    {
                        Height *= value / Width;
                        Width = value;
                        BitmapImage = new Bitmap(BitmapImage, (int)Width, (int)Height);
                        break;
                    }
            }
        }

        public override Bitmap DrawImage()
        {
            return BitmapImage;
        }

        public override void Align()
        {
            throw new System.NotImplementedException();
        }
    }
}