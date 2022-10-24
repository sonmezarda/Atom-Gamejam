using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.Rendering;
public class AnahtarDurum : MonoBehaviour
{
    public bool acik;
    public Sprite acik_sprite, kapali_sprite;
    public GameObject kapi,openLight,closeLight,yazi;
    
    
    void Start()
    {
        Kapa();
    }
    public void Ac()
    {
        acik = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = acik_sprite;
        kapi.GetComponent<kapi>().olanSayi++;
        openLight.SetActive(true);
        closeLight.SetActive(false);
    }
    public void Kapa()
    {
        acik = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = kapali_sprite;
        kapi.GetComponent<kapi>().olanSayi--;

        openLight.SetActive(false);
        closeLight.SetActive(true);
        if (kapi.GetComponent<kapi>().olanSayi < 0)
        {
            kapi.GetComponent<kapi>().olanSayi = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            yazi.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            yazi.SetActive(false);
        }
    }
}
