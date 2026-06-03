using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;


namespace ProyectoFinalProgra
{
    internal class Arduino
    {
        private SerialPort puerto;
        public Arduino(string nombrePuerto)
        {
            puerto = new SerialPort(nombrePuerto, 9500);
        }
        public void Enviar(string Mensaje)
        {
            if (!puerto.IsOpen)
            {
                puerto.Open();
                Thread.Sleep(2000);
            }
            puerto.WriteLine(Mensaje);
            puerto.Close();
        }
    }
}