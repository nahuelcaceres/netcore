
using System;
using InterfacesLogger.Interfaces;

namespace InterfacesLogger.Implementaciones
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string value)
        {
            Console.WriteLine($"Logueando Error: '{value}'. Salida: Consola.");
        }

        public void Informacion(string value)
        {
            Console.WriteLine($"Logueando Informacion: '{value}'. Salida: Consola.");            
        }
    }
}