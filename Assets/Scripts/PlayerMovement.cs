using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    Animator animator;

    //public int jumpMaxCount = 3;
    //public int jumpAvaibleCount;
    public float runSpeed = 40f;

    public bool hareketEdebilir;

    float horizontalMove = 0f;

    bool jump = false;

    public float hareket;
    
    void Start()
    {
        //jumpAvaibleCount = jumpMaxCount;
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (hareketEdebilir)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("karakterHizi", Mathf.Abs(horizontalMove));
            if (Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
        if (!hareketEdebilir)
        {
            horizontalMove = 0f;
        }

        if (Input.GetButtonDown("Jump") && hareketEdebilir)
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove*runSpeed*Time.fixedDeltaTime,false,jump);
        hareket = horizontalMove * runSpeed * Time.fixedDeltaTime * 10;
        jump = false;
    }
}
