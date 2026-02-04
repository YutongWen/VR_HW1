using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitchColor : MonoBehaviour
{
    public Light targetLight;
    public Key toggleKey = Key.Tab;

    private Color originalColor;
    private Color toggledColor = Color.red;
    private bool isToggled = false;

    void Start()
    {
        if (targetLight != null)
        {
            originalColor = targetLight.color;
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current[toggleKey].wasPressedThisFrame && targetLight != null)
        {
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
}
