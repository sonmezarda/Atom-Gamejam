using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigamecontroller : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public GameObject ilerlePanel;

    public GameObject startPos;
    public string sonrakiSahne;
    public float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
    public void SonrakiSahne()
    {
        SceneManager.LoadScene(sonrakiSahne);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Kenar")
        {
            gameObject.transform.position = startPos.transform.position;
        }
        if (collision.gameObject.tag == "Finish")
        {
            
            ilerlePanel.SetActive(true);
            speed = 0;
        }
    }
}
