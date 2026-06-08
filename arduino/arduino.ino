#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <Keypad.h>


LiquidCrystal_I2C lcd(0x27, 16, 2);


const byte FILAS = 4;
const byte COLUMNAS = 3;

char teclas[FILAS][COLUMNAS] = {
  {'1', '2', '3'},
  {'4', '5', '6'},
  {'7', '8', '9'},
  {'*', '0', '#'}
};

byte pinesFilas[FILAS] = {30, 31, 32, 33};
byte pinesColumnas[COLUMNAS] = {34, 35, 36};
Keypad keypad = Keypad(makeKeymap(teclas), pinesFilas, pinesColumnas, FILAS, COLUMNAS);


const int IN1_BOMBA1 = 22;
const int IN2_BOMBA1 = 23;
const int IN1_BOMBA2 = 24;
const int IN2_BOMBA2 = 25;
const int IN1_BOMBA3 = 26;
const int IN2_BOMBA3 = 27;
const int IN1_BOMBA4 = 28;
const int IN2_BOMBA4 = 29;


const int SENSOR_AGUA_PIN = A0;
const int UMBRAL_AGUA = 400;
const bool SENSOR_ACTIVO_MAYOR = true;
const unsigned long TIEMPO_CONFIRMACION_AGUA_MS = 250;


const int TIEMPO_MAX_TANQUE_LLENO_SEG = 120;
const unsigned long DOBLE_ASTERISCO_MS = 900;


enum EstadoMenu {
  MENU_BOMBA,
  MENU_COMBUSTIBLE,
  MENU_TIPO_ABASTECIMIENTO,
  MENU_CANTIDAD,
  MENU_CONFIRMACION,
  MENU_DESPACHANDO
};

struct ResultadoDespacho {
  int segundosDespachados;
  bool paroPorSensor;
};

EstadoMenu estado = MENU_BOMBA;

int bombaSeleccionada = 0;
int combustibleSeleccionado = 0;
int tipoAbastecimiento = -1;
int cantidadPrepago = 0;

String entrada = "";
unsigned long ultimoAsterisco = 0;

bool bombaOcupada[5] = {false, false, false, false, false};
bool ocupadoGeneral = false;


void setup() {
  Serial.begin(9600);

  pinMode(IN1_BOMBA1, OUTPUT);
  pinMode(IN2_BOMBA1, OUTPUT);
  pinMode(IN1_BOMBA2, OUTPUT);
  pinMode(IN2_BOMBA2, OUTPUT);
  pinMode(IN1_BOMBA3, OUTPUT);
  pinMode(IN2_BOMBA3, OUTPUT);
  pinMode(IN1_BOMBA4, OUTPUT);
  pinMode(IN2_BOMBA4, OUTPUT);
  pinMode(SENSOR_AGUA_PIN, INPUT);

  apagarTodas();

  lcd.init();
  lcd.backlight();
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Gasolinera");
  lcd.setCursor(0, 1);
  lcd.print("Sistema listo");

  Serial.println("MEGA_LISTO_KEYPAD_BOMBAS_HW038");
  delay(1500);
  reiniciarMenu();
}


void loop() {
  leerSerialCSharp();

  char tecla = keypad.getKey();
  if (tecla) {
    manejarTecla(tecla);
  }
}


void manejarTecla(char tecla) {
  if (estado == MENU_DESPACHANDO) {
    if (tecla == '*') Serial.println("IGNORADO:DESPACHANDO");
    return;
  }

  if (tecla == '*') {
    manejarAsterisco();
    return;
  }

  if (tecla == '#') {
    confirmarEntrada();
    return;
  }

  if (tecla >= '0' && tecla <= '9') {
    agregarDigito(tecla);
  }
}

