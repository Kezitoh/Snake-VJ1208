using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Snake
{
	internal class Serpiente
	{
		public List<Segmento> cuerpo { get; set; }
		public Segmento cabeza;
		public PictureBox picBox;
		public List<PictureBox> picCuerpo;
		public Giro giro;
		public Serpiente(Point posInicial)
		{
			picCuerpo = new List<PictureBox>();
			cuerpo = new List<Segmento>();
			cabeza = new Segmento(posInicial, 20, Color.Green, "");
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 20), 20, Color.LightGreen, ""));
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 40), 20, Color.LightGreen, ""));
			picBox = cabeza.PicBox;
			picCuerpo.Add(cuerpo[0].PicBox);
			picCuerpo.Add(cuerpo[1].PicBox);

		}

		public void MoverSerpiente(Direcciones d)
		{
			switch (d)
			{
				case Direcciones.Arriba:
					picBox.Top -= 1;
					break;
				case Direcciones.Abajo:
					picBox.Top += 1;
					break;
				case Direcciones.Izquierda:
					picBox.Left -= 1;
					break;
				case Direcciones.Derecha:
					picBox.Left += 1;
					break;
			}
		}

		public void MoverCuerpo(Giro g)
		{
			for (int i = 0; i < cuerpo.Count; i++)
			{
				for (int j = g.giros.Count - 1; j >= 0; j--)
				{
					switch (g.giros[j])
					{
						case Direcciones.Arriba:
							cuerpo[i].PicBox.Top -= 1;
							break;
						case Direcciones.Abajo:
							cuerpo[i].PicBox.Top += 1;
							break;
						case Direcciones.Izquierda:
							cuerpo[i].PicBox.Left -= 1;
							break;
						case Direcciones.Derecha:
							cuerpo[i].PicBox.Left += 1;
							break;
					}
				}
			}
			g.giros.Remove(g.giros[0]);
		}
	}
}
