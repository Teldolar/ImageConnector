using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestProject.ImageController
{
    /// <summary>
    /// Контроллер изображений
    /// </summary>
    public static class Controller
    {
        private static List<Bitmap> _images = new List<Bitmap>();
        private static readonly List<Col> Cols = new List<Col>();
        private static readonly List<Row> Rows = new List<Row>();
        public static int CompressionRatio = 1;
        /// <summary>
        /// Метод возвращающий дерево изображений
        /// </summary>
        /// <returns>Первая строка</returns>
        public static Frame GerTree()
        {
            Rows.RemoveRange(0, Rows.Count);
            Cols.RemoveRange(0, Cols.Count);
            Rows.Add(new Row());
            foreach (var image in _images)
            {
                if (image.Width / image.Height > 100 || image.Height / image.Width > 100)
                {
                    CompressionRatio = 5;
                }
            }
            AddCol(Rows[0]);
            Rows[0].Align();
            Rows[0].Resize(500, EdgeType.Width);
            Rows[0].DrawImage();
            return Rows[0];
        }

        /// <summary>
        /// Метод добавляющий колонку в строку
        /// </summary>
        /// <param name="row">Строка в которую добавляется колонка</param>
        public static void AddCol(Row row)
        {
            var random = new Random();
            while (_images.Count > 0)
            {
                if (_images.Count <= 0) return;
                var a = random.Next(1, 3);
                switch (a)
                {
                    case 1:
                        row.Add(new Image(_images.Last()));
                        _images.RemoveAt(_images.IndexOf(_images.Last()));
                        break;
                    case 2:
                        Cols.Add(new Col());
                        row.Add(Cols.Last());
                        AddRow(Cols.Last());
                        break;
                }
            }
        }

        /// <summary>
        /// Метод добавляющий строку в колонку
        /// </summary>
        /// <param name="col">колонка в которую добавляется строка</param>
        public static void AddRow(Col col)
        {
            var random = new Random();
            while (_images.Count > 0)
            {
                if (_images.Count <= 0) return;
                var a = random.Next(1, 3);
                switch (a)
                {
                    case 1:
                        col.Add(new Image(_images.Last()));
                        _images.RemoveAt(_images.IndexOf(_images.Last()));
                        break;
                    case 2:
                        Rows.Add(new Row());
                        col.Add(Rows.Last());
                        AddCol(Rows.Last());
                        break;
                }
            }
        }

        /// <summary>
        /// Добавление изображения в список
        /// </summary>
        /// <param name="filePath">Путь к изображению</param>
        public static void AddImage(string filePath)
        {
            _images.Add(new Bitmap(filePath));
        }
    }
}