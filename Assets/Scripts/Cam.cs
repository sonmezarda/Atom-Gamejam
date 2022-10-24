using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    GameObject karakter;

    Animator camAnim;
    void Start()
    {
        karakter = GameObject.FindGameObjectWithTag("Player");
        camAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(karakter.transform.position.x, karakter.transform.position.y,-10);
        
    }
    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }
}
