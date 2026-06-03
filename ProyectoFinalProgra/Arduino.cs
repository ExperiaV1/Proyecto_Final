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
            puerto = new SerialPort(nombrePuerto, 9600);
            puerto.NewLine = "\n";
        }
        public void Enviar(string Mensaje)
        {
            try
            {
                if (!puerto.IsOpen)
                {
                    puerto.Open();
                    Thread.Sleep(2000);
                }
                puerto.WriteLine(Mensaje);
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al Enviar datos al arduino " + ex.Message);
            }  
        }

        public void Cerrar()
        {
            if(puerto.IsOpen)
            {
                puerto.Close();
            }
        }
    }
}