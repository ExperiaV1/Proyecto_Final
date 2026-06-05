using System;
using System.Threading.Tasks;

namespace ProyectoFinalProgra.Clases
{
    internal class Bomba
    {
        private int id;
        private string nombre;
        private bool estaActivo;
        private decimal litrosDespachados;

        public int Id { get { return id; } }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }
                nombre = value;
            }
        }

        public bool EstaActivo { get { return estaActivo; } }

        public decimal LitrosDespachados { get { return litrosDespachados; } }

        public Bomba(int id, string nombre)
        {
            this.id = id;
            Nombre = nombre;
            estaActivo = false;
            litrosDespachados = 0;
        }

        public Bomba() { }

        public async Task IniciarDespachoAsync()
        {
            if (estaActivo)
            {
                throw new InvalidOperationException($"La bomba {nombre} ya está en uso.");
            }

            estaActivo = true;
            ResetearLitros();
            await Task.Delay(50);
        }

        public async Task DetenerDespachoAsync()
        {
            estaActivo = false;
            await Task.Delay(50);
        }

        public void Liberar()
        {
            estaActivo = false;
            ResetearLitros();
        }

        public void RegistrarLitros(decimal litros)
        {
            if (litros < 0)
            {
                throw new ArgumentException("La cantidad de litros no puede ser negativa.");
            }

            litrosDespachados += litros;
        }

        public async Task FinalizarSesionAsync()
        {
            await DetenerDespachoAsync();
            ResetearLitros();
        }

        public async Task ReiniciarBombaAsync()
        {
            estaActivo = false;
            ResetearLitros();
            await Task.Delay(50);
        }

        private void ResetearLitros()
        {
            litrosDespachados = 0;
        }
    }
}
