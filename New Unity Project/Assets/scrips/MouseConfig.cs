using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        ClickDerecho();
    }
    void ClickDerecho()
    {
        if(Input.GetMouseButton(1)){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else{
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
