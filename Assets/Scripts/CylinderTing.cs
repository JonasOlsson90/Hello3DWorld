using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTing : MonoBehaviour
{

    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(1,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BallTing")
        {
            GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            isHit = true;
        }
    }
}
