namespace Esferas.Entidades
{
    using System;

    public enum ColorEsfera
    {
        Rojo,
        Verde,
        Azul
    }

    public enum TipoTrazo
    {
        Continuo,
        Rayas,
        Puntos
    }

    public class Esfera
    {
        public double Radio { get; set; }
        public ColorEsfera ColorRelleno { get; set; }
        public TipoTrazo TipoDeTrazo { get; set; }

        public Esfera(double radio, ColorEsfera color, TipoTrazo trazo)
        {
            Radio = radio;
            ColorRelleno = color;
            TipoDeTrazo = trazo;
        }

        public double CalcularVolumen()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radio, 3);
        }

        public double CalcularArea()
        {
            return 4 * Math.PI * Math.Pow(Radio, 2);
        }
    }
}
