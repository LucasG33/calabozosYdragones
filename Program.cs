using System;
using System.Collections.Generic;

namespace Guimil_Lucas
{
    class Program
    {
        static List<Personaje> personajes = new List<Personaje>();

        static void Main(string[] args)
        {
        // SE AÑADEN PERSONAJES AL COMPILAR
            personajes.Add(new Mago("mago1", 10, 50));
            personajes.Add(new Mago("mago2", 7, 40));
            personajes.Add(new Guerrero("guerrero1", 12, 30, 25.5));
            personajes.Add(new Guerrero("guerrero2", 9, 20, 30.0));


            bool salir = false;
            //ACA USAMOS UN BUCLE PARA QUE EL PROGRAMA NO SE CIERRE AL TERMINAR LA ACCION ANTERIOR, Y LUEGO MANEJAMOS EL MENU CON UN SWITCH-CASE
            while (!salir)
            {
                MostrarMenu();
                Console.Write("Ingrese una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarPersonaje();
                        break;
                    case "2":
                        ModificarPersonaje();
                        break;
                    case "3":
                        EliminarPersonaje();
                        break;
                    case "4":
                        ListarPersonajes();
                        break;
                    case "5":
                        CalcularDanioMagico();
                        break;
                    case "6":
                        CalcularDefensa();
                        break;
                    case "7":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción invalida. Intente nuevamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

          //METODO QUE MUESTRA EL MENU
        static void MostrarMenu()
        {
            Console.WriteLine("----- Menú -----");
            Console.WriteLine("1 - Agregar personaje");
            Console.WriteLine("2 - Modificar personaje");
            Console.WriteLine("3 - Eliminar personaje");
            Console.WriteLine("4 - Listar personajes");
            Console.WriteLine("5 - Calcular daño magico (solo magos)");
            Console.WriteLine("6 - Calcular defensa (solo guerreros)");
            Console.WriteLine("7 - Salir");
        }

        //METODO QUE AGREGA PERSONAJEES
        static void AgregarPersonaje()
        {
            Console.Write("Ingrese tipo de personaje (mago/guerrero): ");
            string tipo = Console.ReadLine().ToLower();
//USAMOS UN BLOQUE TRY-CATCH PARA MANEJAR ERRORES DE ENTRADA, Y CADA PERSONAJE TIENE SU VALIDACION 
            try
            {
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Nivel (entero no negativo): ");
                int nivel = int.Parse(Console.ReadLine());
                if (nivel < 0) throw new ArgumentException("Nivel no puede ser negativo.");

                if (tipo == "mago")
                {
                    Console.Write("Poder magico (entero no negativo): ");
                    int poder = int.Parse(Console.ReadLine());
                    if (poder < 0) throw new ArgumentException("Poder mágico no puede ser negativo.");

                    personajes.Add(new Mago(nombre, nivel, poder));
                    Console.WriteLine("Mago agregado correctamente.");
                }
                else if (tipo == "guerrero")
                {
                    Console.Write("Fuerza (entero no negativo): ");
                    int fuerza = int.Parse(Console.ReadLine());
                    if (fuerza < 0) throw new ArgumentException("Fuerza no puede ser negativa.");

                    Console.Write("Resistencia (número no negativo): ");
                    double resistencia = double.Parse(Console.ReadLine());
                    if (resistencia < 0) throw new ArgumentException("Resistencia no puede ser negativa.");

                    personajes.Add(new Guerrero(nombre, nivel, fuerza, resistencia));
                    Console.WriteLine("Guerrero agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("Tipo de personaje inválido.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Entrada inválida. Debe ingresar números válidos.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    

     //FUNCION QUE MANEJA LA MODIFICACION DE PERSONAJES
        static void ModificarPersonaje()
        {
            //LE PEDIMOS QUE VALIDE LA CANTIDAD DE PERSONAJES
            //SI NO HAY PERSONAJES, SE MUESTRA UN MENSAJE
            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes para modificar.");
                return;
            }

//LUEGO RECORREMOS LA LISTA DE PERSONAJES PARA QUE EL USUARIO PUEDA ELEGIR CUAL MODIFICAR
            ListarPersonajes();

            Console.Write("Ingrese el indice del personaje a modificar: ");
            // ACA VALIDAMOS QUE EL INPUT SEA LO ESPERADO 
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                //VALIDAMOS QUE EL INDICE SEA VALIDO
                //SI EL INDICE ES VALIDO, SE MUESTRA EL PERSONAJE 
                if (index >= 0 && index < personajes.Count)
                {
                    Personaje p = personajes[index];

                    Console.WriteLine($"Modificando personaje: {p.Nombre}");

                    Console.Write("Nuevo nombre (enter para mantener actual): ");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre))
                        p.Nombre = nuevoNombre;

                    try
                    {
                        Console.Write("Nuevo nivel (enter para mantener actual): ");
                        string nivelStr = Console.ReadLine();
                        // VALIDACION PARA INPUT
                        if (!string.IsNullOrEmpty(nivelStr))
                        {
                            int nuevoNivel = int.Parse(nivelStr);
                            if (nuevoNivel < 0) throw new ArgumentException("Nivel no puede ser negativo.");
                            p.Nivel = nuevoNivel;
                        }

                        // VALIDACION PARA MAGOS Y GUERREROS
                        // SI EL PERSONAJE ES UN MAGO, SE PIDE EL NUEVO POD
                        // SI EL PERSONAJE ES UN GUERRERO, SE PIDE LA NUEVA FUERZA Y RESISTENCIA
                        // USAMOS EL OPERADOR IS PARA VERIFICAR EL TIPO DE PERSONAJE
                        // SI EL TIPO DE PERSONAJE NO ES VALIDO, SE MUESTRRA UN MENSAJE DE ERROR
                        if (p is Mago mago)
                        {
                            Console.Write("Nuevo poder magico (enter para mantener actual): ");
                            string poderStr = Console.ReadLine();
                            if (!string.IsNullOrEmpty(poderStr))
                            {
                                int nuevoPoder = int.Parse(poderStr);
                                if (nuevoPoder < 0) throw new ArgumentException("Poder magico no puede ser negativo.");
                                mago.PoderMagico = nuevoPoder;
                            }
                        }
                        else if (p is Guerrero guerrero)
                        {
                            Console.Write("Nueva fuerza (enter para mantener actual): ");
                            string fuerzaStr = Console.ReadLine();
                            if (!string.IsNullOrEmpty(fuerzaStr))
                            {
                                int nuevaFuerza = int.Parse(fuerzaStr);
                                if (nuevaFuerza < 0) throw new ArgumentException("Fuerza no puede ser negativa.");
                                guerrero.Fuerza = nuevaFuerza;
                            }

                            Console.Write("Nueva resistencia (enter para mantener actual): ");
                            string resistenciaStr = Console.ReadLine();
                            if (!string.IsNullOrEmpty(resistenciaStr))
                            {
                                double nuevaResistencia = double.Parse(resistenciaStr);
                                if (nuevaResistencia < 0) throw new ArgumentException("Resistencia no puede ser negativa.");
                                guerrero.Resistencia = nuevaResistencia;
                            }
                        }

                        Console.WriteLine("Personaje modificado correctamente.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Entrada inválida. Debe ingresar números válidos.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Indice fuera de rango.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

  //FUNCION QUE MANEJA LA ELIMINACION DE PERSONAJES
        //SE USA UN BUCLE PARA RECORRER LA LISTA DE PERSONAJ
        static void EliminarPersonaje()
        {
            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes para eliminar.");
                return;
            }

            ListarPersonajes();

            Console.Write("Ingrese el indice del personaje a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 0 && index < personajes.Count)
                {
                    personajes.RemoveAt(index);
                    Console.WriteLine("Personaje eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Indice fuera de rango.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

//FUNCION PARA VER LA LISTA DE TODOS LOS PERSONAJES EXISTENTES
        //SE USA UN BUCLE PARA RECORRER LA LISTA DE PERSONAJES
        static void ListarPersonajes()
        {
            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes cargados.");
                return;
            }

            Console.WriteLine("Lista de personajes:");
            for (int i = 0; i < personajes.Count; i++)
            {
                Console.Write($"[{i}] ");
                personajes[i].Mostrar();
            }
        }

 //FUNCION QUE CALCULA EL DAÑO MAGICO DE LOS MAGOS
        //SE USA UN BUCLE PARA RECORRER LA LISTA DE MAGOS
        static void CalcularDanioMagico()
        {
            bool hayMagos = false;
            for (int i = 0; i < personajes.Count; i++)
            {
                if (personajes[i] is Mago mago)
                {
                    hayMagos = true;
                    Console.Write($"[{i}] ");
                    mago.Mostrar();
                    Console.WriteLine($"Daño magico estimado: {mago.CalcularDanioMagico()}");
                }
            }
            if (!hayMagos)
            {
                Console.WriteLine("No hay magos en la lista.");
            }
        }

  //FUNCION QUE CALCULA LA DEFENSA DE LOS GUERREROS
        //SE USA UN BUCLE PARA RECORRER LA LISTA DE GUERREROS
        static void CalcularDefensa()
        {
            bool hayGuerreros = false;
            for (int i = 0; i < personajes.Count; i++)
            {
                if (personajes[i] is Guerrero guerrero)
                {
                    hayGuerreros = true;
                    Console.Write($"[{i}] ");
                    guerrero.Mostrar();
                    Console.WriteLine($"Defensa estimada: {guerrero.CalcularDefensa()}");
                }
            }
            if (!hayGuerreros)
            {
                Console.WriteLine("No hay guerreros en la lista.");
            }
        }
    }
}
