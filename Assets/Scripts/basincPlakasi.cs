using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basincPlakasi : MonoBehaviour
{
    public GameObject kapi;
    public float waitTime;
    float kalansure;
    bool kapaniyor,acik;

    void Update()
    {
        if (kapaniyor)
        {
            kalansure -= Time.deltaTime;
            if (kalansure <= 0)
            {
                kapi.GetComponent<kapi>().olanSayi--;
                kapaniyor = false;
                acik = false;
                kalansure = waitTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !acik)
        {
            kapi.GetComponent<kapi>().olanSayi++;
            acik = true;   
        }else if(collision.gameObject.tag == "Player" && acik)
        {
            kapaniyor = false;
            kalansure = waitTime;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kapaniyor = true;

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            kalansure = waitTime;
        }
    }
}
