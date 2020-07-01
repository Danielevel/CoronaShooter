using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public float valor = 100;
    private float vidaTotal = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if( valor == 0){
            //gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        */
	}

    public void RecibirDaño(float daño)
    {
        valor -= daño;
        if(valor < 0)
        {
            valor = 0;
        }
    }
	void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.tag == "Enemy")
		{
            valor = valor-(vidaTotal/5);
        }

    }

}
