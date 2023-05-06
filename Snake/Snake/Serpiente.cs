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
		public List<Giro> giros;
		public Serpiente(Point posInicial)
		{
			picCuerpo = new List<PictureBox>();
			cuerpo = new List<Segmento>();
			cabeza = new Segmento(posInicial, 20, Color.Green, Keys.Up);
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 20), 20, Color.LightGreen, Keys.Up));
			cuerpo.Add(new Segmento(new Point(posInicial.X, posInicial.Y + 40), 20, Color.LightGreen, Keys.Up));
			picBox = cabeza.PicBox;
			picCuerpo.Add(cuerpo[0].PicBox);
			picCuerpo.Add(cuerpo[1].PicBox);
			giros = new List<Giro>();
		}

		public void Actualizar()
		{
			switch (cabeza.Direccion)
			{
                case Keys.Up:
					cabeza.PicBox.Location = new Point(cabeza.PicBox.Location.X, cabeza.PicBox.Location.Y-1);
					break;
				case Keys.Down:
					cabeza.PicBox.Location = new Point(cabeza.PicBox.Location.X, cabeza.PicBox.Location.Y+1);
					break;
				case Keys.Left:
					cabeza.PicBox.Location = new Point(cabeza.PicBox.Location.X-1, cabeza.PicBox.Location.Y);
					break;
				case Keys.Right:
					cabeza.PicBox.Location = new Point(cabeza.PicBox.Location.X+1, cabeza.PicBox.Location.Y);
					break;
			}
			
			MoverCuerpo();
			Dibujar();
		}

        private void Dibujar()
        {
			cabeza.PicBox.Refresh();
			foreach(Segmento segmento in cuerpo)
			{
				segmento.PicBox.Refresh();
			}
        }

        public void MoverCuerpo()
		{
			for (int i = 0; i < cuerpo.Count; i++)
			{
                //Console.WriteLine($"Pos: {cuerpo[i].PicBox.Location}, Existe: {giros.Find(x => x.Punto == cuerpo[i].PicBox.Location)}");
                if (giros.Exists(x => x.Punto == cuerpo[i].PicBox.Location))
				{
					cuerpo[i].Direccion = giros.Find(x => x.Punto == cuerpo[i].PicBox.Location).Direccion;
					if (cuerpo[i] == cuerpo[cuerpo.Count-1])
					{
						giros.Remove(giros[0]); // Vamos a la lista de claves y sacamos la primera posición para borrar la pareja de datos
					}
				}
				
				switch (cuerpo[i].Direccion)
				{
					case Keys.Up:
						cuerpo[i].PicBox.Location = new Point(cuerpo[i].PicBox.Location.X, cuerpo[i].PicBox.Location.Y - 1);
						break;
					case Keys.Down:
						cuerpo[i].PicBox.Location = new Point(cuerpo[i].PicBox.Location.X, cuerpo[i].PicBox.Location.Y + 1); 
						break;
					case Keys.Left:
						cuerpo[i].PicBox.Location = new Point(cuerpo[i].PicBox.Location.X - 1, cuerpo[i].PicBox.Location.Y);
						break;
					case Keys.Right:
						cuerpo[i].PicBox.Location = new Point(cuerpo[i].PicBox.Location.X + 1, cuerpo[i].PicBox.Location.Y);
						break;
				}
				
			}
			
		}

		public Segmento AddCuerpo()
		{
			Point punto = new Point();
			switch(cuerpo.Last().Direccion)
			{
				case Keys.Up:
					punto = new Point(cuerpo.Last().PicBox.Location.X, cuerpo.Last().PicBox.Location.Y + 20);
                    break;
				case Keys.Down:
					punto = new Point(cuerpo.Last().PicBox.Location.X, cuerpo.Last().PicBox.Location.Y - 20);
                    break;
				case Keys.Left:
					punto = new Point(cuerpo.Last().PicBox.Location.X + 20, cuerpo.Last().PicBox.Location.Y);
                    break;
				case Keys.Right:
					punto = new Point(cuerpo.Last().PicBox.Location.X - 20, cuerpo.Last().PicBox.Location.Y);
                    break;
			}
			Segmento segmento = new Segmento(punto, 20, Color.LightGreen, cuerpo.Last().Direccion);
			cuerpo.Add(segmento);
			return segmento;
        }

	}
}
