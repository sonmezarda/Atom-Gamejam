using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeTut : MonoBehaviour
{
    public float maxUzaklik;
    bool elde = false;
    GameObject elObj,karakter;

    public GameObject isinlayici,magnet;

    int layerMask;

    private void Start()
    {
        karakter = GameObject.FindGameObjectWithTag("Player");
        layerMask = ~(LayerMask.GetMask("NhitRay"));


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !elde)
        {
            

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, maxUzaklik,layerMask);

            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.tag);
            }
            if (hit.collider != null && hit.collider.tag == "Tasinabilir" && Vector2.Distance(gameObject.transform.position,hit.collider.transform.position) <= maxUzaklik)
            {
                Debug.Log(hit.collider.gameObject.name);
                elde = true;
                elObj = hit.collider.gameObject;

                elObj.GetComponent<Collider2D>().isTrigger = true;
                elObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }

            if(hit.collider != null && Vector2.Distance(gameObject.transform.position,hit.collider.transform.position) <= maxUzaklik)
            {
                if(hit.collider.tag == "Isinlayici")
                {
                    Destroy(hit.collider.gameObject);
                    isinlayici.SetActive(true);
                    gameObject.GetComponent<TeleporterThrow>().enabled = true;
                    
                }
                if(hit.collider.tag == "Magnet")
                {
                    Destroy(hit.collider.gameObject);
                    magnet.SetActive(true);
                    gameObject.transform.GetChild(0).GetComponent<Magnet>().enabled = true;
                }

                
            }
        }
        else if(Input.GetKeyDown(KeyCode.R) && elde){
            elde = false;
            
            elObj.GetComponent<Collider2D>().isTrigger = false;
            elObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            elObj = null;
        }
        
        
        if(elObj != null && elde)
        {
            
            EleAl(elObj);
        }

        karakter.GetComponent<karakterOzellikler>().eliDolu = elde;
    }

    void EleAl(GameObject alinanObj)
    {
        alinanObj.transform.position = gameObject.transform.position;
    }

}