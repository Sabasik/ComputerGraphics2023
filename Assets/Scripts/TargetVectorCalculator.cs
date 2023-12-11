using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TargetVectorCalculator : MonoBehaviour
{
    public Transform target;

    private Material normalInterpolatorMaterial;

    // Start is called before the first frame update
    void Start()
    {
        normalInterpolatorMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = (target.position - transform.position).normalized;
        normalInterpolatorMaterial.SetVector("_TargetVector", targetVector);
    }
}
