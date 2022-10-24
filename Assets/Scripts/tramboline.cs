using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramboline : MonoBehaviour
{
    public float ziplaForce;
    float ilkGuc;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ilkGuc = collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce;
            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = ziplaForce;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = ilkGuc;
            
        }
    }
}
