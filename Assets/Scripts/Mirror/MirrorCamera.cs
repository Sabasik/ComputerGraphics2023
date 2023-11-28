using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    private Transform playerCamTrans;
    public Transform mirrorPlane;

    private Transform mirrorOrigin;
    private Camera mirrorCamera;
    private Camera playerCamera;
    private RenderTexture mirrorTexture;

    // Start is called before the first frame update
    void Start()
    {
        mirrorOrigin = transform.parent;
        playerCamTrans = Camera.main.transform;
        mirrorCamera = GetComponent<Camera>();
        playerCamera = Camera.main;

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
        //SetNearClipPlane(); doesn't work currently

        Vector3 playerCamPosRelativeToMirror = mirrorOrigin.InverseTransformPoint(playerCamTrans.position);
        Vector3 mirroredPosRelativeToMirror = new Vector3(playerCamPosRelativeToMirror.x, playerCamPosRelativeToMirror.y, -playerCamPosRelativeToMirror.z);
        transform.position = mirrorOrigin.TransformPoint(mirroredPosRelativeToMirror);

        Quaternion playerCamRotationRelativeToMirror = Quaternion.Inverse(mirrorOrigin.rotation) * playerCamTrans.rotation;
        Vector3 relativeRotationEuler = playerCamRotationRelativeToMirror.eulerAngles;
        
        Vector3 relativeMirroredRotationEuler = new Vector3(relativeRotationEuler.x, 180 - relativeRotationEuler.y, relativeRotationEuler.z);
        transform.rotation = mirrorOrigin.rotation * Quaternion.Euler(relativeMirroredRotationEuler);
    }

    // Source: https://www.youtube.com/watch?v=cWpFZbjtSQg&t=138s
    void SetNearClipPlane()
    {
        int dot = System.Math.Sign (Vector3.Dot (mirrorPlane.forward, mirrorPlane.transform.position - transform.position));

        Vector3 camSpacePos = mirrorCamera.worldToCameraMatrix.MultiplyPoint(mirrorPlane.position);
        Vector3 camSpaceNormal = mirrorCamera.worldToCameraMatrix.MultiplyVector(mirrorPlane.forward) * dot;
        float camSpaceDst = -Vector3.Dot(camSpacePos, camSpaceNormal);
        Vector4 clipPlaneCameraSpace = new Vector4(camSpaceNormal.x, camSpaceNormal.y, camSpaceNormal.z, camSpaceDst);

        mirrorCamera.projectionMatrix = playerCamera.CalculateObliqueMatrix(clipPlaneCameraSpace);
    }
}
