using System;
using System.IO.Ports;
using System.Threading;

namespace ProyectoFinalProgra.Clases
{
    internal class DespachoResultado
    {
        public int BombaId { get; set; }
        public int SegundosDespachados { get; set; }
        public string MotivoParo { get; set; }
        public string LineaOriginal { get; set; }

        public bool ParoPorSensor
        {
            get { return string.Equals(MotivoParo, "SENSOR", StringComparison.OrdinalIgnoreCase); }
        }
    }

    internal class Arduino
    {
        private readonly SerialPort puerto;
        private bool yaEsperoReinicio;
        private readonly object bloqueo = new object();

        public Arduino(string nombrePuerto)
        {
            puerto = new SerialPort(nombrePuerto, 9600);
            puerto.NewLine = "\n";
            puerto.ReadTimeout = 1000;
            puerto.WriteTimeout = 1000;
            yaEsperoReinicio = false;
        }

        public void Conectar()
        {
            lock (bloqueo)
            {
                try
                {
                    if (!puerto.IsOpen)
                    {
                        puerto.Open();

                        // El Arduino Mega normalmente se reinicia al abrir el puerto serial.
                        // Solo esperamos una vez, no en cada despacho.
                        if (!yaEsperoReinicio)
                        {
                            Thread.Sleep(2000);
                            yaEsperoReinicio = true;
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    throw new Exception("El puerto " + puerto.PortName + " esta ocupado. Cierra Arduino IDE, Monitor Serial u otra ventana del programa.");
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo abrir el puerto " + puerto.PortName + ": " + ex.Message);
                }
            }
        }

        public void Enviar(string mensaje)
        {
            lock (bloqueo)
            {
                try
                {
                    Conectar();
                    puerto.DiscardInBuffer();
                    puerto.DiscardOutBuffer();
                    puerto.WriteLine(mensaje);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new Exception("El puerto " + puerto.PortName + " esta ocupado. Cierra Arduino IDE, Monitor Serial u otra ventana del programa.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al enviar datos al Arduino: " + ex.Message);
                }
            }
        }

        public DespachoResultado EnviarYEsperarFin(string mensaje, int timeoutMs)
        {
            lock (bloqueo)
            {
                try
                {
                    Conectar();
                    puerto.DiscardInBuffer();
                    puerto.DiscardOutBuffer();
                    puerto.WriteLine(mensaje);

                    DateTime limite = DateTime.Now.AddMilliseconds(timeoutMs);

                    while (DateTime.Now < limite)
                    {
                        try
                        {
                            string linea = puerto.ReadLine();
                            if (linea == null) continue;

                            linea = linea.Trim();
                            if (linea.Length == 0) continue;

                            if (linea.Equals("BUSY", StringComparison.OrdinalIgnoreCase))
                                throw new Exception("Arduino indica BUSY: la bomba o el sistema estan ocupados.");

                            if (linea.StartsWith("ERROR", StringComparison.OrdinalIgnoreCase))
                                throw new Exception("Arduino respondio: " + linea);

                            if (linea.StartsWith("OK:FIN:B", StringComparison.OrdinalIgnoreCase))
                                return ParsearResultado(linea);
                        }
                        catch (TimeoutException)
                        {
                            // Seguimos esperando hasta llegar al timeout general.
                        }
                    }

                    throw new Exception("Tiempo de espera agotado. No se recibio OK:FIN desde Arduino.");
                }
                catch (UnauthorizedAccessException)
                {
                    throw new Exception("El puerto " + puerto.PortName + " esta ocupado. Cierra Arduino IDE, Monitor Serial u otra ventana del programa.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en comunicacion con Arduino: " + ex.Message);
                }
            }
        }

        private DespachoResultado ParsearResultado(string linea)
        {
            // Formato esperado:
            // OK:FIN:B1:DESP=4:PARO=SENSOR
            DespachoResultado resultado = new DespachoResultado();
            resultado.LineaOriginal = linea;
            resultado.MotivoParo = "DESCONOCIDO";
            resultado.SegundosDespachados = 0;

            string[] partes = linea.Split(':');

            foreach (string parte in partes)
            {
                if (parte.StartsWith("B", StringComparison.OrdinalIgnoreCase) && parte.Length > 1)
                {
                    int bomba;
                    if (int.TryParse(parte.Substring(1), out bomba))
                        resultado.BombaId = bomba;
                }
                else if (parte.StartsWith("DESP=", StringComparison.OrdinalIgnoreCase))
                {
                    int segundos;
                    if (int.TryParse(parte.Substring(5), out segundos))
                        resultado.SegundosDespachados = segundos;
                }
                else if (parte.StartsWith("PARO=", StringComparison.OrdinalIgnoreCase))
                {
                    resultado.MotivoParo = parte.Substring(5);
                }
            }

            return resultado;
        }

        public string Leer()
        {
            lock (bloqueo)
            {
                try
                {
                    Conectar();
                    return puerto.ReadLine();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public void Cerrar()
        {
            lock (bloqueo)
            {
                try
                {
                    if (puerto != null && puerto.IsOpen)
                    {
                        puerto.Close();
                    }
                }
                catch
                {
                    // Evita errores al cerrar la aplicacion.
                }
            }
        }
    }
}
