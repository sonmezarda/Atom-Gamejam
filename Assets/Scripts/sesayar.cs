using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sesayar : MonoBehaviour
{
    public int sesAyar;
    GameObject karakter;
    public Image hoparlor_image;
    public Sprite sesAcik_sprite,sesKapali_sprite;
    public GameObject araMenu;
    bool menuAcik;
    void Start()
    {
        sesAyar = PlayerPrefs.GetInt("SesAyar");
        karakter = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(sesAyar == 1)
        {
            karakter.GetComponent<AudioSource>().volume = 1;
            hoparlor_image.sprite = sesAcik_sprite;
        }else if(sesAyar == 0)
        {
            karakter.GetComponent<AudioSource>().volume = 0;
            hoparlor_image.sprite = sesKapali_sprite;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AraMenuAcKapa();
        }
    }
    public void SesDegis()
    {
        if(sesAyar == 1) 
        { 
            sesAyar = 0; PlayerPrefs.SetInt("SesAyar", 1); 
        }
        else if(sesAyar == 0) 
        { 
            sesAyar = 1; PlayerPrefs.SetInt("SesAyar", 0); 
        }
    }
    public void SahneAc(string sahneIsim)
    {
        SceneManager.LoadScene(sahneIsim);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void AraMenuAcKapa()
    {
        if(menuAcik)
        {
            menuAcik = false;
            araMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            menuAcik = true;
            araMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
