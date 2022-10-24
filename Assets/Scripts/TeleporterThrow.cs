using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporterThrow : MonoBehaviour
{
    public GameObject teleportObj, format, sonAtilan, karakter, teleportParticle, sonParticle, mknat,olPart;

    public GameObject[] kapananlar;

    public Vector3 startPos;

    public float throwSpeed,teleportTime,waitTime,countDown;
    public float teleportStartTime,startCountDown;
    public bool atildi,isinlanmaBekleme,atabilir,atmaBekleme;

    public Image isinlanmaCubugu; 

    void Start()
    {
        format = GameObject.FindGameObjectWithTag("Format");
        karakter = GameObject.FindGameObjectWithTag("Player");
        teleportStartTime = teleportTime;
        startCountDown = countDown;
        startPos = karakter.transform.position;
        atabilir = true;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !atildi && !karakter.GetComponent<karakterOzellikler>().eliDolu && atabilir)
        {
            Quaternion mermiRotation = gameObject.transform.rotation;
            
            mermiRotation.eulerAngles = new Vector3(mermiRotation.eulerAngles.x, mermiRotation.eulerAngles.y, mermiRotation.eulerAngles.z);

            
            sonAtilan =  Instantiate(teleportObj, gameObject.transform.position,  mermiRotation, format.transform);

            gameObject.transform.parent.GetComponent<AudioSource>().Play();

            if(karakter.transform.localScale.x == 1)
            {
                sonAtilan.GetComponent<Rigidbody2D>().velocity = transform.right * throwSpeed;
            }else if(karakter.transform.localScale.x == -1)
            {
                sonAtilan.GetComponent<Rigidbody2D>().velocity = transform.right * -throwSpeed;
            }
            atildi = true;
            atabilir = false;
            //tObj.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.parent.transform.up);
        }

        if (atildi)
        {
            teleportTime -= Time.deltaTime;
        }
        if(atildi && teleportTime <= 0)
        {
            atildi = false;

            Vector3 sonAtilanPos = sonAtilan.transform.position;
            Destroy(sonAtilan);

            Teleport(sonAtilanPos);
            teleportTime = teleportStartTime;
            
        }
        if(atildi && Input.GetMouseButtonDown(1))
        {
            teleportTime = 0;
        }

        if (isinlanmaBekleme)
        {
            waitTime -= Time.deltaTime;
        }

        if(waitTime<= 0)
        {
            karakter.GetComponent<SpriteRenderer>().enabled = true;
            karakter.GetComponent<PlayerMovement>().hareketEdebilir = true;
            karakter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = true;

            atmaBekleme = true;

            if (gameObject.transform.GetChild(0).GetComponent<Magnet>().enabled == true)
            {
                mknat.SetActive(true);
            }

            foreach (var x in kapananlar)
            {
                x.SetActive(true);
            }

            //gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(sonParticle);
            isinlanmaBekleme = false;
            waitTime = 0.6f;
        }

        if (atmaBekleme)
        {
            countDown -= Time.deltaTime;
            isinlanmaCubugu.rectTransform.sizeDelta = new Vector2(300-countDown * 300, 75);
        }
        if(countDown<= 0)
        {
            atabilir = true;
            atmaBekleme = false;
            countDown = startCountDown;
        }
    }

    public void Teleport(Vector3 teleportPosition)
    { 
        karakter.transform.position = new Vector2(teleportPosition.x,teleportPosition.y+1);
        sonParticle = Instantiate(teleportParticle, new Vector2(teleportPosition.x,teleportPosition.y), Quaternion.identity);

        karakter.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = false;

        gameObject.GetComponent<AudioSource>().Play();

        foreach(var x in kapananlar)
        {
            x.SetActive(false);
        }

        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        karakter.GetComponent<PlayerMovement>().hareketEdebilir = false;
        karakter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // karakter.SetActive(false);
        isinlanmaBekleme = true;
    }
}
