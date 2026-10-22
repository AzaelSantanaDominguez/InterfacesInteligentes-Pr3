# InterfacesInteligentes-Pr3

# Ejercicio 1: Sistema de eventos y colisiones entre esferas

## Objetivo

Crear una escena en Unity con cinco esferas, un cubo y un cilindro. Las esferas se dividen en dos grupos y reaccionan de forma diferente cuando el cubo colisiona con el cilindro.

## Elementos de la escena

- **Esferas rojas:** pertenecen al tipo 1 y tienen la etiqueta `EscudoTipo1`.
- **Esferas verdes:** pertenecen al tipo 2 y tienen la etiqueta `EscudoTipo2`.
- **Cubo:** es el objeto que se mueve por la escena y provoca la colisión.
- **Cilindro:** detecta la colisión con el cubo y envía el evento que activa el comportamiento de las esferas.

## Desarrollo

Se creó el script `GestorEventos.cs`, encargado de detectar cuándo el cubo colisiona con el cilindro mediante el evento de colisión correspondiente.

Cuando se produce la colisión, se envía un evento para notificar a las esferas que deben reaccionar.

También se utilizó el script `HumanoideReaccion.cs` para implementar la respuesta de los objetos suscritos al evento. Aunque el nombre del script hace referencia a humanoides, su función en este ejercicio es gestionar la reacción de los objetos que lo tienen asignado.

Las esferas del tipo 1 se desplazan hacia una esfera verde seleccionada previamente como objetivo. Las esferas del tipo 2 se mueven hacia el cilindro.

Para diferenciar los comportamientos se utilizaron las etiquetas de los objetos y un sistema de eventos, de manera que cada grupo ejecuta la acción que le corresponde cuando recibe la notificación.

## Resultado

Se implementó un sistema de comunicación mediante eventos en el que una colisión entre el cubo y el cilindro provoca una reacción en las esferas de ambos grupos.

Las esferas rojas se dirigen hacia una esfera verde elegida previamente, mientras que las verdes se desplazan hacia el cilindro. De esta forma, se trabaja con detección de colisiones, etiquetas, suscripción a eventos y comportamientos diferenciados según el tipo de objeto.

<img width="1917" height="1029" alt="Ej1" src="https://github.com/user-attachments/assets/a7e61d05-504f-4a44-90ca-21b6cbd48a5d" />
<img width="1918" height="1018" alt="Ej2" src="https://github.com/user-attachments/assets/f1fdc293-9e5b-48e8-b503-b17919bdcb47" />

# Ejercicio 2/3: Humanoides y reacciones mediante eventos

## Objetivo

Adaptar la escena del ejercicio anterior sustituyendo los objetos geométricos por modelos humanoides y ampliando las mecánicas para que los personajes reaccionen a las colisiones con el cubo y con los escudos.

## Elementos de la escena

Se incorporaron dos modelos de la Unity Asset Store:

- **Mini Legion Footman:** utilizado para representar humanoides de uno de los grupos.
- **Mini Legion Lich:** utilizado para representar humanoides del otro grupo.

También se añadieron escudos de tipo 1 y tipo 2, junto con el cubo del jugador, que permite activar las distintas reacciones.

Para diferenciar los objetos se utilizaron las etiquetas `EscudoTipo1` y `EscudoTipo2`.

## Desarrollo

Se adaptó el sistema de eventos del ejercicio anterior para trabajar con los nuevos modelos humanoides.

El script `GestorEventos.cs` se encarga de detectar las colisiones del cubo con los humanoides y emitir los eventos correspondientes según el grupo del objeto con el que colisiona.

Mediante el script `HumanoideReaccion.cs`, los personajes reciben estos eventos y ejecutan diferentes comportamientos:

- Cuando el cubo colisiona con un humanoide del tipo 2, los humanoides del grupo 1 se desplazan hacia un escudo seleccionado previamente.
- Cuando el cubo colisiona con un humanoide del tipo 1, los humanoides de ese grupo provocan que los del grupo 2 se dirijan hacia los escudos correspondientes.
- Cuando un humanoide colisiona con uno de los escudos físicos, cambia su color para indicar que se ha producido la interacción.

Para detectar correctamente las colisiones se configuraron los colliders de los humanoides y de los escudos, teniendo en cuenta las características de los modelos importados.

## Resultado

Se amplió la escena inicial incorporando personajes humanoides y diferentes tipos de escudos. Se implementó un sistema de eventos que permite coordinar los movimientos de los personajes según las colisiones del jugador y modificar su apariencia al entrar en contacto con determinados objetos.

