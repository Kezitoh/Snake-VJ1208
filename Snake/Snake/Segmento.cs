using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    internal class Segmento
    {
        private PictureBox picBox = new PictureBox();
        public PictureBox PicBox { get { return picBox; } }
        private Point pos;
        private int size;
        private Color color;
        private string direccion;
        public Segmento(Point pos, int size, Color color, string direccion)
        {
            picBox.Location = pos;
            picBox.Size = new Size(size, size);
            picBox.BackColor = color;
            this.pos = pos;
            this.size = size;
            this.color = color;
            this.direccion = direccion;
        }
    }
}
