using ProyectoFinalProgra.Clases;
using System;

namespace ProyectoFinalProgra.DeAbastecimientos
{
    internal class AbastecimientoPrepago : Abastecimiento
    {
        public decimal LitrosSolicitados { get; set; }

        public AbastecimientoPrepago(int id, int clienteId, int bombaId, decimal cantidadPagada, PrecioCombustible precio, string tipoCombustible)
        {
            Id = id;
            ClienteId = clienteId;
            BombaId = bombaId;
            Fecha = DateTime.Now;
            Estado = "pendiente";

            // En esta version de pruebas, 1 unidad ingresada = 1 segundo de bomba.
            // Por eso usamos cantidadPagada como segundos solicitados.
            CantidadPagada = cantidadPagada;
            LitrosSolicitados = cantidadPagada;
            LitrosDespachados = 0;
            TipoCombustible = tipoCombustible;
        }

        public AbastecimientoPrepago() { }

        public override void RegistrarDespacho(decimal litrosRecibidos)
        {
            // Por ahora este valor representa segundos reales despachados.
            LitrosDespachados = litrosRecibidos;

            // Si el sensor paro antes, la base de datos guarda lo realmente despachado,
            // no lo que el usuario habia elegido.
            CantidadPagada = LitrosDespachados;

            ActualizarEstado();
        }

        public override void ActualizarEstado()
        {
            Estado = LitrosDespachados >= LitrosSolicitados ? "completo" : "incompleto_sensor";
        }
    }
}
