using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public GameObject tarj;
    public Transform myTransform;
    //private bool VidaE;
    [Range (0, 5)] public float VelocityValue;
    // Start is called before the first frame update
    void Start()
    {
        tarj = GameObject.Find("Jugador/MainCamera");
        target = tarj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
          transform.LookAt(target);
          transform.Translate(Vector3.forward*VelocityValue*Time.deltaTime);

          //if(VidaE == false){
            //  myTransform = false;
          //}
    }
}