void manejarAsterisco() {
  unsigned long ahora = millis();

  if (ahora - ultimoAsterisco <= DOBLE_ASTERISCO_MS) {
    ultimoAsterisco = 0;
    entrada = "";
    regresarOpcionAnterior();
  } else {
    ultimoAsterisco = ahora;
    entrada = "";
    mostrarPantallaActual();
    lcd.setCursor(0, 1);
    lcd.print("Borrado         ");
    delay(450);
    mostrarPantallaActual();
  }
}

void agregarDigito(char tecla) {
  ultimoAsterisco = 0;

  switch (estado) {
    case MENU_BOMBA:
      if (tecla >= '1' && tecla <= '4') entrada = String(tecla);
      else mensajeTemporal("Valido: 1 a 4", "");
      break;

    case MENU_COMBUSTIBLE:
      if (tecla >= '1' && tecla <= '3') entrada = String(tecla);
      else mensajeTemporal("Valido: 1 a 3", "");
      break;

    case MENU_TIPO_ABASTECIMIENTO:
      if (tecla == '1' || tecla == '0') entrada = String(tecla);
      else mensajeTemporal("1 Prep 0 Lleno", "");
      break;

    case MENU_CANTIDAD:
      if (entrada.length() < 5) entrada += tecla;
      break;

    case MENU_CONFIRMACION:
      break;

    default:
      break;
  }

  mostrarPantallaActual();
}

void confirmarEntrada() {
  ultimoAsterisco = 0;

  switch (estado) {
    case MENU_BOMBA:
      if (entrada.length() == 0) {
        mensajeTemporal("Seleccione bomba", "1 2 3 4");
        return;
      }
      bombaSeleccionada = entrada.toInt();
      if (bombaSeleccionada < 1 || bombaSeleccionada > 4) {
        mensajeTemporal("Bomba invalida", "Use 1 a 4");
        entrada = "";
        return;
      }
      if (bombaOcupada[bombaSeleccionada]) {
        mensajeTemporal("Bomba en uso", "Elija otra");
        entrada = "";
        return;
      }
      entrada = "";
      estado = MENU_COMBUSTIBLE;
      mostrarPantallaActual();
      break;

    case MENU_COMBUSTIBLE:
      if (entrada.length() == 0) {
        mensajeTemporal("Seleccione gas", "1 2 3");
        return;
      }
      combustibleSeleccionado = entrada.toInt();
      if (combustibleSeleccionado < 1 || combustibleSeleccionado > 3) {
        mensajeTemporal("Gas invalido", "Use 1 a 3");
        entrada = "";
        return;
      }
      entrada = "";
      estado = MENU_TIPO_ABASTECIMIENTO;
      mostrarPantallaActual();
      break;

    case MENU_TIPO_ABASTECIMIENTO:
      if (entrada.length() == 0) {
        mensajeTemporal("Seleccione tipo", "1 Prep 0 Lleno");
        return;
      }
      tipoAbastecimiento = entrada.toInt();
      if (tipoAbastecimiento != 0 && tipoAbastecimiento != 1) {
        mensajeTemporal("Tipo invalido", "1 Prep 0 Lleno");
        entrada = "";
        return;
      }
      entrada = "";
      if (tipoAbastecimiento == 1) {
        estado = MENU_CANTIDAD;
      } else {
        cantidadPrepago = TIEMPO_MAX_TANQUE_LLENO_SEG;
        estado = MENU_CONFIRMACION;
      }
      mostrarPantallaActual();
      break;

    case MENU_CANTIDAD:
      if (entrada.length() == 0) {
        mensajeTemporal("Ingrese cantidad", "# para aceptar");
        return;
      }
      cantidadPrepago = entrada.toInt();
      if (cantidadPrepago <= 0) {
        mensajeTemporal("Cantidad invalida", "Mayor a 0");
        entrada = "";
        return;
      }
      entrada = "";
      estado = MENU_CONFIRMACION;
      mostrarPantallaActual();
      break;

    case MENU_CONFIRMACION:
      ejecutarOrdenDesdeMenu();
      break;

    default:
      break;
  }
}

