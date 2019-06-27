
using System;
using InterfacesLogger.Interfaces;

namespace InterfacesLogger.Implementaciones
{
    public class WindowLogger : ILogger
    {
        public void Error(string value)
        {
            Console.WriteLine($"Logueando Error: '{value}'. Salida: Window.");
        }

        public void Informacion(string value)
        {
            Console.WriteLine($"Logueando Informacion: '{value}'. Salida: Window.");            
        }
    }
}