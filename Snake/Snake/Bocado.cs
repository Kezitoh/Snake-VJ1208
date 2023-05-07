using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Bocado
    {
        public double Duracion { get; set; }
        private int valor;
        public int Valor { get { return valor; } }
        PictureBox picBox;
        public PictureBox PicBox { get { return picBox; } }
        double timer;
        public double Timer { get { return timer; } }

        public Bocado(double duracion, int valor, Point punto) 
        {
            picBox = new PictureBox();
            picBox.Location = punto;
            //picBox.BackColor = Color.Red;
            picBox.Size = new Size(10,10);
            Duracion = duracion;
            this.valor = valor;
            timer = 0;
            switch (valor)
            {
                case 2:
                    picBox.BackColor = Color.Yellow;
                    break;
				case 3:
					picBox.BackColor = Color.YellowGreen;
					break;
				case 4:
					picBox.BackColor = Color.Green;
					break;
				case 5:
					picBox.BackColor = Color.DarkGreen;
					break;
				case 6:
					picBox.BackColor = Color.Red;
					break;
			}

        }

        public void Actualizar()
        {
            timer++;
            picBox.Refresh();

        }

    }
}
