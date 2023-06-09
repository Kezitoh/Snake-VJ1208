﻿using System;
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
			cabeza = new Segmento(posInicial, 20, Color.Green, Direcciones.Arriba);
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 20), 20, Color.LightGreen, Direcciones.Arriba));
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 40), 20, Color.LightGreen, Direcciones.Arriba));
			picBox = cabeza.PicBox;
			picCuerpo.Add(cuerpo[0].PicBox);
			picCuerpo.Add(cuerpo[1].PicBox);
			giro = new Giro(new Dictionary<Point, Direcciones>());
		}

		public void MoverSerpiente()
		{
			switch (cabeza.Direccion)
			{
				case Direcciones.Arriba:
					picBox.Top -= 20;
					break;
				case Direcciones.Abajo:
					picBox.Top += 20;
					break;
				case Direcciones.Izquierda:
					picBox.Left -= 20;
					break;
				case Direcciones.Derecha:
					picBox.Left += 20;
					break;
			}
			
			MoverCuerpo();
		}

		public void MoverCuerpo()
		{
			for (int i = 0; i < cuerpo.Count; i++)
			{
				if (giro.Giros.ContainsKey(cuerpo[i].Pos))
				{
					cuerpo[i].Direccion = giro.Giros[cuerpo[i].Pos];
				}
				
				switch (cuerpo[i].Direccion)
				{
					case Direcciones.Arriba:
						cuerpo[i].PicBox.Top -= 20;
						break;
					case Direcciones.Abajo:
						cuerpo[i].PicBox.Top += 20;
						break;
					case Direcciones.Izquierda:
						cuerpo[i].PicBox.Left -= 20;
						break;
					case Direcciones.Derecha:
						cuerpo[i].PicBox.Left += 20;
						break;
				}
				
			}
			if (giro.Giros.Count > 0)
			{
				giro.Giros.Remove(giro.Giros.Keys.First()); // Vamos a la lista de claves y sacamos la primera posición para borrar la pareja de datos
			}
		}
	}
}
