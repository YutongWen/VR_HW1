using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private string escapeRoomSceneName = "SampleScene"; // name of your escape room scene

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(escapeRoomSceneName);
    }
}
