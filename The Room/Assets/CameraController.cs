using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 0.2f;
    public float minPitch = -80f; // look down limit
    public float maxPitch = 80f;  // look up limit

    private float pitch = 0f; // up/down
    private float yaw = 0f;   // left/right

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor to screen
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 delta = Mouse.current.delta.ReadValue() * sensitivity;

        // Deadzone to prevent drift
        if (delta.magnitude < 0.01f) return;

        yaw += delta.x;
        pitch -= delta.y;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Apply rotation
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
