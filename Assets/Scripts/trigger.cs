using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject kapi,key;
    public Color acanColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == key)
        {
            kapi.GetComponent<kapi>().olanSayi++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == key)
        {
            kapi.GetComponent<kapi>().olanSayi--;
        }
    }
}
