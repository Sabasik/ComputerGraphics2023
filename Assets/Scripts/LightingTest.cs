using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTest : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 2f;
    public float moveSpeed = 2f;
    public float colorChangeSpeed = 1f;
    public Material lightMaterial;

    private float timeCounter = 0f;
    private float angle = 0f;

    void Start()
    {
        // reset to white
        lightMaterial.SetColor("_EmissionColor", Color.white);
    }

    void Update()
    {
        // Circular motion
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float z = centerPoint.position.z + radius * Mathf.Sin(angle);

        // Update light position
        transform.position = new Vector3(x, transform.position.y, z);

        timeCounter += Time.deltaTime;

        angle += moveSpeed * Time.deltaTime;
        angle = Mathf.Repeat(angle, 2 * Mathf.PI);
    }
}
