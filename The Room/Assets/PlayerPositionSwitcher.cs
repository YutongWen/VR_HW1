using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPositionSwitcher : MonoBehaviour
{
    public Transform externalViewPoint;  // external viewing point
    public Key toggleKey = Key.Tab;      // key to switch positions

    private Vector3 originalPosition;    // room position
    private bool atExternal = false;     // current state

    void Start()
    {
        // Save the original starting position (inside the room)
        originalPosition = transform.position;

        if (externalViewPoint == null)
        {
            Debug.LogError("Assign an external view point Transform!");
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // Check if toggle key pressed this frame
        if (Keyboard.current[toggleKey].wasPressedThisFrame)
        {
            if (atExternal)
            {
                transform.position = originalPosition;  // move back to room
            }
            else
            {
                transform.position = externalViewPoint.position;  // move outside
            }

            atExternal = !atExternal;  // toggle state
        }
    }
}
