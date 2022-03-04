using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Jugador
    {
        private int maxAmonestaciones
        {
            get; set;
        }
        private int maxFaltas
        {
            get; set;
        }

        private Random rand
        {
            get; set;
        }

        private int minEnergia
        {
            get; set;
        }

        public string nombre
        { get;  
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
                if(maxAmonestaciones <= value){
                    // amonestacionesMaximoExcedido();
                }
                else{
                    if (value < 0){
                        _amonestaciones = 0;
                    }
                    else{
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
                    //faltasMaximoExcedido();
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
                if(value < minEnergia)
                {
                    // energiaMinimaExcedida();
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

        
    }
}
