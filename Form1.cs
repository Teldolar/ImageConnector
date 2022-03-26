using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject._3Controller;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var image = Controller.SplitImage();
            InitializeComponent();
            Size = new Size(image.Width + 40, image.Height + 63);
            pictureBox1.Image = image;
        }
    }
}