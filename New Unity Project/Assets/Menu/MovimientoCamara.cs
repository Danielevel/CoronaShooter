using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    float mousePosX;
    float mousePosY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
          (mousePosX/Screen.width) * 40 + (Screen.width/2),
          (mousePosY/Screen.height) * 40 + (Screen.height/2));

    }
}