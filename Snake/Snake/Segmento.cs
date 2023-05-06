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
        private PictureBox picBox;
        public PictureBox PicBox { get { return picBox; } }
        private int size;
        private Color color;
        public Keys Direccion { get; set; }
        public Segmento(Point pos, int size, Color color, Keys direccion)
        {
            picBox = new PictureBox();
            picBox.Location = pos;
            picBox.Size = new Size(size, size);
            picBox.BackColor = color;
            this.size = size;
            this.color = color;
            Direccion = direccion;
        }
    }
}
