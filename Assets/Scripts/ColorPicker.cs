using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Device;
using UnityEngine.InputSystem.XR;
using System;

public class ColorPicker : MonoBehaviour
{ 
    public Color color;
    public Light lightParent;
    public Light lightHalo;
    public Material messageMaterial;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) { return; }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 5);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject == gameObject)
            {
                // print out coordinates
                color = getColorAtPoint(hit.point);
                lightParent.color = color; 
                lightHalo.color = color;
                
                messageMaterial.SetFloat("_RedMult", color.r);
                messageMaterial.SetFloat("_GreenMult", color.g);
                messageMaterial.SetFloat("_BlueMult", color.b);

            }
        }
    }

    private Color getColorAtPoint(Vector3 point)
    {
        float x = point.x - gameObject.transform.position.x;
        float y = point.y - gameObject.transform.position.y;
        float z = point.z - gameObject.transform.position.z;
        
        if (x <= 0.03f && x >= -0.03f) // for atan2 simplicity it will always be vertical and at a straight angle
        {
            x = z;
        }
        // normalize to 0..1
        x += 0.5f;
        y += 0.5f;
        // one minus in shader
        x = 1f - x;
        y = 1f - y;
        // subtract 0.5
        x -= 0.5f;
        y -= 0.5f;
        // atan2
        float hue = Mathf.Atan2(x, y);
        // add pi
        hue += Mathf.PI;
        // divide by 2PI
        float tau = Mathf.PI * 2;
        hue = hue / tau;
        Debug.Log("x: " + x + " | y: " + y + " | hue: " + hue);
        return Color.HSVToRGB(hue, 1, 1);
    }
}
