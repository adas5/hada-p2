using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada

{
    class Equipo
    {
        public static int minJugadores { get; set; }
        public static int maxNumeroMovimientos { get; set; }
        public int movimientos { get; private set; }
        public string nombreEquipo { get; private set; }
        public List<Jugador> jugadores { get; set; }

        public List<Jugador> MaxAmonestJug { get; set; }
        public List<Jugador> MaxfaltaJug { get; set; }
        public List<Jugador> MaxEnergiaJug { get; set; }

        public Equipo(int nj, string nom)
        {
            jugadores = new List<Jugador>();
            MaxAmonestJug = new List<Jugador>();
            MaxfaltaJug = new List<Jugador>();
            MaxEnergiaJug = new List<Jugador>();
            movimientos = 0;
            nombreEquipo = nom;
            for(int i=1; i<= nj; i++){
                string nombre = "jugador_" + i;
                Jugador j = new Jugador(nombre, 0, 0, 50, 0);
                j.amonestacionesMaximoExcedido += amonestadosmax;
                j.energiaMinimaExcedida+= energiamax;
                j.faltasMaximoExcedido += faltasmax;
                jugadores.Add( j);

            }
        }

        public bool moverJugadores()
        {
            bool mov;
            int cont = 0;
            
            
                for(int i =0; i< jugadores.Count(); i++) {
                    if (jugadores[i].todoOk() ){
                        jugadores[i].mover();
                        cont++;
                        
                    }
                }
            
            if (cont >= minJugadores){
                mov = true;
                }
            else { mov = false; }


            movimientos += 1;
            return mov;
        }

        public void moverJugadoresEnBucle()
        {
            bool sigue = false;
            do
            {
                sigue = moverJugadores();
                movimientos += 1;
            } while (sigue);
        }

        public int sumarPuntos()
        {
            int puntos = 0;
            for(int i=0; i< jugadores.Count(); i++)
            {
                puntos += jugadores[i].puntos;
            }
            return puntos;
        }
        public List<Jugador> getJugadoresExcedenLimiteAmonestaciones()
        {
            return MaxAmonestJug;


        }

        public List<Jugador> getJugadoresExcedenLimiteFaltas()
        {
            return MaxfaltaJug;
        }

        public List<Jugador> getJugadoresExcedenMinimoEnergia()
        {
            return MaxEnergiaJug;
        }

        public override string ToString()
        {
            string salida = "";
            salida += "[" + nombreEquipo + "] Puntos: " + sumarPuntos() + "; Expulsados: " + MaxAmonestJug.Count() + "; Lesionados: " + MaxfaltaJug.Count() + "; Retirados: " + MaxEnergiaJug.Count() + "\n";
            for(int i =0; i< jugadores.Count(); i++)
            {
                salida += jugadores[i] + "\n";
            }

            return salida;
            
        }

        public void amonestadosmax(object sender, AmonestacionesMaximoExcedidoArgs args)
        {
            Jugador p = (Hada.Jugador)sender;
            Console.WriteLine("¡¡Número máximo excedido de amonestaciones. Jugador expulsado!!");
            Console.WriteLine("Jugador: " + p.nombre);
            Console.WriteLine("Jugador: " + nombreEquipo);
            Console.WriteLine("Amonestaciones: " + args.amonestacion);
            MaxAmonestJug.Add(p);
        }
        public void faltasmax(object sender, FaltasMaximoExcedidoArgs args)
        {
            Jugador p = (Hada.Jugador)sender;
            Console.WriteLine("¡¡Número máximo excedido de faltas recibidas. Jugador lesionado!!");
            Console.WriteLine("Jugador: " + p.nombre);
            Console.WriteLine("Jugador: " + nombreEquipo);
            Console.WriteLine("Faltas: " + args.faltas);
            MaxfaltaJug.Add(p);
        }
        public void energiamax(object sender, EnergiaMinimaExcedidaArgs args)
        {
            Jugador p = (Hada.Jugador)sender;
            Console.WriteLine("¡¡Energía mínima excedida. Jugador retirado!!");
            Console.WriteLine("Jugador: " + p.nombre);
            Console.WriteLine("Jugador: " + nombreEquipo);
            Console.WriteLine("Energia: " + args.energia + " %");
            MaxEnergiaJug.Add(p);
        }
    }
}
