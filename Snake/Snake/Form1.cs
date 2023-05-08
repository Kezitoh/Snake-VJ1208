using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private const int anchoEscenario = 735;
        private const int altoEscenario = 500;
        private Marcador marcador;
        private Serpiente serpiente;
        private Comidas comida;
        private const Keys arriba = Keys.Up;
        private const Keys abajo = Keys.Down;
        private const Keys izquierda = Keys.Left;
        private const Keys derecha = Keys.Right;
        private Stopwatch tiempo;
        private double ultimoTiempo;
        double contadorTiempo;
        private Keys ultimaDireccion;
        private Point posicion;
        bool flagDerrota = true;


		public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.UserPaint
                   | ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.SupportsTransparentBackColor, true);
            this.Text = "Serpiente VJ1208 ...";
            this.Width = anchoEscenario;
            this.Height = altoEscenario;
            this.BackColor = Color.LightGray;
            serpiente = new Serpiente(new Point(this.Width / 2, this.Height / 2)); 
            Controls.Add(serpiente.picBox); 
            Controls.Add(serpiente.picCuerpo[0]);
            Controls.Add(serpiente.picCuerpo[1]);
            comida = new Comidas(anchoEscenario, altoEscenario, serpiente, Controls);
            marcador = new Marcador();
            Controls.Add(marcador.Informacion);
            marcador.Informacion.SendToBack();
            tiempo = new Stopwatch();
            tiempo.Start();
            ultimoTiempo = 0.0;
            ultimaDireccion = arriba;

        }

        public bool Derrota()
        {
            bool derrota = false;
            if ((serpiente.cabeza.PicBox.Location.X <= 0 || serpiente.cabeza.PicBox.Location.X >= 700) ||
			(serpiente.cabeza.PicBox.Location.Y <= 0 || serpiente.cabeza.PicBox.Location.Y >= 440) ||
			(marcador.TiempoVida <= 0)) derrota = true;
			for (int i = 1; i < serpiente.cuerpo.Count; i++)
			{
                if (serpiente.cabeza.PicBox.Bounds.IntersectsWith(serpiente.cuerpo[i].PicBox.Bounds)) derrota = true;
			}
            
            return derrota;
		}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == arriba && ultimaDireccion == abajo) && 
                !(e.KeyCode == abajo && ultimaDireccion == arriba) && 
                !(e.KeyCode == izquierda && ultimaDireccion == derecha) && 
                !(e.KeyCode == derecha && ultimaDireccion == izquierda))
            { 
                switch (e.KeyCode)
                {
                    case arriba:
                        ultimaDireccion = arriba;
                        break;
                    case abajo:
                        ultimaDireccion = abajo;
                        break;
                    case izquierda:
                        ultimaDireccion = izquierda;
                        break;
                    case derecha:
                        ultimaDireccion = derecha;
                        break;
                }
                posicion = serpiente.cabeza.PicBox.Location;
                serpiente.cabeza.Direccion = ultimaDireccion;
                serpiente.giros.Add(new Giro(posicion, ultimaDireccion));
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Derrota())
            {
                if (flagDerrota)
                {
					flagDerrota = false;
					MessageBox.Show("Has perdido");
				}
            }
            else
            {
				double tiempoJuego = tiempo.ElapsedMilliseconds;
				double tiempoTranscurrido = tiempoJuego - ultimoTiempo;
				ultimoTiempo = tiempoJuego;
				contadorTiempo += tiempoTranscurrido;

				if (contadorTiempo % 10 == 0)
				{
					marcador.Actualizar();
					serpiente.Actualizar();
                    comida.Actualizar(marcador);
				}
				this.Invalidate();
			}

        }
    }
}
