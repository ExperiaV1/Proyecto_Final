using ProyectoFinalProgra.DeAbastecimientos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace ProyectoFinalProgra.DeAbastecimientos
{
    [JsonDerivedType(typeof(AbastecimientoPrepago), typeDiscriminator: "prepago")]
    [JsonDerivedType(typeof(AbastecimientoTanqueLleno), typeDiscriminator: "tanqueLleno")]
    public abstract class Abastecimiento
    {
        //----Atributos Privados----
        private int id;
        private int clienteId;
        private int bombaId;
        private decimal cantidadPagada;
        private decimal litrosDespachados;
        private DateTime fecha;
        private string estado;
        private string tipoCombustible;

        //----Propiedades Publicas----
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ClienteId
        {
            get { return clienteId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del cliente no es válido.");
                clienteId = value;
            }
        }
        public int BombaId
        {
            get { return bombaId; }
            set { bombaId = value; }
        }

        public decimal CantidadPagada
        {
            get { return cantidadPagada; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La cantidad pagada no puede ser negativa.");
                }
                cantidadPagada = value;
            }
        }
        public decimal LitrosDespachados
        {
            get { return litrosDespachados; }
            set { litrosDespachados = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string TipoCombustible
        {
            get { return tipoCombustible; }
            set { tipoCombustible = value; }
        }
        protected Abastecimiento() { }

        public virtual void RegistrarDespacho(decimal litrosRecibidos)
        {
            LitrosDespachados = litrosRecibidos;
            ActualizarEstado();
        }
        public abstract void ActualizarEstado();
    }
}
