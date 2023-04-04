using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioPOO12022_Quinela
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            DateTime fechaActual = DateTime.Now;
            int diasDelMes = DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month);
            int[,] quinela = new int[diasDelMes + 1, 20];
            int[,] listaQuinela = new int[4, 5];
            int diaSorteo, diaMostrar, opcion;
            bool dale = true;

            while (dale)
            {
                try
                {
                    opcion = PedirOpcion();

                    switch (opcion)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("**** AGREGAR SORTEO ****");
                                Console.WriteLine("\nUsted puede ingresar 20 numeros del 1 al 999.");
                                AgregarSorteo(quinela, diaSorteo = VerificarDia());
                                break;
                            }

                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("**** MODIFICAR UN SORTEO ****");
                                ModificarSorteo(quinela, listaQuinela, diaSorteo = VerificarDia());
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("**** MOSTRAR UN SORTEO ****");
                                Console.WriteLine("\nIngrese el dia de sorteo que quiere ver.");
                                MostrarUnSorteo(quinela, listaQuinela, diaMostrar = VerificarDia());
                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine("**** MOSTRAR SORTEOS ****\n");
                                MostrarSorteos(quinela, fechaActual);
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                Console.WriteLine("Ha optado por salir.");
                                Console.ReadLine();
                                dale = false;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\nIngreso una opcion no estipulada.");
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("Intente nuevamente por favor.");
                    Console.ReadLine();
                }
            }
        }

        static int PidoEntero(string mensaje)
        {
            int numero;

            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < 1 || numero > 999)
                        Console.WriteLine("\nPor favor ingrese un numero entre 1 y 999.");
                    else
                        break;
                }
                catch
                {
                    Console.WriteLine("\nPor favor ingrese un numero entero.");
                    Console.WriteLine();
                }
            }
            return numero;
        }

        static int PidoPosicion(string mensaje)
        {
            int numero;

            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < 1 || numero > 20)
                    {
                        Console.WriteLine("\nPor favor ingrese una posicion entre 1 y 20.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nPor favor ingrese un numero entero entre 1 y 20.");
                    Console.WriteLine();
                }
            }
            return numero;
        }

        static int PedirOpcion()
        {
            int opcion;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" **** QUINELA **** ");
                Console.WriteLine();
                Console.WriteLine("1. Agregar Sorteo");
                Console.WriteLine("2. Modificar un numero de un Sorteo");
                Console.WriteLine("3. Mostrar un Sorteo");
                Console.WriteLine("4. Mostrar todos los Sorteos");
                Console.WriteLine("5. Salir");
                Console.WriteLine();

                try
                {
                    Console.Write("Elija una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion < 1 || opcion > 5)
                    {
                        Console.WriteLine("\nDebe ingresar una opción entre 1 y 5");
                        Console.ReadLine();
                    }
                    else
                        return opcion;
                }
                catch
                {
                    Console.WriteLine("\nPor favor ingrese una opcion entre 1 y 5.");
                    Console.ReadLine();
                }
            }
        }

        static int VerificarDia() // Cree esta funcion ya que se debe verificar el dia constantemente, devuelve mensajes amigables al usuario ubicandolo en el mes en el que esta y cuantos dias tiene en caso de ingresar un dia incorrecto.
        {
            // Estas variables se podian pasar como parametros por que ya existen en main, pero me parecia mas prolijo a la vista que esten dentro de la funcion.
            DateTime fechaActual = DateTime.Now;
            int diasDelMes = DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month);
            int diaSorteo;

            while (true)
            {
                try
                {
                    Console.Write("\nEstas en el mes de " + fechaActual.ToString("MMMM") + ", ingrese un dia: ");
                    diaSorteo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (diaSorteo > diasDelMes)
                    {
                        Console.Write("\nEl mes de " + fechaActual.ToString("MMMM") + " tiene " + diasDelMes + " dias, por favor ingrese un dia adecuado.");
                        Console.ReadLine();
                    }
                    else if (diaSorteo < 0)
                    {
                        Console.Write("\nNo existe dias negativos, porfavor ingrese nuevamente.");
                        Console.ReadLine();
                    }
                    else if (diaSorteo == 0)
                    {
                        Console.Write("\nNo existe el dia 0, porfavor ingrese nuevamente.");
                        Console.ReadLine();
                    }
                    else
                        break;
                }
                catch
                {
                    Console.WriteLine("\nPor favor ingrese un dia del mes correspondiente.");
                    Console.ReadLine();
                }
            }
            return diaSorteo;
        }

        static void AgregarSorteo(int[,] quinela, int diaSorteo)
        {
            int num;
            bool repetido = false;

            if (quinela[diaSorteo, 1] == 0)
            {
                for (int col = 0; col < quinela.GetLength(1); col++)
                {
                    num = PidoEntero("\nPor favor ingrese el numero " + (col + 1) + " para el dia " + diaSorteo + ": ");
                    repetido = false;

                    for (int i = 0; i < quinela.GetLength(1) && !repetido; i++)
                    {
                        if (quinela[diaSorteo, i] == num)
                            repetido = true;
                    }
                    if (repetido)
                    {
                        Console.WriteLine("\nEl numero que usted ingreso esta repetido, intente de nuevo.");
                        col--;
                        Console.ReadLine();
                    }
                    else
                        quinela[diaSorteo, col] = num;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nYa hay numeros asignados para el sorteo de este dia, eliga uno distinto.");
                Console.ReadLine();
            }
        }

        static void ModificarSorteo(int[,] quinela, int[,] listaQuinela, int diaSorteo)
        {
            int posModificar;
            int num;
            bool repetido = false;

            if (quinela[diaSorteo, 1] != 0)
            {
                // Se muestran los numeros para que el usuario pueda tener claro en que posicion esta el numero que quiere cambiar
                MostrarUnSorteo(quinela, listaQuinela, diaSorteo);

                posModificar = PidoPosicion("\nPor favor ingrese la posicion de numero que desea modificar del 1 al 20: ");
                num = PidoEntero("\nIngrese el nuevo numero para la posicion " + posModificar + ": ");
                posModificar = posModificar - 1;

                for (int i = 0; i < quinela.GetLength(1) && !repetido; i++)
                {
                    if (quinela[diaSorteo, i] == num)
                        repetido = true;
                }
                if (repetido)
                {
                    // No se vuelve a pedir el numero luego de este if, ya que eso obligaria al usuario tener que modificar un numero despues de ver que esta repetido.
                    Console.WriteLine("\nEl numero que usted ingreso esta repetido, intente nuevamente.");
                    Console.ReadLine();
                }
                else if (repetido == false)
                {
                    quinela[diaSorteo, posModificar] = num;

                    Console.Clear();
                    Console.WriteLine("**** MODIFICAR UN SORTEO ****");
                    Console.WriteLine();

                    // Se muestran nuevamente los numeros
                    MostrarUnSorteo(quinela, listaQuinela, diaSorteo);

                    Console.WriteLine("\nModificado exitosamente.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nEl dia que eligio no tiene numeros asignados para modificar.");
                Console.ReadLine();
            }
        }

        static void MostrarUnSorteo(int[,] quinela, int[,] listaQuinela, int diaSorteo)
        {
            if (quinela[diaSorteo, 1] != 0)
            {
                // Nueva matriz listaQuinela con dimensiones diferentes para poder mostrar al usuario los numeros de ese dia.
                int col2 = 0;

                for (int col = 0; col < listaQuinela.GetLength(0); col++)
                {
                    for (int fila = 0; fila < listaQuinela.GetLength(1); fila++)
                    {
                        listaQuinela[col, fila] = quinela[diaSorteo, col2];
                        col2++;
                    }
                }
                // Recorro la matriz nueva para poder mostrar al usuario los numeros del dia elegido (estoy seguro de que debe haber formas mejores de hacer esto y la verdad no se me ocurrio, pero al menos funciona bien.)
                int pos = 1;

                for (int col = 0; col < listaQuinela.GetLength(1); col++)
                {
                    if (pos == 16)
                        pos = 2;
                    else if (pos == 17)
                        pos = 3;
                    else if (pos == 18)
                        pos = 4;
                    else if (pos == 19)
                        pos = 5;

                    for (int fila = 0; fila < listaQuinela.GetLength(0); fila++)
                    {
                        Console.Write(" Posicion " + pos + ": " + listaQuinela[fila, col]);

                        if (fila != 3)
                            pos += 5;
                    }
                    Console.WriteLine();
                }
            }
            else if (quinela[diaSorteo, 1] == 0)
            {
                Console.WriteLine("\nNo hay numeros que mostrar para el dia elegido.");
            }
        }

        static void MostrarSorteos(int[,] quinela, DateTime fechaActual)
        {
            int col1 = 1;

            for (int fila = 1; fila < quinela.GetLength(0); fila++)
            {
                if (quinela[fila, col1] != 0)
                {
                    Console.Write("Dia " + fila + " de " + fechaActual.ToString("MMMM") + " ==>\t");
                }
                for (int col = 0; col < quinela.GetLength(1); col++)
                {
                    if (quinela[fila, col] != 0)
                    {
                        Console.Write(quinela[fila, col] + "\t");

                        if (col == 19)
                            Console.WriteLine("\n");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}