Este ejercicio permite trabajar con modelos importados, etiquetas, colliders, eventos, suscripciones y comportamientos diferentes para cada grupo de humanoides.

<img width="1918" height="1018" alt="Ej2" src="https://github.com/user-attachments/assets/07f21a92-e6c7-4c26-b816-ba81bf3a3a79" />

## Ejercicio 4: Teletransporte de los humanoides del grupo 1

Se añadió un objeto de referencia en la escena y se seleccionó previamente un escudo objetivo utilizando los modelos del paquete [3D Low Poly Shields](https://assetstore.unity.com/packages/3d/props/weapons/3d-low-poly-shields-239460).

Cuando el cubo se aproxima al objeto de referencia, se activa un evento que provoca que los humanoides del grupo 1 se teletransporten directamente a la posición del escudo objetivo.

Para implementar este comportamiento, se utiliza un sistema de detección de proximidad entre el cubo y el objeto de referencia. Cuando se cumple la condición de proximidad, se notifica a los humanoides suscritos al evento, que ejecutan el teletransporte a la posición previamente establecida.

El escudo objetivo se configura antes de iniciar la escena, de modo que todos los humanoides del grupo 1 conocen el destino al que deben desplazarse.

### Resultado

Esta mecánica permite trabajar con la detección de proximidad, la comunicación mediante eventos, la asignación de referencias entre objetos y el cambio directo de posición de los humanoides mediante el teletransporte.

<img width="1918" height="1028" alt="Ej4" src="https://github.com/user-attachments/assets/ebfba83d-8d83-43b9-aeeb-18a96b44d26a" />

# Ejercicio 5: Recolección de escudos y sistema de puntuación

## Objetivo

Implementar una mecánica de recolección de escudos en la escena de Unity. Cada vez que el jugador recoja un escudo, la puntuación se actualizará según su tipo y se mostrará el resultado en la consola.

## Mecánica implementada

Se establecieron dos tipos de escudos, identificados mediante sus etiquetas (*Tags*):

- **Escudo tipo 1 (`EscudoTipo1`):** suma 5 puntos.
- **Escudo tipo 2 (`EscudoTipo2`):** suma 10 puntos.

Cuando el cubo del jugador entra en contacto con un escudo, el sistema identifica su tipo, añade los puntos correspondientes y actualiza la puntuación total. Después, el escudo recolectado se elimina de la escena para evitar que se contabilice varias veces.

## Scripts utilizados

- **`RecolectarEscudos.cs`:** detecta las colisiones con los escudos, identifica su tipo, suma los puntos correspondientes y elimina el escudo recogido.

## Visualización de la puntuación

La puntuación acumulada se muestra en la consola de Unity mediante mensajes de `Debug.Log()`. De esta manera, es posible comprobar cuántos puntos obtiene el jugador al recoger cada escudo y cuál es su puntuación total.

## Resultado

Se implementó un sistema de recolección que distingue entre los dos tipos de escudos y actualiza correctamente la puntuación del jugador: 5 puntos por cada escudo de tipo 1 y 10 puntos por cada escudo de tipo 2.

<img width="1916" height="1032" alt="Ej5" src="https://github.com/user-attachments/assets/abb75f07-86dc-4c0e-9bd0-fb5149273188" />

# Ejercicio 6: Interfaz visual de puntuación

## Objetivo

Modificar el sistema de puntuación del ejercicio anterior para incorporar una interfaz gráfica que muestre en pantalla los puntos que va obteniendo el cubo al recoger escudos.

## Desarrollo

Se reutilizó el sistema de recolección de escudos del ejercicio 5, manteniendo los valores de puntuación:

- **Escudo tipo 1 (`EscudoTipo1`):** suma 5 puntos.
- **Escudo tipo 2 (`EscudoTipo2`):** suma 10 puntos.

Se creó una interfaz de usuario (UI) en Unity mediante un elemento de texto para mostrar la puntuación actual del jugador.

El script encargado de gestionar la recolección actualiza la puntuación cuando el cubo recoge un escudo y comunica el nuevo valor al componente de interfaz, que actualiza el texto mostrado en pantalla.

## Scripts utilizados

- **`RecolectarEscudos.cs`:** detecta los escudos recogidos y calcula la puntuación acumulada.
- **`PuntuacionUI.cs`:** actualiza el texto de la interfaz para mostrar la puntuación actual.

## Configuración en Unity

1. Crear un elemento de texto dentro de un `Canvas` para mostrar la puntuación.
2. Añadir o configurar el script `PuntuacionUI.cs` para controlar el texto.
3. Asignar el componente de texto a la referencia correspondiente en el Inspector.
4. Conectar el sistema de recolección con la interfaz para actualizar la puntuación cada vez que se recoge un escudo.

## Resultado

La puntuación del jugador se muestra directamente en pantalla y se actualiza en tiempo real cada vez que el cubo recoge un escudo, facilitando el seguimiento de los puntos obtenidos durante la partida.

<img width="1918" height="1030" alt="Ej6" src="https://github.com/user-attachments/assets/52db1b79-b495-4f2a-b38e-fa52fab1166e" />

# Ejercicio 7: Recompensas por puntuación

## Objetivo

Ampliar el sistema de puntuación de los ejercicios anteriores para que el jugador obtenga una recompensa cada vez que alcance 100 puntos. La recompensa se mostrará mediante un mensaje en la interfaz de usuario (UI).

## Desarrollo

Se reutilizó el sistema de recolección de escudos y la interfaz de puntuación implementados anteriormente.

La puntuación se acumula según el tipo de escudo recogido:

- **Escudo tipo 1 (`EscudoTipo1`):** suma 5 puntos.
- **Escudo tipo 2 (`EscudoTipo2`):** suma 10 puntos.

Se añadió una mecánica que comprueba cuándo la puntuación alcanza un nuevo múltiplo de 100. Cada vez que esto sucede, se muestra un mensaje de recompensa en la interfaz.

Por ejemplo, al alcanzar 100, 200 o 300 puntos, el jugador recibe una nueva recompensa.

## Scripts utilizados

- **`RecolectarEscudos.cs`:** detecta los escudos recogidos y actualiza la puntuación.
- **`PuntuacionUI.cs`:** muestra la puntuación actual y el mensaje de recompensa en la interfaz.

## Configuración en Unity

1. Reutilizar el `Canvas` y el texto de puntuación del ejercicio anterior.
2. Añadir un elemento de texto adicional para mostrar las recompensas.
3. Asignar los componentes de texto a las referencias correspondientes en el Inspector.
4. Configurar la lógica para detectar cada nuevo múltiplo de 100 puntos y mostrar el mensaje de recompensa.

## Resultado

El jugador puede consultar su puntuación en pantalla y recibe una notificación visual cada vez que alcanza otros 100 puntos, añadiendo un incentivo para seguir recogiendo escudos durante la partida.

<img width="1917" height="1033" alt="Ej7" src="https://github.com/user-attachments/assets/653b484f-1e9e-4b7a-8553-8ee137939a80" />

# Ejercicio 8: Creación de una escena basada en el prototipo

## Objetivo

Diseñar una escena en Unity que se adapte a la temática del prototipo e integre algunos de los elementos y mecánicas implementados en los ejercicios anteriores.

## Diseño de la escena

Se creó una escena jugable utilizando elementos 3D que encajan con la temática del prototipo. Se incorporaron un escenario, el cubo controlado por el jugador y diferentes escudos que pueden aparecer distribuidos por la escena.

Los elementos se organizaron para permitir que el jugador interactúe con ellos y pueda poner en práctica las mecánicas desarrolladas previamente.

## Mecánicas incorporadas

Se reutilizaron algunas de las funcionalidades implementadas en los ejercicios anteriores:

- **Movimiento del jugador:** el cubo puede desplazarse por el escenario.
- **Recolección de escudos:** el jugador puede recoger escudos de tipo 1 y tipo 2.
- **Sistema de puntuación:** los escudos de tipo 1 suman 5 puntos y los de tipo 2 suman 10 puntos.
- **Interfaz de usuario:** la puntuación se muestra en pantalla y se actualiza al recoger escudos.
- **Sistema de recompensas:** cada vez que el jugador alcanza otros 100 puntos, aparece una notificación de recompensa en la interfaz.

## Organización de la escena

Se distribuyeron los objetos dentro del escenario para facilitar la interacción y hacer que la experiencia resulte clara para el jugador. También se configuraron los componentes físicos y las colisiones necesarios para que las mecánicas funcionen correctamente.

## Resultado

Se obtuvo una escena de Unity basada en el prototipo, combinando elementos visuales y mecánicas desarrolladas durante las prácticas. La escena permite controlar al jugador, recoger escudos, acumular puntos y recibir recompensas, integrando varios de los sistemas creados en los ejercicios anteriores.

<img width="1918" height="1031" alt="Ej8" src="https://github.com/user-attachments/assets/e731d481-da5d-4d3e-beff-e747833e8e21" />