void regresarOpcionAnterior() {
  switch (estado) {
    case MENU_BOMBA:
      reiniciarMenu();
      break;
    case MENU_COMBUSTIBLE:
      combustibleSeleccionado = 0;
      estado = MENU_BOMBA;
      break;
    case MENU_TIPO_ABASTECIMIENTO:
      tipoAbastecimiento = -1;
      estado = MENU_COMBUSTIBLE;
      break;
    case MENU_CANTIDAD:
      cantidadPrepago = 0;
      estado = MENU_TIPO_ABASTECIMIENTO;
      break;
    case MENU_CONFIRMACION:
      estado = (tipoAbastecimiento == 1) ? MENU_CANTIDAD : MENU_TIPO_ABASTECIMIENTO;
      break;
    default:
      estado = MENU_BOMBA;
      break;
  }

  mostrarPantallaActual();
}

void mostrarPantallaActual() {
  lcd.clear();

  switch (estado) {
    case MENU_BOMBA:
      lcd.setCursor(0, 0);
      lcd.print("Bomba? 1 2 3 4");
      lcd.setCursor(0, 1);
      lcd.print("Sel:");
      lcd.print(entrada);
      break;

    case MENU_COMBUSTIBLE:
      lcd.setCursor(0, 0);
      lcd.print("Gas 1S 2R 3D");
      lcd.setCursor(0, 1);
      lcd.print("B");
      lcd.print(bombaSeleccionada);
      lcd.print(" Sel:");
      lcd.print(entrada);
      break;

    case MENU_TIPO_ABASTECIMIENTO:
      lcd.setCursor(0, 0);
      lcd.print("1 Prep 0 Lleno");
      lcd.setCursor(0, 1);
      lcd.print("Gas:");
      lcd.print(nombreCombustibleCorto(combustibleSeleccionado));
      lcd.print(" Sel:");
      lcd.print(entrada);
      break;

    case MENU_CANTIDAD:
      lcd.setCursor(0, 0);
      lcd.print("Cantidad/seg:");
      lcd.setCursor(0, 1);
      lcd.print(entrada);
      break;

    case MENU_CONFIRMACION:
      lcd.setCursor(0, 0);
      lcd.print("B");
      lcd.print(bombaSeleccionada);
      lcd.print(" ");
      lcd.print(nombreCombustibleCorto(combustibleSeleccionado));
      lcd.print(" ");
      lcd.print(tipoAbastecimiento == 1 ? "Prep" : "Lleno");
      lcd.setCursor(0, 1);
      lcd.print("# OK ** Atras");
      break;

    case MENU_DESPACHANDO:
      lcd.setCursor(0, 0);
      lcd.print("Despachando B");
      lcd.print(bombaSeleccionada);
      lcd.setCursor(0, 1);
      lcd.print("Sensor activo");
      break;
  }
}

void mensajeTemporal(String linea1, String linea2) {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(linea1.substring(0, 16));
  lcd.setCursor(0, 1);
  lcd.print(linea2.substring(0, 16));
  delay(1000);
  mostrarPantallaActual();
}

String nombreCombustibleCorto(int tipo) {
  switch (tipo) {
    case 1: return "Super";
    case 2: return "Regular";
    case 3: return "Diesel";
    default: return "---";
  }
}

void reiniciarMenu() {
  bombaSeleccionada = 0;
  combustibleSeleccionado = 0;
  tipoAbastecimiento = -1;
  cantidadPrepago = 0;
  entrada = "";
  estado = MENU_BOMBA;
  mostrarPantallaActual();
}

