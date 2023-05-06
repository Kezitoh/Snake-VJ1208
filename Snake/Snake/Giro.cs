using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    
    internal class Giro
    {
        public Point Punto { get; set; }
        public Keys Direccion { get; set; }

        public Giro(Point punto, Keys key)
        {
            Punto = punto;
            Direccion = key;
        }
    }
}
