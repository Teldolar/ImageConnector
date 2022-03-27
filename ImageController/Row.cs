using System;
using System.Drawing;
using System.Linq;

namespace TestProject.ImageController
{
    /// <summary>
    /// Класс для хранения строк из фреймов
    /// </summary>
    public class Row : Frame
    {
        public Row()
        {
            Width = 0;
            Height = 0;
            BitmapImage = new Bitmap(1, 1);
        }

        public override void Resize(double value, EdgeType edgeType)
        {
            Height = Math.Round(Height * value / Width);
            Width = value;
            foreach (var frame in ChildFrames)
            {
                frame.Resize(Height, EdgeType.Height);
            }
            BitmapImage = new Bitmap(BitmapImage, (int)Width, (int)Height);
        }


        public override void Align()
        {
            //Linq-запрос для выравнивания объекта внутри фрейма, если его размеры равны 0
            foreach (var frame in ChildFrames.Where(frame => frame.Height == 0 || frame.Width == 0))
            {
                frame.Align();
            }

            double maxHeight = ChildFrames.Select(frame => frame.Height).Prepend(0).Max();


            //Масштабирование каждого объекта относительно 1
            foreach (var frame in ChildFrames)
            {
                frame.Resize(maxHeight / Controller.CompressionRatio, EdgeType.Height);
                Width = Width + frame.Width;
            }
            Height = ChildFrames[0].Height;
        }

        public override Bitmap DrawImage()
        {
            Graphics graphics = Graphics.FromImage(BitmapImage);
            double currWidth = 0;
            foreach (var frame in ChildFrames)
            {
                graphics.DrawImage(frame.DrawImage(), (int)currWidth, 0);
                currWidth += frame.Width;
            }

            return BitmapImage;
        }
    }
}