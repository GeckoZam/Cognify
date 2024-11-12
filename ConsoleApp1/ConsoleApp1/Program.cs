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
            private readonly InstrumentFactory _instrumentFactory;

            // Constructor que recibe la fábrica como dependencia
            public MusicStore(InstrumentFactory instrumentFactory)
            {
                _instrumentFactory = instrumentFactory;
            }

            public void PlayInstrument(string instrumentType)
            {
                try
                {
                    var instrument = _instrumentFactory.CreateInstrument(instrumentType);
                    instrument.Play();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void Main(string[] args)
        {
            var factory = new InstrumentFactory();
            var store = new MusicStore(factory);

            store.PlayInstrument("Guitar");  // Output: Playing a guitar.
            store.PlayInstrument("Piano");   // Output: Playing a piano.
            store.PlayInstrument("Drums");   // Output: Instrument not available.
        }
    }
}
