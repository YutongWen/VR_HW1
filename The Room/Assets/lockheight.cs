using UnityEngine;

public class LockCameraHeightVR : MonoBehaviour
{
    public float fixedHeight = 1.6f; // desired human eye height
    private Transform cameraOffset;

    void Start()
    {
        cameraOffset = transform.Find("Camera Offset");
        if (cameraOffset != null)
        {
            Vector3 pos = cameraOffset.position;
            pos.y = fixedHeight;
            cameraOffset.position = pos;
        }
    }

    void LateUpdate()
    {
        if (cameraOffset != null)
        {
            Vector3 pos = cameraOffset.position;
            pos.y = fixedHeight;  // lock Y every frame
            cameraOffset.position = pos;
        }
    }
}
