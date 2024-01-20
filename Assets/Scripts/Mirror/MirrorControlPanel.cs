using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPanel : MonoBehaviour
{
    public GameObject mirrorPlane;

    private Material mirrorMaterial;


    // Start is called before the first frame update
    void Start()
    {
        //mirrorMaterial = mirrorPlane.GetComponent<MeshRenderer>().material;
        mirrorMaterial = mirrorPlane.GetComponent<MeshRenderer>().materials[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRedMultiplier(float value)
    {
        mirrorMaterial.SetFloat("_RedMult", value);
    }

    public void UpdateGreenMultiplier(float value)
    {
        mirrorMaterial.SetFloat("_GreenMult", value);
    }

    public void UpdateBlueMultiplier(float value)
    {
        mirrorMaterial.SetFloat("_BlueMult", value);
    }
}
