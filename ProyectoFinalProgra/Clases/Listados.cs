using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ProyectoFinalProgra.Clases
{
    public static class Listados
    {
        // FUNCION PARA GUARDAR LOS DATOS DEL CLIENTE EN UN TXT
        public static void GuardarClientes_EnTxt(string rutaClientes, BindingList<Clientes> listaClientes)
        {
            using (StreamWriter writer = new StreamWriter(rutaClientes, false))
            {
                foreach (Clientes cliente in listaClientes)
                {
                    writer.WriteLine(cliente.Nombre + "|" + cliente.NIT);
                }
            }
        }

        // FUNCION PARA CARGAR LOS DATOS DEL CLIENTE CADA VEZ QUE SE INICIE EL PROGRAMA
        public static int CargarClientes_DesdeTxt(string rutaClientes, BindingList<Clientes> listaClientes, int contadorClientes)
        {
            if (!File.Exists(rutaClientes))
            {
                return contadorClientes;
            }

            string[] lineas = File.ReadAllLines(rutaClientes);

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split('|');

                if (datos.Length == 2)
                {
                    string nombre = datos[0];
                    string nit = datos[1];

                    Clientes cliente = new Clientes(contadorClientes, nombre, nit);
                    listaClientes.Add(cliente);

                    contadorClientes++;
                }
            }

            return contadorClientes;
        }
    }
}