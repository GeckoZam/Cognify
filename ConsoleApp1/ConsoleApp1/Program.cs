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
        public interface ICrimen
        {
            void Crimen();
        }

        // Clases de instrumentos específicas que implementan la interfaz IInstrument
        public class Robo : ICrimen
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Robo.");
            }
        }

        public class Homocidio : ICrimen
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Homicidio.");
            }
        }

        public class Asalto : ICrimen
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de Asalto.");
            }
        }

        public class Guerra : ICrimen
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de guerra.");
            }
        }

        public class Guerra : ICrimen
        {
            public void Crimen()
            {
                Console.WriteLine("Cometío crimen de guerra.");
            }
        }

        // Clase Factory que devuelve instancias de IInstrument según el tipo
        public class InstrumentFactory
        {
            public IInstrument CreateInstrument(string instrumentType)
            {
                if (instrumentType == "Guitar")
                {
                    return new Guitar();
                }
                else if (instrumentType == "Piano")
                {
                    return new Piano();
                }
                else
                {
                    throw new ArgumentException("Instrument not available.");
                }
            }
        }
        // Clase MusicStore que usa InstrumentFactory y aplica Inversión de Dependencias
        public class MusicStore
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
