using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTest : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bobbingSpeed = 1f;
    public float bobbingAmount = 0.5f;
    public float colorChangeSpeed = 1f;

    private float timeCounter = 0f;

    void Update()
    {
        // Circular motion
        float x = Mathf.Cos(timeCounter) * moveSpeed;
        float z = Mathf.Sin(timeCounter) * moveSpeed;

        // Vertical oscillation (bobbing)
        float y = Mathf.Sin(timeCounter * bobbingSpeed) * bobbingAmount;

        // Update light position
        transform.position = new Vector3(x, y, z);

        // Smoothly change light color through RGB spectrum
        float hue = Mathf.PingPong(timeCounter * colorChangeSpeed, 1f);
        Color newColor = Color.HSVToRGB(hue, 1f, 1f);

        GetComponent<Light>().color = newColor;

        // Increment time counter for animation
        timeCounter += Time.deltaTime;
    }
}
