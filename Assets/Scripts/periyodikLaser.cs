using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class periyodikLaser : MonoBehaviour
{
    kapi bukapi;

    public float startOffset, openTime, closeTime;
    float d_startOffset, d_openTime, d_closeTime;

    bool acik,baslangicGecti;
    void Start()
    {
        bukapi = gameObject.GetComponent<kapi>();

        d_startOffset = startOffset;
        d_closeTime = closeTime;
        d_openTime = openTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!baslangicGecti)
        {
            startOffset -= Time.deltaTime;
            if (startOffset <= 0)
            {
                bukapi.olanSayi = 0;
                baslangicGecti = true;
                acik = true;
            }
        }
        
        

        if(acik && baslangicGecti)
        {
            openTime -= Time.deltaTime;
            if (openTime <= 0)
            {
                acik = false;
                bukapi.olanSayi = 1;
                openTime = d_openTime;
                //closeTime = d_closeTime;
            }
        }
        if(!acik && baslangicGecti)
        {
            closeTime -= Time.deltaTime;
            if(closeTime <= 0)
            {
                acik = true;
                bukapi.olanSayi = 0;
                closeTime = d_closeTime;
                //openTime = d_openTime;
            }
            
        }

    }
}