void ejecutarOrdenDesdeMenu() {
  if (bombaSeleccionada < 1 || bombaSeleccionada > 4) {
    mensajeTemporal("Error bomba", "Reiniciando");
    reiniciarMenu();
    return;
  }

  int segundos = (tipoAbastecimiento == 0) ? TIEMPO_MAX_TANQUE_LLENO_SEG : cantidadPrepago;

  Serial.print("ORDEN_KEYPAD:B");
  Serial.print(bombaSeleccionada);
  Serial.print(":");
  Serial.print(tipoAbastecimiento == 0 ? "FULL" : String(segundos));
  Serial.print(":GAS=");
  Serial.print(nombreCombustibleCorto(combustibleSeleccionado));
  Serial.print(":TIPO=");
  Serial.println(tipoAbastecimiento == 1 ? "PREPAGO" : "LLENO");

  estado = MENU_DESPACHANDO;
  mostrarPantallaActual();

  ResultadoDespacho r = activarPorSegundos(bombaSeleccionada, segundos);

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(r.paroPorSensor ? "Paro sensor B" : "Finalizado B");
  lcd.print(bombaSeleccionada);
  lcd.setCursor(0, 1);
  lcd.print("Desp:");
  lcd.print(r.segundosDespachados);
  lcd.print(" seg");

  Serial.print("OK:FIN_KEYPAD:B");
  Serial.print(bombaSeleccionada);
  Serial.print(":DESP=");
  Serial.print(r.segundosDespachados);
  Serial.print(":PARO=");
  Serial.println(r.paroPorSensor ? "SENSOR" : "TIEMPO");

  delay(1800);
  reiniciarMenu();
}


void leerSerialCSharp() {
  if (Serial.available() <= 0) return;

  String comando = Serial.readStringUntil('\n');
  comando.trim();
  if (comando.length() == 0) return;

  procesarComandoSerial(comando);
}

void procesarComandoSerial(String comando) {
  comando.trim();
  comando.toUpperCase();

  int separador = comando.indexOf(':');
  if (separador == -1) {
    Serial.println("ERROR:FORMATO_USE_B1:5");
    return;
  }

  String bombaTexto = comando.substring(0, separador);
  String tiempoTexto = comando.substring(separador + 1);
  tiempoTexto.trim();

  if (!bombaTexto.startsWith("B")) {
    Serial.println("ERROR:BOMBA_INVALIDA");
    return;
  }

  int bomba = bombaTexto.substring(1).toInt();
  bool esLleno = (tiempoTexto == "FULL" || tiempoTexto == "LLENO" || tiempoTexto == "TANQUE");
  int segundos = esLleno ? TIEMPO_MAX_TANQUE_LLENO_SEG : tiempoTexto.toInt();

  if (bomba < 1 || bomba > 4) {
    Serial.println("ERROR:BOMBA_INVALIDA");
    return;
  }

  if (segundos <= 0) {
    Serial.println("ERROR:TIEMPO_INVALIDO");
    return;
  }

  if (ocupadoGeneral || bombaOcupada[bomba]) {
    Serial.println("BUSY");
    return;
  }

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(esLleno ? "PC lleno B" : "PC prep B");
  lcd.print(bomba);
  lcd.setCursor(0, 1);
  lcd.print(esLleno ? "Hasta sensor" : String(segundos) + " segundos");

  Serial.print("OK:INICIO:B");
  Serial.print(bomba);
  Serial.print(":MAX=");
  Serial.println(segundos);

  ResultadoDespacho r = activarPorSegundos(bomba, segundos);

  Serial.print("OK:FIN:B");
  Serial.print(bomba);
  Serial.print(":DESP=");
  Serial.print(r.segundosDespachados);
  Serial.print(":PARO=");
  Serial.println(r.paroPorSensor ? "SENSOR" : "TIEMPO");

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(r.paroPorSensor ? "Paro sensor" : "PC finalizado");
  lcd.setCursor(0, 1);
  lcd.print("B");
  lcd.print(bomba);
  lcd.print(" ");
  lcd.print(r.segundosDespachados);
  lcd.print(" seg");
  delay(1200);

  reiniciarMenu();
}


