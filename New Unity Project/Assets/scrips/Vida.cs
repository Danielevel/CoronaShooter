using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
    public float valor = 100;
    public ScoreCount MyScoreCount;
    public GameObject ScoreContiner;
    public int SumaPunto = 1;

	// Use this for initialization
	void Start () {
		//MyScoreCount = GetComponent<ScoreCount>();
        ScoreContiner = GameObject.FindWithTag("Numbers");
        MyScoreCount = ScoreContiner.GetComponent<ScoreCount>();
        //ScoreContiner.GetComponent<MyScoreCount>();
	}
	
	// Update is called once per frame
	void Update () {
		if( valor == 0){
            gameObject.SetActive(false);
            //MyScoreCount = GetComponent<ScoreCount>();
            //MyScoreCount = GameObject.Find("Canvas/ScoreText").GetComponent("ScoreCount");
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
            MyScoreCount.Points++;
            valor = 0;
        }

    }

}
