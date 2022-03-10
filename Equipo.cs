using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada

{
    class Equipo
    {
        public int minJugadores { get; set; }
        public int maxNumeroMovimientos { get; set; }
        public int movimientos { get; private set; }
        public string nombreEquipo { get; private set; }

        public Equipo(int nj, string nom)
        {
            nombreEquipo = nom;
            for(int i=0; i< nj; i++){
                string nombre = "jugador_" + i;

            }
        }
    }
}
