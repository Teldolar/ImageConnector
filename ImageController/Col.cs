using System;
using System.Drawing;
using System.Linq;

namespace TestProject._3Controller
{
    /// <summary>
    /// Класс для хранения колонок из фреймов
    /// </summary>
    public class Col : Frame
    {
        public Col()
        {
            Width = 0;
            Height = 0;
            BitmapImage = new Bitmap(1, 1);
        }

        
        public override void Resize(double value, EdgeType edgeType)
        {
            Width = Math.Round(Width*value/Height);
            Height = value;
            foreach (var frame in ChildFrames)
            {
                frame.Resize(Width,EdgeType.Width);
            }
            BitmapImage = new Bitmap(BitmapImage, (int)Width, (int)Height);
        }
        
        public override void Align()
        {
            //Linq-запрос для выравнивания объекта внутри фрейма, если его размеры равны 0
            foreach (var frame in ChildFrames.Where(frame => frame.Width==0 || frame.Height==0))
            {
                frame.Align();
            }
            //Масштабирование каждого объекта относительно 1
            foreach (var frame in ChildFrames)
            {
                frame.Resize(ChildFrames[0].Width,EdgeType.Width);
                Height = Height + frame.Height;
            }
            Width = ChildFrames[0].Width;
        }
        
        
        public override Bitmap DrawImage()
        {
            var g = Graphics.FromImage(BitmapImage);
            double currHeight = 0;
            foreach (var frame in ChildFrames)
            {
                g.DrawImage(frame.DrawImage(),0,(int)currHeight);
                currHeight = currHeight + frame.Height;
            }
            return BitmapImage;
        }
    }
}