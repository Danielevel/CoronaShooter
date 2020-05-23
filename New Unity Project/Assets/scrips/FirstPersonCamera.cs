using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public Vector3 offset;
    public Vector3 off;
    private Transform target;
    [Range (0, 1)] public float lerpValue;

    public float sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        ClickDerechoCamara();

        transform.LookAt(target);
    }


    void ClickDerechoCamara()
    {
        /*
        QUE HACE ESTA FUNCION:
        -si se esta apulsando el click derecho, la camara rotara en torno al personaje como eje y la posicion del mouse.
        -si se deja de pulsar click derecho, el ultimo valor registrado de rotacion se guarda en "off" y es vuelto a ser puesto en "offset"-
         lo cual dejara la camara estatica en ese ultimo punto sin importar cuanto se mueva el mouse, hasta que el click derecho sea vuelto a pusar.
        */
        if(Input.GetMouseButton(1)){
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;
        }else{
            off = offset;
            offset = off;
        }
        
    }


}
