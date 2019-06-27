
using System;
using InterfacesLogger.Interfaces;

namespace InterfacesLogger.Implementaciones
{
    public class DatabaseLogger : ILogger
    {
        public void Error(string value)
        {
            Console.WriteLine($"Logueando Error: '{value}'. Salida: Database.");
        }

        public void Informacion(string value)
        {
            Console.WriteLine($"Logueando Informacion: '{value}'. Salida: Database.");            
        }
    }
}