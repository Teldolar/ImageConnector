using System.Collections.Generic;
using System.Drawing;

namespace TestProject._3Controller
{
    public static class Controller
    {
        /// <summary>
        /// Метод сливающий изображения по заданному древу
        /// </summary>
        public static Bitmap SplitImage(bool needToSave = false, string filePath="")
        {
            List<Col> cols = new (1)
            {
                new Col()
            };
            
            List<Row> rows = new (2)
            {
                new Row(),
                new Row()
            };

            rows[0].Add(new Image("C:\\Users\\artur\\Desktop\\TestProject\\TestProject\\1.jpg")).Add(cols[0]);
            cols[0].Add(rows[1]).Add(new Image("C:\\Users\\artur\\Desktop\\TestProject\\TestProject\\2.jpg"));
            rows[1].Add(new Image("C:\\Users\\artur\\Desktop\\TestProject\\TestProject\\3.jpg")).Add(new Image("C:\\Users\\artur\\Desktop\\TestProject\\TestProject\\4.jpg"));
            
            rows[0].Align();
            rows[0].Resize(500,EdgeType.Width);
            if(needToSave)
            {
                rows[0].DrawImage().Save(filePath);
            }
            return rows[0].BitmapImage;
        }
    }
}