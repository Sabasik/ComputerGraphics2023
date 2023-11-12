using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    private Transform playerCamera;
    public Transform mirrorPlane;

    private Camera mirrorCamera;
    private RenderTexture mirrorTexture;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
        mirrorCamera = GetComponent<Camera>();

        if (mirrorTexture != null)
        {
            mirrorTexture.Release();
        }
        mirrorTexture = new RenderTexture(Screen.width, Screen.height, 0);
        mirrorCamera.targetTexture = mirrorTexture;
        MeshRenderer mirrorRenderer = mirrorPlane.GetComponent<MeshRenderer>();
        mirrorRenderer.material.SetTexture("_MainTex", mirrorTexture);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerCamPosRelativeToMirror = mirrorPlane.InverseTransformPoint(playerCamera.position);
        Vector3 mirroredPosRelativeToMirror = new Vector3(playerCamPosRelativeToMirror.x, -playerCamPosRelativeToMirror.y, playerCamPosRelativeToMirror.z);
        transform.position = mirrorPlane.TransformPoint(mirroredPosRelativeToMirror);

        Quaternion playerCamRotationRelativeToMirror = Quaternion.Inverse(mirrorPlane.rotation) * playerCamera.rotation;
        Vector3 relativeRotationEuler = playerCamRotationRelativeToMirror.eulerAngles;
        Vector3 relativeMirroredRotationEuler = new Vector3(-relativeRotationEuler.x, relativeRotationEuler.y, relativeRotationEuler.z);
        transform.rotation = mirrorPlane.rotation * Quaternion.Euler(relativeMirroredRotationEuler);
    }
}
