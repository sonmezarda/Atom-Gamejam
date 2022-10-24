using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterOzellikler : MonoBehaviour
{
    public bool eliDolu;
    public GameObject teleporter;
    public GameObject[] kapananlar;
    public GameObject[] spriteGidenler;

    
    public sesayar manager;
    Vector3 startPos;
    void Start()
    {
        startPos = gameObject.transform.position;
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<sesayar>();
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
    public void Ol()
    {
        foreach(GameObject x in kapananlar)
        {
            x.SetActive(false);
        }
        foreach (GameObject x in spriteGidenler)
        {
            x.GetComponent<SpriteRenderer>().enabled = false;
        }

        Time.timeScale = 0;
        gameObject.GetComponent<PlayerMovement>().hareketEdebilir = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        manager.AraMenuAcKapa();
    }
}
