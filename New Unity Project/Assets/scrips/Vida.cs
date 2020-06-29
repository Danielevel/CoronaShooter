using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
    public float valor = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( valor == 0){
            gameObject.SetActive(false);
        }
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
        if (collision.transform.tag == "Disparo")
		{
            valor = 0;
        }

    }

}
