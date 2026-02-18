// using UnityEngine;
// using UnityEngine.InputSystem;

// public class LightSwitchColor : MonoBehaviour
// {
//     public Light targetLight;
//     public Key toggleKey = Key.Tab;

//     private Color originalColor;
//     private Color toggledColor = Color.red;
//     private bool isToggled = false;

//     void Start()
//     {
//         if (targetLight != null)
//         {
//             originalColor = targetLight.color;
//         }
//     }

//     void Update()
//     {
//         if (Keyboard.current == null) return;

//         if (Keyboard.current[toggleKey].wasPressedThisFrame && targetLight != null)
//         {
//             if (isToggled)
//             {
//                 targetLight.color = originalColor;
//             }
//             else
//             {
//                 targetLight.color = toggledColor;
//             }

//             isToggled = !isToggled;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitchColorVR : MonoBehaviour
{
    public Light targetLight;
    public InputActionReference toggleAction = null;  // assign your XR Input Action here

    private Color originalColor;
    private Color toggledColor = Color.red;
    private bool isToggled = false;

    void Start()
    {
        if (targetLight != null)
        {
            originalColor = targetLight.color;
        }

        if (toggleAction != null)
            toggleAction.action.Enable();
    }

    void OnEnable()
    {
        if (toggleAction != null)
            toggleAction.action.performed += OnTogglePressed;
    }

    void OnDisable()
    {
        if (toggleAction != null)
            toggleAction.action.performed -= OnTogglePressed;
    }

    private void OnTogglePressed(InputAction.CallbackContext context)
    {
        if (targetLight == null) return;

        if (isToggled)
        {
            targetLight.color = originalColor;
        }
        else
        {
            targetLight.color = toggledColor;
        }

        isToggled = !isToggled;
    }
}
