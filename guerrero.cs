using System;

namespace Guimil_Lucas
{
    class Guerrero : Personaje
    {
        private int fuerza;
        private double resistencia;

// Constructor que recibe nombre, nivel, fuerza y resistencia
        // y lanza una excepción si la fuerza o resistencia son negativas
        public Guerrero(string nombre, int nivel, int fuerza, double resistencia) : base(nombre, nivel)
        {
            if (fuerza < 0) throw new ArgumentException("Fuerza no puede ser negativa.");
            if (resistencia < 0) throw new ArgumentException("Resistencia no puede ser negativa.");
            this.fuerza = fuerza;
            this.resistencia = resistencia;
        }

// GETTER Y SETTER PARA MODIFICAR LA FUERZA Y RESISTENCIA
        // Fuerza no puede ser negativa, resistencia no puede ser negativa
        public int Fuerza
        {
            get => fuerza;
            set
            {
                if (value < 0) throw new ArgumentException("Fuerza no puede ser negativa.");
                fuerza = value;
            }
        }

        public double Resistencia
        {
            get => resistencia;
            set
            {
                if (value < 0) throw new ArgumentException("Resistencia no puede ser negativa.");
                resistencia = value;
            }
        }
// Metodo para mostrar información del guerrero
        // Muestra el nombre, nivel, fuerza y resistencia del guerrero
        public override void Mostrar()
        {
            Console.WriteLine($"Guerrero: {nombre}, Nivel: {nivel}, Fuerza: {fuerza}, Resistencia: {resistencia}");
        }
// Metodo para calcular el daño físico basado en la fuerza y el nivel
        public double CalcularDefensa()
        {
            return resistencia * fuerza / nivel;
        }
    }
}
    