using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handfollowCursor : MonoBehaviour
{
    void Update()
    {
        LookToMouse();   
    }
    void LookToMouse()
    { 
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
            );

        transform.up = direction;
    }
}
