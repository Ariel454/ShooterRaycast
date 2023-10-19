# ShooterRaycast
ShooterRaycast
Descripción
ShooterRaycast es un proyecto de Unity que te permite controlar un arma de rayos láser en un juego. Dispara a los objetos adecuados y alcanza la condición de victoria.

Requisitos
Unity 2022.3.10 o posterior
Configuración del Entorno
Paso 1: Terreno y Assets
Descarga el proyecto y ábrelo en Unity.
Configura un terreno en tu escena.
Paso 2: Arma y Personaje
Importa el "First Person Controller" y el modelo del arma como assets.
Coloca el arma dentro del objeto "Main Camera" del "First Person Controller".
Paso 3: Puntero
Crea un objeto vacío como el origen del láser y colócalo en la boca del arma.
En el Canvas, crea una imagen que servirá como puntero y configura su altura, ancho y apariencia.
Paso 4: Canvas
En el Canvas, establece la escala de la interfaz de usuario en "Scale with Screen Size".
Paso 5: Line Renderer
Elimina el collider del arma y agrega un componente "Line Renderer".
Configura el material del Line Renderer y ajusta el color del láser.
Cambia el ancho del láser a 0.1 y la posición Z a 0.
Paso 6: Configuración del Script
Agrega el script "RaycastGun" al arma.
Etiquetas y Texturas
Define etiquetas ("Cubo", "Esfera", etc.) para los objetos que quieras destruir.
Asigna las etiquetas correspondientes a los objetos en tu escena.
Contador
Agrega un contador de puntuación en el Canvas.
Asegúrate de que el contador esté en la esquina superior derecha de la pantalla.
Funcionalidad del Juego
El proyecto incluye un script de Unity escrito en C# que controla un arma de rayos láser en el juego. A continuación, se detalla su funcionalidad:

Awake()
El método Awake() se utiliza para inicializar el objeto que contiene el script y obtener una referencia al componente LineRenderer.

Update()
El método Update() controla la lógica principal del juego. Verifica si el jugador puede disparar y, en caso afirmativo, realiza un raycast desde el arma para detectar colisiones con objetos y procesarlas.

ShootLaser()
ShootLaser() controla la visibilidad del láser y crea un efecto de láser visible durante un breve período después de cada disparo.

Generador de Objetos
Agrega un GameObject llamado "Generador" a la escena.
Asigna el script "Generador.cs" al objeto "Generador".
El script "Generador.cs" se encarga de generar objetos automáticamente después de ser destruidos.

Dinámica del Juego
Para ganar el juego, debes destruir al menos 3 cubos y 2 esferas. Si cumples con esta condición, verás un mensaje de victoria en pantalla y el juego se detendrá.

Detener el Juego
La función DetenerJuego() se utiliza para pausar la lógica del juego y ajustar los componentes necesarios cuando se alcanza la condición de victoria.

Créditos
Autor: Ariel454
Licencia
Este proyecto no tiene una licencia especificada y es de código abierto.
