using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private MeshRenderer mirrorRenderer;
    private Camera playerCamera;

    public GameObject mirrorCamera;
    private bool isMirrorCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        mirrorRenderer = GetComponent<MeshRenderer>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMirrorCameraActive && !VisibleFromCamera(mirrorRenderer, playerCamera))
        {
            isMirrorCameraActive = false;
            mirrorCamera.SetActive(false);
        } else if (!isMirrorCameraActive && VisibleFromCamera(mirrorRenderer, playerCamera))
        {
            isMirrorCameraActive = true;
            mirrorCamera.SetActive(true);
        }
    }

    static bool VisibleFromCamera(Renderer renderer, Camera camera)
    {
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, renderer.bounds);
    }
}
