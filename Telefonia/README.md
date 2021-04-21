# Parcial 01

## Indications
Etapa I: Registro de usuario (cuenta telefónica recién adquirida)

El usuario deberá introducir los siguientes datos:
- Nombre completo.
- Número de DUI.
- Número de NIT.
- Fecha de nacimiento.
- Correo electrónico.
La aplicación generará:
- Número telefónico (generado aleatoriamente).
- PIN o contraseña (generado aleatoriamente).

Etapa II: Registro de dispositivos (un usuario puede tener N dispositivos)

Atributos para todos los dispositivos:
- Saldo actual (medido en dólar EEUU).
Atributos para todos los Smartphones:
- Datos disponibles para navegar en la web (medido en MB).
- Datos disponibles para navegar en redes sociales (medido en MB).
- Cantidad de canciones disponibles para escuchar.

Existirán distintos tipos de dispositivos:
- Teléfono Legacy (viejito).
- Smartphone Android:
  - Atributos adicionales: Marca, Modelo, Versión del SO.
- Smartphone iOS:
  - Atributos adicionales: Apple ID (generado aleatoriamente), Versión del SO.

Etapa III: Uso cotidiano de los dispositivos (menú que se repetirá N veces)

Parte A: Uso de los dispositivos (subconjunto de la Etapa III)

Métodos para los dispositivos:
- General:
  - Realizar llamadas (cada minuto cuesta $0.15).
  - Enviar SMS (cada 20 caracteres o fracción, cuesta $0.05).
- Propio de los Smartphones:
  - Reproducir música (ya sea en Spotify para Android o iTunes para iOS).
  - Navegar en la Web (cada página consultada cuesta 4 MB).
  - Navegar en redes sociales (cada minuto cuesta 2 MB).

Parte B: Solicitudes de servicios (subconjunto de la Etapa III)

Los servicios solicitados dependen de cada dispositivo:
- Teléfono Legacy (viejito)
  - Recargar saldo.
  - No admite solicitud de paquete (de ningún tipo).
- Smartphone Android
  - Recargar saldo (medido en dólar EEUU).
  - Paquetes propios para Android: Spotify (medido en canciones).
  - Paquetes generales: redes sociales, datos (medido en MB).
- Smartphone iOS
  - Recargar saldo (medido en dólar EEUU).
  - Paquetes propios para iOS: iTunes (medido en canciones).
  - Paquetes generales: redes sociales, datos (medido en MB).

Precio de los paquetes:
- Spotify, iTunes: $3.00 - 200 canciones.
- Redes sociales: $4.00 - 500 MB.
- Datos para navegación general: $5.00 - 500 MB.

Requisitos técnicos
- Jerarquía de Herencia: para tipos de dispositivos.
- La base de la jerarquía (Teléfono) debe ser clase abstracta.
- Uso de interfaces: para servicio de paquetería.
- Uso de estructuras dinámicas: List, ArrayList o HashTable.
- Clases estáticas: para generación aleatoria de número de teléfono, PIN/contraseña y Apple ID.
- Diagramas UML de clases y de casos de uso.

Otros requisitos:
- Restricciones o validaciones: el saldo y la cantidad de datos o canciones nunca deben ser negativos.
- Los números de teléfono deben tener 8 dígitos (sin usar expresiones regulares).
- Las llamadas no deben superar los 240 minutos de duración (aunque tenga suficiente saldo).
- Los SMS no deben superar los 100 caracteres (aunque tenga suficiente saldo).
- Los paquetes pueden ser acumulativos. Ejemplo: al contratar 2 veces un paquete de redes sociales, se tendrán 1000 MB disponibles.
- Seguir las buenas prácticas y el código en inglés.
- Se evidencia el trabajo de ambos miembros del clan, mediante commits equitativos y significativos.

Punto extra (+1.0):
- Llevar un registro histórico de movimientos realizados (adquisición y gasto) en cada dispositivo, tomando en cuenta: llamadas, SMS, datos y canciones.
- Esto mediante una lista donde cada nodo sea de tipo “Movimiento”, una clase cuyos atributos sean: valor (double) y concepto (string).
- Mostrar un resumen de todos los movimientos realizados por el usuario (tomando en cuenta todos sus dispositivos), previa autenticación mediante su PIN/contraseña.
