using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    enum Direcciones { Izquierda, Derecha, Arriba, Abajo }
    internal class Giro
    {
        public Dictionary<Point, Direcciones> Giros { get; set; }

        public Giro(Dictionary<Point,Direcciones> giros)
        {
            Giros = giros;
        }
    }
}
