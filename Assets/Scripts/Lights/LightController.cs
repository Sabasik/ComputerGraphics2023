using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public Light lightMain;
    public Light lightHalo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRedMultiplier(float redMultiplier)
    {
        Color color = lightMain.color;
        color.r = redMultiplier;
        lightMain.color = color;
        lightHalo.color = color;
    }

    public void UpdateGreenMultiplier(float greenMultiplier)
    {
        Color color = lightMain.color;
        color.g = greenMultiplier;
        lightMain.color = color;
        lightHalo.color = color;
    }

    public void UpdateBlueMultiplier(float blueMultiplier)
    {
        Color color = lightMain.color;
        color.b = blueMultiplier;
        lightMain.color = color;
        lightHalo.color = color;
    }
}
