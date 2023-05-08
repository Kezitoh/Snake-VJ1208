using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    internal class Comidas
    {
        List<Bocado> bocados;
        Random random;
        int anchoPantalla;
        public int AnchoPantalla { get; set; }
        int altoPantalla;
        public int AltoPantalla { get; set; }
        Serpiente serpiente;
        public Serpiente Serpiente { get; set; }
        Control.ControlCollection Controls;
        double timer;
        public Comidas(int anchoPantalla, int altoPantalla, Serpiente serpiente, Control.ControlCollection control) { 
            random = new Random();
            bocados = new List<Bocado>();
            this.altoPantalla = altoPantalla;
            this.anchoPantalla = anchoPantalla;
            this.serpiente = serpiente;
            Controls = control;
            timer = 0;
        }

        public void Actualizar(Marcador marcador)
        {
            if(timer > 0)
            {
                timer--;
            }

            if(timer <= 0 && bocados.Count < 4)
            {
                Bocado bocado = new Bocado(random.Next(10,17), random.Next(2,7), new Point(random.Next(0,anchoPantalla),random.Next(0,altoPantalla)));
                Controls.Add(bocado.PicBox);
                bocados.Add(bocado);
                bocado.PicBox.Refresh();
                timer = random.Next(3, 7)*100;
            }
            if(bocados.Count > 0)
            {
                foreach(Bocado bocado in bocados.ToList())
                { 
                    bocado.Actualizar();
                    if(bocado.Timer >= bocado.Duracion*100)
                    {
                        bocado.PicBox.Dispose();
                        bocados.Remove(bocado);

                    }else if ( bocado.PicBox.Bounds.IntersectsWith(serpiente.cabeza.PicBox.Bounds))
                    {
                        marcador.Puntos += bocado.Valor;
                        marcador.TiempoVida += bocado.Valor;
                        bocado.PicBox.Dispose();
                        bocados.Remove(bocado);
                        
                        Controls.Add(serpiente.AddCuerpo().PicBox);
                    }
                }
            }
        }
    }
}
