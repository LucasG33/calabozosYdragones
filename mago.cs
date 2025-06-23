using System;

namespace Guimil_Lucas
{
    class Mago : Personaje
    {
        private int poderMagico;


//       // Constructor que recibe nombre, nivel y poder magico        // y lanza una excepción si el poder magico es negativo
        public Mago(string nombre, int nivel, int poderMagico) : base(nombre, nivel)
        {
            if (poderMagico < 0) throw new ArgumentException("Poder magico no puede ser negativo.");
            this.poderMagico = poderMagico;
        }

//GETTER Y SETTER PARA MODIFICAR EL PODER MAGICO
        public int PoderMagico
        {
            get => poderMagico;
            set
            {
                if (value < 0) throw new ArgumentException("Poder magico no puede ser negativo.");
                poderMagico = value;
            }
        }

// Metodo para mostrar información del mago
        public override void Mostrar()
        {
            Console.WriteLine($"Mago: {nombre}, Nivel: {nivel}, Poder Mágico: {poderMagico}");
        }

// Metodo para calcular el daño magico basado en el poder mágico y el nivel
        public float CalcularDanioMagico()
        {
            return poderMagico * nivel * 0.8f;
        }
    }
}