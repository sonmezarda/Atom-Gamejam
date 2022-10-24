using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Sprite[] resimler;
    public string[] yazilar;
    public Text metin;
    public Image resim;
    public bool resimlerEkraninda;

    public GameObject sonYazi;

    public int resimSira;
    void Start()
    {
        
    }

    void Update()
    {
        if (resimlerEkraninda)
        {
            if (Input.GetMouseButtonDown(0))
            {
                resimSira++;
                ResimGoster(resimSira);
            }
            if (Input.GetMouseButtonDown(1))
            {
                resimSira--;
                ResimGoster(resimSira);
            }
        }
        
    }
    public void SahneYukle(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi);
    }
    public void ResimGoster(int x)
    {
        if (x <= 0)
        {
            resimSira = 0;
        }
        /*if(x > resimler.Length-1)
        {
            resimSira = resimler.Length - 1;
        }*/
        if (resimSira == 4)
        {
            resim.sprite = resimler[resimSira];
            metin.text = yazilar[resimSira];
            sonYazi.SetActive(true);
        }
        else if(resimSira == 5)
        {
            SceneManager.LoadScene("LevelSelect");
        }
        else if(resimSira<6 && resimSira>=0)
        {
            resim.sprite = resimler[resimSira];
            metin.text = yazilar[resimSira];
            sonYazi.SetActive(false);
        }
        

    }
    public void Cikis()
    {
        Application.Quit();
    }
}
