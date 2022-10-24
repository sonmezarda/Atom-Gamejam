using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce;
    bool miknatisAcik = false;

    public GameObject magnetLight1, magnetParticle;

    PointEffector2D mEffector;
    void Start()
    {
        mEffector = gameObject.GetComponent<PointEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            miknatisAcik = true;
            mEffector.forceMagnitude = -magnetForce;
            magnetLight1.SetActive(true);
            magnetParticle.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            miknatisAcik = false;
            mEffector.forceMagnitude = 0;
            magnetLight1.SetActive(false);
            magnetParticle.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            miknatisAcik = true;
            mEffector.forceMagnitude = magnetForce;
            magnetLight1.SetActive(true);
            magnetParticle.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            miknatisAcik = false;
            mEffector.forceMagnitude = 0;
            magnetLight1.SetActive(false);
            magnetParticle.SetActive(false);
        }
    }
}
