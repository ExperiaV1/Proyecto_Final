using ProyectoFinalProgra.Clases;
using ProyectoFinalProgra.DeAbastecimientos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class PanelCentral
    {
        // ----Atributos privados----
        private List<Bomba> bombas;
        private List<Abastecimiento> abastecimientos;
        private PrecioCombustible precio;
        private Estadisticas estadisticas;
        private List<Clientes> clientes;
        private Arduino arduino;

        private const string rutaArchivo = @"C:\Gasolinera\abastecimientos.json";
        private const string rutaPrecio = @"C:\Gasolinera\precio_dia.json";
        private const string rutaClientes = @"C:\Gasolinera\clientes.json";

        private int contadorId;
        private int contadorClienteId;

        // ----Propiedades públicas----
        public List<Bomba> Bombas { get { return bombas; } }
        public List<Abastecimiento> Abastecimientos { get { return abastecimientos; } }
        public PrecioCombustible Precio { get { return precio; } }

        // ----Constructor----
        public PanelCentral()
        {
            Directory.CreateDirectory(@"C:\Gasolinera");

            abastecimientos = new List<Abastecimiento>();
            bombas = new List<Bomba>();
            clientes = new List<Clientes>();
            contadorId = 1;
            contadorClienteId = 1;

            
            arduino = new Arduino("COM15");

            for (int i = 1; i <= 4; i++)
                bombas.Add(new Bomba(i, $"Bomba {i}"));

            CargarPrecio();
            CargarAbastecimientos();
            CargarClientes();

            VincularHistorialClientes();
            estadisticas = new Estadisticas(abastecimientos, clientes);
        }


       
        public async Task<string> IniciarPrepago(string nombreCliente, string nit, string tipoGas, int bombaId, decimal monto)
        {
            Bomba bomba = BuscarBomba(bombaId);
            if (bomba == null)
                throw new Exception($"No existe la bomba {bombaId}.");

            if (monto <= 0)
                throw new Exception("La cantidad debe ser mayor a 0.");

            int segundosSolicitados = (int)Math.Round(monto, MidpointRounding.AwayFromZero);
            if (segundosSolicitados <= 0) segundosSolicitados = 1;

            await bomba.IniciarDespachoAsync();

            string enviarMensaje = $"B{bombaId}:{segundosSolicitados}";

            try
            {
                Clientes cliente = BuscarOCrearCliente(nombreCliente, nit);

                int timeoutMs = (segundosSolicitados + 15) * 1000;
                DespachoResultado resultado = await Task.Run(() => arduino.EnviarYEsperarFin(enviarMensaje, timeoutMs));

                decimal segundosReales = resultado.SegundosDespachados;

                AbastecimientoPrepago nuevo = new AbastecimientoPrepago(
                    contadorId++,
                    cliente.Id,
                    bombaId,
                    monto,
                    precio,
                    tipoGas
                );

                nuevo.RegistrarDespacho(segundosReales);

                cliente.AgregarAbastecimientos(nuevo);
                abastecimientos.Add(nuevo);

                GuardarAbastecimientos();
                GuardarClientes();

                string detalleParo = resultado.ParoPorSensor ? "SENSOR_AGUA" : "TIEMPO_COMPLETO";
                return $"{enviarMensaje} | Despachado real: {segundosReales} seg | Paro: {detalleParo}";
            }
            finally
            {
                await bomba.ReiniciarBombaAsync();
            }
        }

        
        public async Task<string> IniciarTanqueLleno(string nombreCliente, string nit, int bombaId, string tipoGas = "")
        {
            Bomba bomba = BuscarBomba(bombaId);
            if (bomba == null)
                throw new Exception($"No existe la bomba {bombaId}.");

            await bomba.IniciarDespachoAsync();

            string enviarMensaje = $"B{bombaId}:FULL";

            try
            {
                Clientes cliente = BuscarOCrearCliente(nombreCliente, nit);

                int timeoutMs = 140000;
                DespachoResultado resultado = await Task.Run(() => arduino.EnviarYEsperarFin(enviarMensaje, timeoutMs));

                decimal segundosReales = resultado.SegundosDespachados;

                AbastecimientoTanqueLleno nuevo = new AbastecimientoTanqueLleno(
                    contadorId++,
                    cliente.Id,
                    bombaId,
                    precio,
                    tipoGas
                );

                nuevo.RegistrarDespacho(segundosReales);

                cliente.AgregarAbastecimientos(nuevo);
                abastecimientos.Add(nuevo);

                GuardarAbastecimientos();
                GuardarClientes();

                string detalleParo = resultado.ParoPorSensor ? "SENSOR_AGUA" : "LIMITE_SEGURIDAD";
                return $"{enviarMensaje} | Despachado real: {segundosReales} seg | Paro: {detalleParo}";
            }
            finally
            {
                await bomba.ReiniciarBombaAsync();
            }
        }

        public void DetenerBomba (int bombaId)
        {
            Bomba bomba = BuscarBomba(bombaId);
            if(bomba != null)
            {
                string comandoParo = $"B{bombaId}: PARO";
                try
                {
                    arduino.Enviar(comandoParo);
                }
                catch (Exception ex) 
                {
                    throw new Exception($"Error al intentar enviar comando de paro a la bomba {bombaId}: {ex.Message}");
                }
            }

        }

        public void LiberarBomba(int bombaId)
        {
            Bomba bomba = BuscarBomba(bombaId);
            if (bomba != null)
            {
                bomba.Liberar();
            }   
        }

        public void CerrarArduino()
        {
            if (arduino != null)
            {
                arduino.Cerrar();
            }
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            precio = new PrecioCombustible(nuevoPrecio);
            GuardarPrecio();
        }

        // Métodos de estadísticas
        public List<Abastecimiento> ObtenerCierreDiario(DateTime fecha) { return estadisticas.CierreCajaDiario(fecha); }
        public decimal ObtenerTotalDia(DateTime fecha) { return estadisticas.TotalRecaudado(fecha); }
        public List<Abastecimiento> ObtenerInformePrepagos() { return estadisticas.InformePrepagos(); }
        public List<Abastecimiento> ObtenerInformeTanqueLleno() { return estadisticas.InformeTanqueLleno(); }
        public int ObtenerBombaMasUsada() { return estadisticas.BombaMasUtilizada(); }
        public int ObtenerBombaMenosUsada() { return estadisticas.BombaMenosUtilizada(); }
        public int ObtenerUsosDeBomba(int bombaId) { return estadisticas.UsosDeBomba(bombaId); }

        private Clientes BuscarOCrearCliente(string nombre, string nit)
        {
            foreach (var c in clientes)
            {
                if (c.NIT == nit)
                    return c;
            }

            Clientes nuevo = new Clientes(contadorClienteId++, nombre, nit);
            clientes.Add(nuevo);
            return nuevo;
        }

        private Clientes BuscarClientePorId(int id)
        {
            foreach (var c in clientes)
            {
                if (c.Id == id) return c;
            }
            return null;
        }

        private void VincularHistorialClientes()
        {
            foreach (var a in abastecimientos)
            {
                Clientes cliente = BuscarClientePorId(a.ClienteId);
                if (cliente != null)
                {
                    cliente.AgregarAbastecimientos(a);
                }
            }
        }

        private void GuardarClientes()
        {
            try
            {
                string json = JsonSerializer.Serialize(clientes, OpcionesJson());
                File.WriteAllText(rutaClientes, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar clientes: {ex.Message}");
            }
        }

        private void CargarClientes()
        {
            try
            {
                if (File.Exists(rutaClientes))
                {
                    string json = File.ReadAllText(rutaClientes);
                    List<Clientes> cargados = JsonSerializer.Deserialize<List<Clientes>>(json);
                    if (cargados != null)
                    {
                        clientes = cargados;
                        foreach (var c in clientes)
                        {
                            if (c.Id >= contadorClienteId)
                                contadorClienteId = c.Id + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar clientes: {ex.Message}");
            }
        }

        private Bomba BuscarBomba(int id)
        {
            foreach (var b in bombas)
            {
                if (b.Id == id)
                    return b;
            }
            return null;
        }

        private void GuardarAbastecimientos()
        {
            try
            {
                string json = JsonSerializer.Serialize(abastecimientos, OpcionesJson());
                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar abastecimientos: {ex.Message}");
            }
        }

        private void CargarAbastecimientos()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string json = File.ReadAllText(rutaArchivo);
                    List<Abastecimiento> cargados = JsonSerializer.Deserialize<List<Abastecimiento>>(json);

                    if (cargados != null)
                    {
                        abastecimientos = cargados;
                        foreach (var a in abastecimientos)
                        {
                            if (a.Id >= contadorId)
                                contadorId = a.Id + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar abastecimientos: {ex.Message}");
            }
        }

        private void GuardarPrecio()
        {
            try
            {
                string json = JsonSerializer.Serialize(precio, OpcionesJson());
                File.WriteAllText(rutaPrecio, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar precio: {ex.Message}");
            }
        }

        private void CargarPrecio()
        {
            try
            {
                if (File.Exists(rutaPrecio))
                {
                    string json = File.ReadAllText(rutaPrecio);
                    precio = JsonSerializer.Deserialize<PrecioCombustible>(json);
                }
                else
                {
                    precio = new PrecioCombustible(10);
                }
            }
            catch
            {
                precio = new PrecioCombustible(10);
            }
        }

        private JsonSerializerOptions OpcionesJson()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }


    }
    
}