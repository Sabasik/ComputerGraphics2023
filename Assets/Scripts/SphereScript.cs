using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereScript : MonoBehaviour
{
    public Transform playerCamera;
    public Material secret;
    public Material original;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0);
        if (Math.Abs(Math.Round(transform.rotation.y, 2)) < 0.2) {
            this.GetComponent<Renderer>().material = secret;
        } else {
            this.GetComponent<Renderer>().material = original;
        }
    }
}
