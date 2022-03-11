using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Jugador
    {
        public static int maxAmonestaciones
        {
            get; set;
        }
        public static int maxFaltas
        {
            get; set;
        }

        public static Random rand
        {
            get; set;
        }

        public static int minEnergia
        {
            get; set;
        }

        public string nombre
        {
            get;
            private set;
        }

        public int puntos
        {
            get; set;
        }


        private int _amonestaciones;

        public int amonestaciones
        {
            get
            {
                return _amonestaciones;
            }
            set
            {
                if (maxAmonestaciones <= value)
                {
                    _amonestaciones = value;
                    amonestacionesMaximoExcedido(this, new AmonestacionesMaximoExcedidoArgs(amonestaciones));
                }
                else
                {
                    if (value < 0)
                    {
                        _amonestaciones = 0;
                    }
                    else
                    {
                        _amonestaciones = value;
                    }

                }
            }
        }

        private int _faltas;
        public int faltas
        {
            get { return _faltas; }

            set
            {
                if (value > maxFaltas)
                {
                    _faltas = value;
                    faltasMaximoExcedido(this, new FaltasMaximoExcedidoArgs(faltas));
                }
                else
                {
                    _faltas = value;
                }
            }
        }

        private int _energia;

        public int energia
        {
            get { return _energia; }

            set
            {
                if (value < minEnergia)
                {
                    _energia = value;
                    energiaMinimaExcedida(this, new EnergiaMinimaExcedidaArgs(energia));
                }
                else
                {
                    if (value < 0)
                    {
                        _energia = 0;
                    }
                    else
                    {
                        if (value > 100)
                        {
                            _energia = 100;
                        }
                        else
                        {
                            _energia = value;
                        }
                    }
                }
            }
        }

        public Jugador(string nombre, int amonestaciones, int faltas, int energia, int puntos)
        {
            this.nombre = nombre;
            this.amonestaciones = amonestaciones;
            this.faltas = faltas;
            this.energia = energia;
            this.puntos = puntos;
        }

        public void incAmonestaciones()
        {
            amonestaciones += rand.Next(0, 3);
        }

        public void incFaltas()
        {
            faltas += rand.Next(0, 4);
        }

        public void decEnergia()
        {
            energia -= rand.Next(1, 8);
        }

        public void incPuntos()
        {
            puntos += rand.Next(0, 4);
        }

        public bool todoOk()
        {
            return (amonestaciones <= maxAmonestaciones) && (energia >= minEnergia) && (faltas <= maxFaltas);
           
        }

        public void mover()
        {
            if (todoOk() == true)
            {
                incAmonestaciones();
                incFaltas();
                incPuntos();
                decEnergia();
            }
        }

        public override string ToString()
        {
            string salida = "";
            salida += "[" + nombre + "] Puntos: " + puntos + "; Amonestaciones: " + amonestaciones + "; Faltas: " + faltas + "; Energía: " + energia + " %; Ok:" + todoOk();
            return salida;
        }
        public event EventHandler<AmonestacionesMaximoExcedidoArgs> amonestacionesMaximoExcedido;
        public event EventHandler<FaltasMaximoExcedidoArgs> faltasMaximoExcedido;
        public event EventHandler<EnergiaMinimaExcedidaArgs> energiaMinimaExcedida;
    }
        public class AmonestacionesMaximoExcedidoArgs : EventArgs
        {
            public int amonestacion { get; set; }
            public AmonestacionesMaximoExcedidoArgs(int amon)
            {
                amonestacion = amon;
            }
        }

        public class FaltasMaximoExcedidoArgs : EventArgs
        {
            public int faltas { get; set; }
            public FaltasMaximoExcedidoArgs(int f)
            {
                faltas = f;
            }
        }

        public class EnergiaMinimaExcedidaArgs : EventArgs
        {
            public int energia { get; set; }
            public EnergiaMinimaExcedidaArgs(int ener)
            {
                energia = ener;
            }
        }

    
}
