using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Ejemplo de uso
    public class Program
    {
        // Interfaz común para todos los Crimenes
        public interface ICrimenType
        {
            void Crimen();
        }

        // Clases de instrumentos específicas que implementan la interfaz IInstrument
        public class Robo : ICrimenType
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Robo.");
            }
        }

        public class Homocidio : ICrimenType
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Homicidio.");
            }
        }

        public class Asalto : ICrimenType
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Asalto.");
            }
        }

        public class Guerra : ICrimenType
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de guerra.");
            }
        }

        public class Fraude : ICrimenType
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío el crimen de fraude.");
            }
        }

        // Clase Factory que devuelve instancias de IInstrument según el tipo
        public class MemoryFactory
        {
            public ICrimenType CreateSimulation(string crimeType)
            {
                if (crimeType == "Robo")
                {
                    return new Robo();
                }
                else if (crimeType == "Homicidio")
                {
                    return new Homicidio();
                }
                else if (crimeType == "Homicidio")
                {
                    return new Homicidio();
                }
                else if (crimeType == "Asalto")
                {
                    return new Asalto();
                }
                else if (crimeType == "Guerra")
                {
                    return new Guerra();
                }                
                else if (crimeType == "Fraude")
                {
                    return new Fraude();
                }
                else
                {
                    throw new ArgumentException("Persona libre de crimenes.");
                }
            }
        }
        // Clase MusicStore que usa InstrumentFactory y aplica Inversión de Dependencias
        public class Simulation
        {
            private readonly MemoryFactory _memoryFactory;

            // Constructor que recibe la fábrica como dependencia
            public Criminal(MemoryFactory memoryFactory)
            {
                _memoryFactory = memoryFactory;
            }

            public void Sentencia(string crimenType)
            {
                try
                {
                    var criminal = _memoryFactory.CreateSimulation(memoryType);
                    criminal.Crimen();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void Main(string[] args)
        {
            var factory = new MemoryFactory();
            var simulacion = new Simulacion(factory);

            simulacion.PlayInstrument("Guerra");  // Output: Playing a guitar.
            simulacion.PlayInstrument("Asalto");   // Output: Playing a piano.
            simulacion.PlayInstrument("Homicidio");   // Output: Instrument not available.
        }
    }
}
