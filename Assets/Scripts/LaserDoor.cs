using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCol;
    public GameObject startPos,stopPos;
    // Start is called before the first frame update
    void Start()
    {
        //Vector2[] points = {startPos.transform.position, stopPos.transform.position};

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        edgeCol = gameObject.GetComponent<EdgeCollider2D>();

        lineRenderer.SetPosition(0, startPos.transform.position);
        lineRenderer.SetPosition(1, stopPos.transform.position);

        edgeCol.points[0] = startPos.transform.position;
        edgeCol.points[1] = stopPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
