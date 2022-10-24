using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffectorDuzenle : MonoBehaviour
{
    PlatformEffector2D effector;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
