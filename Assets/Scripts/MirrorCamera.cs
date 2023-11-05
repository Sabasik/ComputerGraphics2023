using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    public Transform mirrorPlane;
    public Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
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
