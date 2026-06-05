using ProyectoFinalProgra.Clases;
using System;

namespace ProyectoFinalProgra.DeAbastecimientos
{
    internal class AbastecimientoTanqueLleno : Abastecimiento
    {
        public decimal PrecioPorLitro { get; set; }

        public AbastecimientoTanqueLleno(int id, int clienteId, int bombaId, PrecioCombustible precio, string tipoCombustible = "")
        {
            Id = id;
            ClienteId = clienteId;
            BombaId = bombaId;
            Fecha = DateTime.Now;
            Estado = "pendiente";
            LitrosDespachados = 0;
            CantidadPagada = 0;
            PrecioPorLitro = precio.PrecioPorLitro;
            TipoCombustible = tipoCombustible;
        }

        public AbastecimientoTanqueLleno() { }

        public override void RegistrarDespacho(decimal litrosRecibidos)
        {
            // Por ahora este valor representa segundos reales despachados.
            LitrosDespachados = litrosRecibidos;

            // Para pruebas, la cantidad en base de datos tambien queda en segundos reales.
            // Cuando calibres caudal, aqui puedes convertir segundos a litros y dinero real.
            CantidadPagada = LitrosDespachados;

            ActualizarEstado();
        }

        public override void ActualizarEstado()
        {
            Estado = "completo_sensor";
        }
    }
}
