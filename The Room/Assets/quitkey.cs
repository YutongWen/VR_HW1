using UnityEngine;
using UnityEngine.InputSystem;

public class quitkey : MonoBehaviour
{
    public Key quitKey = Key.Escape;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current[quitKey].wasPressedThisFrame)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}