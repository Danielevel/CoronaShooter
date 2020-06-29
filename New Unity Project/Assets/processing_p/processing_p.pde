// importa la librería video
import processing.video.*;
import processing.serial.*;
import processing.net.*;

//Instancio la variable para capturar la camara
Capture camara;
Server servidor;
String datosPosiciones = "";//Guarda la informacion que se enviara por el puerto.

// Instancio la variable del color que se va a buscar
color marcadorB;

int xMarcadorB = 0;
int yMarcadorB = 0;

// Distancia de semejanza en color
float semejanzaEnColor = 45;
float minimoDePixelesSemejantes = 50;

void settings() {
// creo la ventana
size(640, 480);
}

void setup()
{
// Iniciar servidor en el puerto 5204
servidor = new Server(this, 5204);

// Habilitar solo para depurar el driver de la camara
//String[] cameras = Capture.list();
//printArray(cameras);
//camara = new Capture(this, cameras[3]);

//En la variable video almaceno la camra
camara = new Capture(this, width, height, 30);
camara.start();

// Marcadores
marcadorB = color(46, 55, 129); // Color mano izquierda BL
}

void draw()
{
//verifica si la camara esta disponible
if (camara.available())
{
camara.read();
image(camara, 0, 0);
camara.loadPixels();

float promedioXMarcadorB = 0;
float promedioYMarcadorB = 0;

int cantidadPixelesCoincidenConMarcadorB = 0;

//empieza a recorrer cada pixel
for ( int x = 0; x < camara.width; x++ )
{
for ( int y = 0; y < camara.height; y++ )
{

color pixelActual = camara.pixels[x + y * camara.width];

float cantidadRojoDelPixelActual = red(pixelActual);
float cantidadVerdeDelPixelActual = green(pixelActual);
float cantidadAzulDelPixelActual = blue(pixelActual);

float cantidadRojoDelMarcadorB = red(marcadorB);
float cantidadVerdeDelMarcadorB = green(marcadorB);
float cantidadAzulDelMarcadorB = blue(marcadorB);

float similitudEnDistanciaDelColorMarcadorB = dist(cantidadRojoDelPixelActual, cantidadVerdeDelPixelActual, cantidadAzulDelPixelActual, cantidadRojoDelMarcadorB, cantidadVerdeDelMarcadorB, cantidadAzulDelMarcadorB); // We are using the dist( ) function to compare the current color with the color we are tracking.

// Esta muy cerca del verde
if (similitudEnDistanciaDelColorMarcadorB < semejanzaEnColor)
{
promedioXMarcadorB += x;
promedioYMarcadorB += y;
cantidadPixelesCoincidenConMarcadorB++;
}

}
}

if ( cantidadPixelesCoincidenConMarcadorB > minimoDePixelesSemejantes )
{
xMarcadorB = (int) promedioXMarcadorB / cantidadPixelesCoincidenConMarcadorB;
yMarcadorB = (int) promedioYMarcadorB / cantidadPixelesCoincidenConMarcadorB;
}

dibujarCentroide(marcadorB, xMarcadorB, yMarcadorB);

if ( xMarcadorB > 0 || yMarcadorB > 0) {
datosPosiciones = (width-xMarcadorB)+","+(height-yMarcadorB)+"\n";
} else {
datosPosiciones = "0,0,0,0\n";
}
//Enviar el dato por el puerto
servidor.write(datosPosiciones);
}
}

/**
* Dibujar centroide.
*/
void dibujarCentroide (color marcador, int xMarcador, int yMarcador) {
fill(marcador);
strokeWeight(4.0);
stroke(0);
ellipse(xMarcador, yMarcador, 16, 16);
}

/**
* Obtiene el color exacto del pixel donde
* se dio un click.
*/
void mousePressed() {

int loc = mouseX + mouseY * camara.width;
color pixelLeido = camara.pixels[loc];

float r1 = red(pixelLeido);
float g1 = green(pixelLeido);
float b1 = blue(pixelLeido);
print(r1 + " "+ g1+ " "+b1+ "\n");

//Habilitar para hacer tracking
//marcadorRojo = pixelLeido;
}
