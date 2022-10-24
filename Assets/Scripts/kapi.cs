using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapi : MonoBehaviour
{
    public int gerekenSayi,olanSayi;
    public GameObject[] lights;

    TeleporterThrow teleporter;

    // Start is called before the first frame update
    void Start()
    {
        teleporter = GameObject.FindGameObjectWithTag("Hand").GetComponent<TeleporterThrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gerekenSayi == olanSayi)
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<LineRenderer>().enabled = false;
            foreach(var x in lights)
            {
                x.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<LineRenderer>().enabled = true;
            foreach (var x in lights)
            {
                x.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<karakterOzellikler>().Ol();
        }
        if(collision.gameObject.tag == "Isinlayici")
        {
            teleporter.atildi = false;

            teleporter.teleportTime = teleporter.teleportStartTime;
            teleporter.atmaBekleme = true;

            Destroy(collision.gameObject);
        }
    }
}
