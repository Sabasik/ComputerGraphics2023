using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //public Vector3 rotation;
    public float rotatingSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotatingSpeed * Time.deltaTime, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
