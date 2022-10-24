using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HataBloguYakala : MonoBehaviour
{
    [SerializeField] bool blokYaninda = false;
    GameObject hataBlogu;
    void Start()
    {
        hataBlogu = GameObject.FindGameObjectWithTag("HataBlogu");
    }

    void Update()
    {
        if(blokYaninda && Input.GetKeyDown(KeyCode.F))
        {
            HataCoz();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HataBlogu")
        {
            blokYaninda = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "HataBlogu")
        {
            blokYaninda = false;
        }

    }
    void HataCoz() 
    {
        SceneManager.LoadScene(hataBlogu.GetComponent<HataBlogu>().nextScene);
    }

}
