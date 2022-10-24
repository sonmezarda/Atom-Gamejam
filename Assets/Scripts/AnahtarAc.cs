using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnahtarAc : MonoBehaviour
{
    [SerializeField] bool anahtarYaninda;
    public GameObject anahtar;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && anahtarYaninda && anahtar != null)
        {
            if (!anahtar.GetComponent<AnahtarDurum>().acik)
            {
                anahtar.GetComponent<AnahtarDurum>().Ac();
            }
            else
            {
                anahtar.GetComponent<AnahtarDurum>().Kapa();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Anahtar")
        {
            anahtarYaninda = true;
            anahtar = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Anahtar")
        {
            anahtarYaninda = false;
            anahtar = null;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Anahtar")
        {
            anahtarYaninda = true;
            anahtar = other.gameObject;
        }
    }
}
