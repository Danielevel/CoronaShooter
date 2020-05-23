using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Main_Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
