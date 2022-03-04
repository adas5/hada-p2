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

        private int minEnergia
        {
            get; set;
        }
 
        private int amonestaciones
        {
            get
            {
                return amonestaciones;
            }
            set
            {
                if(maxAmonestaciones <= value)
                {
                    throw new amonestacionesMaximoExcedido();
                }
                else
                {
                    if (value < 0)
                    {
                        amonestaciones = 0;
                    }
                    else
                    {
                        amonestaciones = value;
                    }
                   
                }
            }
        }
        
    }
}