bool sensorAguaDetecta() {
  int lectura = analogRead(SENSOR_AGUA_PIN);
  if (SENSOR_ACTIVO_MAYOR) {
    return lectura >= UMBRAL_AGUA;
  }
  return lectura <= UMBRAL_AGUA;
}

bool sensorAguaConfirmado() {
  if (!sensorAguaDetecta()) return false;

  unsigned long inicio = millis();
  while (millis() - inicio < TIEMPO_CONFIRMACION_AGUA_MS) {
    if (!sensorAguaDetecta()) return false;
    delay(10);
  }
  return true;
}


ResultadoDespacho activarPorSegundos(int bomba, int segundos) {
  ResultadoDespacho r;
  r.segundosDespachados = 0;
  r.paroPorSensor = false;

  if (bomba < 1 || bomba > 4 || segundos <= 0) return r;

  ocupadoGeneral = true;
  bombaOcupada[bomba] = true;

  activarBomba(bomba);

  unsigned long inicio = millis();
  unsigned long ultimaActualizacion = 0;
  unsigned long duracion = (unsigned long)segundos * 1000UL;

  while (millis() - inicio < duracion) {
    if (sensorAguaConfirmado()) {
      r.paroPorSensor = true;
      break;
    }

    unsigned long ahora = millis();
    if (ahora - ultimaActualizacion >= 250) {
      r.segundosDespachados = (int)((ahora - inicio) / 1000UL);
      lcd.setCursor(0, 1);
      lcd.print("Desp:");
      lcd.print(r.segundosDespachados);
      lcd.print("s       ");
      ultimaActualizacion = ahora;
    }

    delay(10);
  }

  unsigned long transcurrido = millis() - inicio;
  r.segundosDespachados = (int)((transcurrido + 999UL) / 1000UL);
  if (r.segundosDespachados > segundos) r.segundosDespachados = segundos;

  apagarBomba(bomba);
  bombaOcupada[bomba] = false;
  ocupadoGeneral = false;
  return r;
}

void activarBomba(int bomba) {
  apagarTodas();

  switch (bomba) {
    case 1:
      digitalWrite(IN1_BOMBA1, HIGH);
      digitalWrite(IN2_BOMBA1, LOW);
      break;
    case 2:
      digitalWrite(IN1_BOMBA2, HIGH);
      digitalWrite(IN2_BOMBA2, LOW);
      break;
    case 3:
      digitalWrite(IN1_BOMBA3, HIGH);
      digitalWrite(IN2_BOMBA3, LOW);
      break;
    case 4:
      digitalWrite(IN1_BOMBA4, HIGH);
      digitalWrite(IN2_BOMBA4, LOW);
      break;
  }
}

void apagarBomba(int bomba) {
  switch (bomba) {
    case 1:
      digitalWrite(IN1_BOMBA1, LOW);
      digitalWrite(IN2_BOMBA1, LOW);
      break;
    case 2:
      digitalWrite(IN1_BOMBA2, LOW);
      digitalWrite(IN2_BOMBA2, LOW);
      break;
    case 3:
      digitalWrite(IN1_BOMBA3, LOW);
      digitalWrite(IN2_BOMBA3, LOW);
      break;
    case 4:
      digitalWrite(IN1_BOMBA4, LOW);
      digitalWrite(IN2_BOMBA4, LOW);
      break;
  }
}

void apagarTodas() {
  digitalWrite(IN1_BOMBA1, LOW);
  digitalWrite(IN2_BOMBA1, LOW);
  digitalWrite(IN1_BOMBA2, LOW);
  digitalWrite(IN2_BOMBA2, LOW);
  digitalWrite(IN1_BOMBA3, LOW);
  digitalWrite(IN2_BOMBA3, LOW);
  digitalWrite(IN1_BOMBA4, LOW);
  digitalWrite(IN2_BOMBA4, LOW);
}
