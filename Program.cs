using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Numerics;
using System.Runtime.Serialization.Formatters;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al tateti para que fausto pruebe el lenguaje de programación c#");
            Console.WriteLine();
            Console.WriteLine("¿Quieres iniciar una partida?");
            Console.WriteLine("si o no, fácil");

            bool comenzar = false;
            while (!comenzar)
            {
                string entrada = Console.ReadLine().ToLower().Trim();
                if (entrada.Equals("si"))
                {
                    comenzar = true;
                    Console.Clear();
                }
                else if (entrada.Equals("no"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Si o No, no es tan dificil bro");
                    Console.WriteLine("Dale mandale de nuevo, vos podés");
                }
            }

            Console.WriteLine("¿Quieres jugar de a 2 o contra la maquina?");
            Console.WriteLine("Ingresa Maquina o 2 segun quieras");

            comenzar = false;
            while (!comenzar)
            {
                string entrada = Console.ReadLine().ToLower().Trim();
                if (entrada.Equals("maquina"))
                {
                    Console.Clear();
                    Console.WriteLine("jajajajaja te pensas que se hacer una IA para que juegue contra vos dale contate otra, largando de a 2");
                    Console.WriteLine();
                    Console.WriteLine();
                    comenzar = true;
                }
                else if (entrada.Equals("2"))
                {
                    Console.Clear();
                    Console.WriteLine("Dale maquinola largando");
                    comenzar = true;
                }
                else
                {
                    Console.WriteLine("Dale man poneme una de las 2 opciones no seas tan trolo");
                }

            }

            //Registro de datos

            string nombre;
            Ficha ficha;

            //Jugador 1
            Console.Write("jugador1 ingresa tu nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Si quieres ser el O ingresa 1, si quieres la X, 2: ");
            ficha = (Ficha)int.Parse(Console.ReadLine());
            Jugador jugador1 = new Jugador(nombre, ficha);
            Console.Clear();

            //Jugador 2
            Console.Write("jugador2 ingresa tu nombre: ");
            nombre = Console.ReadLine();
            if (ficha.Equals(Ficha.O))
            {
                ficha = Ficha.X;
            }
            else
            {
                ficha = Ficha.O;
            }
            Jugador jugador2 = new Jugador(nombre, ficha);
            Console.Clear();

            bool ganador = false;
            bool empate = false;
            Jugador jugador_ganador = null;
            Tablero tablero = new Tablero();

            Console.WriteLine("El nombre del jugador 1 es: " + jugador1.Nombre);
            Console.WriteLine("La ficha asignada es: " + jugador1.Ficha);
            Console.WriteLine();
            Console.WriteLine("El nombre del jugador 2 es: " + jugador2.Nombre);
            Console.WriteLine("La ficha asignada es: " + jugador2.Ficha);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Para colocar la ficha ingresa la posicion que figura en el tablero");

            Console.WriteLine();
            Console.WriteLine();

            bool validar = true;

            while (!ganador || !empate)
            {

                //Turno jugador 1
                do
                {
                    tablero.imprimirTablero();
                    Console.Write("{0} ingresa una posición: ", jugador1.Nombre);
                    if (!tablero.jugar(jugador1.Ficha, Console.ReadLine()))
                    {
                        Console.Clear();
                        Console.WriteLine("La posicion esta ocupada");
                        Console.WriteLine();
                        Console.WriteLine();
                        validar = false;
                    }
                } while (!validar);

                if (tablero.hayGanador())
                {
                    ganador = true;
                    jugador_ganador = jugador1;
                    break;
                }
                if (tablero.hayEmpate())
                {
                    empate = true;
                    break;
                }
                Console.Clear();

                //Turno jugador 2
                do
                {
                    tablero.imprimirTablero();
                    Console.Write("{0} ingresa una posición: ", jugador2.Nombre);
                    if (!tablero.jugar(jugador2.Ficha, Console.ReadLine()))
                    {
                        Console.Clear();
                        Console.WriteLine("La posicion esta ocupada");
                        Console.WriteLine();
                        Console.WriteLine();
                        validar = false;
                    }
                } while (!validar);

                if (tablero.hayGanador())
                {
                    ganador = true;
                    jugador_ganador = jugador2;
                    break;
                }
                if (tablero.hayEmpate())
                {
                    empate = true;
                    break;
                }
                Console.Clear();
            }


            if (ganador)
            {
                Console.Clear();
                tablero.imprimirTablero();
                Console.WriteLine("Felicidades {0}, ganaste", jugador_ganador.Nombre);
            }
            else
            {
                Console.Clear();
                tablero.imprimirTablero();
                Console.WriteLine("Empate, unos mancos");
            }

               
        }
    }

    class Tablero
    {
        private string[,] tablero;

        public Tablero()
        {
            tablero = new string[3, 3];
            tablero[0, 0] = "1";
            tablero[0, 1] = "2";
            tablero[0, 2] = "3";
            tablero[1, 0] = "4";
            tablero[1, 1] = "5";
            tablero[1, 2] = "6";
            tablero[2, 0] = "7";
            tablero[2, 1] = "8";
            tablero[2, 2] = "9";
        }

        public void imprimirTablero()
        {
            for (int f = 0; f < 3; f++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(tablero[f, c] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("---------");
            }
        }

        public void setPosicion(string posicion, Ficha ficha)
        {
            switch (posicion)
            {
                case "1":
                    tablero[0, 0] = ficha.ToString();
                    break;
                case "2":
                    tablero[0, 1] = ficha.ToString();
                    break;
                case "3":
                    tablero[0, 2] = ficha.ToString();
                    break;
                case "4":
                    tablero[1, 0] = ficha.ToString();
                    break;
                case "5":
                    tablero[1, 1] = ficha.ToString();
                    break;
                case "6":
                    tablero[1, 2] = ficha.ToString();
                    break;
                case "7":
                    tablero[2, 0] = ficha.ToString();
                    break;
                case "8":
                    tablero[2, 1] = ficha.ToString();
                    break;
                case "9":
                    tablero[2, 2] = ficha.ToString();
                    break;
            }
        }

        public string getPosicion(string posicion)
        {
            switch (posicion)
            {
                case "1":
                    return tablero[0, 0];
                case "2":
                    return tablero[0, 1];
                case "3":
                    return tablero[0, 2];
                case "4":
                    return tablero[1, 0];
                case "5":
                    return tablero[1, 1];
                case "6":
                    return tablero[1, 2];
                case "7":
                    return tablero[2, 0];
                case "8":
                    return tablero[2, 1];
                case "9":
                    return tablero[2, 2];
            }

            throw new ArgumentOutOfRangeException();

        }

        public bool hayGanador()
        {
            // Verificiar filas
            for (int f = 0; f < 3; f++)
            {
                if (tablero[f, 0].Equals(tablero[f, 1]) && tablero[f, 1].Equals(tablero[f, 2]))
                {
                    return true;
                }
            }
            // Verificar columnas
            for (int c = 0; c < 3; c++)
            {
                if (tablero[0, c].Equals(tablero[1, c]) && tablero[1, c].Equals(tablero[2, c]))
                {
                    return true;
                }
            }
            //Verificar diagonal principal
            if (tablero[0, 0].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 2]))
            {
                return true;
            }
            //Verificar diagonal opuesta
            if (tablero[0, 2].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 0]))
            {
                return true;
            }

            return false;
        }

        public bool hayEmpate()
        {
            for (int p = 1; p <= 9; p++)
            {
                if (!PosicionOcupada(p.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool PosicionOcupada(string posicion)
        {
            return (getPosicion(posicion).Equals("O") || getPosicion(posicion).Equals("X"));
        }

        public bool jugar(Ficha ficha, string posición)
        {
            if (!PosicionOcupada(posición))
            {
                setPosicion(posición, ficha);
                return true;
            }
            return false;
        }

    }

    class Jugador
    {
        private string nombre;
        private Ficha ficha;

        public Jugador(string nombre, Ficha ficha)
        {
            this.nombre = nombre;
            this.ficha = ficha;
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
        }
        public Ficha Ficha
        {
            get
            {
                return ficha;
            }
            set
            {
                ficha = value;
            }
        }
    }
    public enum Ficha
    {
        O = 1, X = 2
    }
}