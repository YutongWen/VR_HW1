using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private string startSceneName = "StartScreen";

    public void OnButtonPressed()
    {
        SceneManager.LoadScene(startSceneName);
    }
}
