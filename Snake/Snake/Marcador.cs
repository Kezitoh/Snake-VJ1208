using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Marcador
    {
        public Label Informacion { get { return informacion; } }
        private Label informacion = new Label();
        public int Puntos  { get; set; }
        public double TiempoVida { get; set; }
		public Marcador()
        {
            informacion.Font = new Font("Courier", 18);
            informacion.AutoSize = true;
            informacion.Location = new Point(0,0);
            informacion.BackColor = Color.Transparent;
            Puntos = 0;
            TiempoVida = 10;
            informacion.Text = $"Puntos: {Puntos}\nTiempo: {TiempoVida}";
        }

        public void Actualizar()
        {
            informacion.Text = $"Puntos: {Puntos}\nTiempo: {TiempoVida}";
            informacion.Refresh();
        }
    }
}
