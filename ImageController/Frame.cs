using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestProject._3Controller
{
    /// <summary>
    /// Базовый класс для всех возможных фреймов (строки, колонки, изображения)
    /// </summary>
    public abstract class Frame
    {
        /// <summary>
        /// Изображение фрейма
        /// </summary>
        public Bitmap BitmapImage;
        public double Width { get; set; }
        public double Height { get; set; }
        
        /// <summary>
        /// Список дочерних фреймов
        /// </summary>
        protected readonly List<Frame> ChildFrames = new();
        
        /// <summary>
        /// Метод добавляющий дочерний фрейм в конец списка, и возвращающий текущий фрейм
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Frame Add(Frame field)
        {
            ChildFrames.Add(field);
            return this;
        }
        
        /// <summary>
        /// Метод для сохранения получившегося изображения в файл
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveImage(string filePath)
        {
            DrawImage().Save(filePath);
        }
        
        /// <summary>
        /// Метод для масштабирования выровненного фрейма
        /// </summary>
        /// <param name="value">Колличество пикселей, на которые необходимо масштабировать ту или иную сторону</param>
        /// <param name="edgeType">Сторона, на основе которой масштабируется фрейм</param>
        public abstract void Resize(double value, EdgeType edgeType);

        /// <summary>
        /// Метод для выравнивания объектов внутри фрейма относительно первого объекта
        /// </summary>
        public abstract void Align();

        /// <summary>
        /// Метод для отрисовки изображения
        /// </summary>
        /// <returns>Возвращает получившееся изображение</returns>
        public abstract Bitmap DrawImage();
        
        
    }

    public enum EdgeType
    {
        Width,
        Height
    }
}