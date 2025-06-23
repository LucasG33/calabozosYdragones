using System;

namespace Guimil_Lucas
{
    abstract class Personaje
    {
        protected string nombre;
        protected int nivel;
// Constructor que recibe nombre y nivel
        // y lanza una excepción si el nivel es negativo
        public Personaje(string nombre, int nivel)
        {
            if (nivel < 0) throw new ArgumentException("Nivel no puede ser negativo.");
            this.nombre = nombre;
            this.nivel = nivel;
        }
// GETTER Y SETTER PARA MODIFICAR EL NOMBRE Y NIVEL
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int Nivel
        {
            get => nivel;
            set
            {
                if (value < 0) throw new ArgumentException("Nivel no puede ser negativo.");
                nivel = value;
            }
        }
// Metodo abstracto para mostrar información del personaje
        // Cada clase derivada debe implementar este método
        public abstract void Mostrar();
    }
}
