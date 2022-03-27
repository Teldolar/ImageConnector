using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.ImageController;

namespace TestProject
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                Controller.AddImage(openFileDialog1.FileName);
        }

        private void ShowImage_Click(object sender, EventArgs e)
        {
            //Здесь задается ширина
            var tree = Controller.GerTree(500);
            Size = new Size(tree.BitmapImage.Width + 40, tree.BitmapImage.Height + 63);
            pictureBox1.Size = new Size(tree.BitmapImage.Width, tree.BitmapImage.Height);
            pictureBox1.Image = tree.BitmapImage;
        }
    }
}