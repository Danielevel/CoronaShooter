// Leer datos de procesing en Unity
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class proceesing : MonoBehaviour
{
    internal Boolean socketReady = false;
    TcpClient mySocket;
    NetworkStream theStream;
    StreamReader theReader;
    String Host = "localhost";
    Int32 Port = 5204;

    public GameObject Player;
    public float tcpX = 0;
    public float tcpY = 0;
    public float tcpX2 = 0;
    public float tcpY2 = 0;

    public GameObject ESCUDO;
    public GameObject ESPADA;

    void Start()
    {
        abrirElSocket();
    }

    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);

        leerDatosProcessing();

        ESCUDO.transform.localPosition = new Vector3(tcpX, tcpY,(float) 0.74);
        ESPADA.transform.localPosition = new Vector3(tcpX2, tcpY2, (float)0.74);
    }

    /**
    * camara1 : telnet localhost 5204 205, 100, 34
    * camara2 : telnet localhost 5205 207, 99, 35
    *
    * camara3 : telnet localhost 5206
    * camara4 : telnet localhost 5207
    * /

/**
    * Leemos los datos que llegan por el socket
    * esta informacion la envia processing.
    * */
    public void leerDatosProcessing()
    {
        string informacion = readSocket();
        if (informacion != "")
        {
            string[] partes = informacion.Split(
            new string[] { "," },
            StringSplitOptions.None
            );
            Debug.Log("X=" + partes[0] + " Y=" + partes[1]);
            tcpX = (float)(Int32.Parse(partes[0])/150.000);
            tcpY = (float)(Int32.Parse(partes[1])/150.000);
            tcpX2 = (float)(Int32.Parse(partes[2])/150.000);
            tcpY2 = (float)(Int32.Parse(partes[3])/150.000);
        }
    }


    /**
    * Crea el socket al puerto e Ip datos.
    * **/
    public void abrirElSocket()
    {
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
        }
    }

    /**
    * Lee datos del socket
    * **/
    public String readSocket()
    {
        if (!socketReady)
            return "";
        if (theStream.DataAvailable)
            return theReader.ReadLine();
        return "";
    }

    /**
    * Cierra el socket
    * */
    public void closeSocket()
    {
        if (!socketReady)
            return;
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }
}
