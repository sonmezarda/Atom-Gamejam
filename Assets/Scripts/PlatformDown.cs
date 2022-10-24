using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    public float waitTime = 0.5f;
    bool ters;
    PlatformEffector2D effector;

    public GameObject ustundeObj,checker;
    void Start()
    {
        //effector = gameObject.GetComponent<PlatformEffector2D>();
    }
    void Update()
    {
        ustundeObj = checker.GetComponent<PlatformChecker>().ustundeObj;

        if (Input.GetKeyDown(KeyCode.S) && ustundeObj.tag == "OneWayPlatform")
        {
            ters = true;
            effector = ustundeObj.GetComponent<PlatformEffector2D>();
            effector.rotationalOffset = 180f;
        }

        if (ters && waitTime> 0)
        {
            waitTime -= Time.deltaTime;

        }else if(ters && waitTime<= 0)
        {
            ters = false;
            waitTime = 0.5f;
            effector.rotationalOffset = 0f;
        }
    }
}
