using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;
    [Range (0, 5)] public float VelocityValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.LookAt(target);
          transform.Translate(Vector3.forward*VelocityValue*Time.deltaTime);
    }
}
