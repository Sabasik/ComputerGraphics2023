using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTest : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 2f;
    public float moveSpeed = 2f;
    public float colorChangeSpeed = 1f;
    public Light haloLight;

    private float timeCounter = 0f;
    private float angle = 0f;

    void Update()
    {
        // Circular motion
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float z = centerPoint.position.z + radius * Mathf.Sin(angle);

        // Update light position
        transform.position = new Vector3(x, transform.position.y, z);

        // Smoothly change light color through RGB spectrum
        //float hue = Mathf.PingPong(timeCounter * colorChangeSpeed, 1f);
        //Color newColor = Color.HSVToRGB(hue, 1f, 1f);

        //GetComponent<Light>().color = newColor;
        //haloLight.color = newColor;

        // Increment time counter for animation
        timeCounter += Time.deltaTime;

        angle += moveSpeed * Time.deltaTime;
        angle = Mathf.Repeat(angle, 2 * Mathf.PI);
    }
}
