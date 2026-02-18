// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class EscapeRoomWinManager : MonoBehaviour
// {
//     [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets; // assign 3 sockets
//     [SerializeField] private GameObject winMessage;       // assign "You Win" text/panel
//     private bool hasWon = false;

//     void Start()
//     {
//         if (winMessage != null)
//             winMessage.SetActive(false);

//         // subscribe with correct delegate types
//         foreach (var socket in sockets)
//         {
//             socket.selectEntered.AddListener(OnSocketSelected); // SelectEnterEventArgs
//             socket.selectExited.AddListener(OnSocketDeselected); // SelectExitEventArgs
//         }
//     }

//     // Called when an object is placed into a socket
//     private void OnSocketSelected(SelectEnterEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     // Called when an object is removed from a socket
//     private void OnSocketDeselected(SelectExitEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     private void CheckWinCondition()
//     {
//         if (hasWon) return; // only trigger once

//         foreach (var socket in sockets)
//         {
//             if (socket.firstInteractableSelected == null)
//             {
//                 return; // at least one socket empty → no win
//             }
//         }

//         // All sockets have objects → win
//         hasWon = true;

//         if (winMessage != null)
//             winMessage.SetActive(true);

//         Debug.Log("You Win!");
//     }
// }
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
// using UnityEngine.SceneManagement;
// using System.Collections;

// public class EscapeRoomWinManager : MonoBehaviour
// {
//     [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets; // assign 3 sockets
//     [SerializeField] private GameObject winMessage;       // assign "You Win" text/panel
//     [SerializeField] private string startSceneName = "StartScreen"; // name of start scene
//     [SerializeField] private float returnDelay = 5f;      // seconds to wait before returning

//     private bool hasWon = false;

//     void Start()
//     {
//         if (winMessage != null)
//             winMessage.SetActive(false);

//         foreach (var socket in sockets)
//         {
//             socket.selectEntered.AddListener(OnSocketSelected);
//             socket.selectExited.AddListener(OnSocketDeselected);
//         }
//     }

//     private void OnSocketSelected(SelectEnterEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     private void OnSocketDeselected(SelectExitEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     private void CheckWinCondition()
//     {
//         if (hasWon) return;

//         foreach (var socket in sockets)
//         {
//             if (socket.firstInteractableSelected == null)
//             {
//                 return; // at least one socket empty → no win
//             }
//         }

//         // All sockets have objects → win
//         hasWon = true;

//         if (winMessage != null)
//             winMessage.SetActive(true);

//         Debug.Log("You Win!");

//         // Start coroutine to go back to Start Screen after delay
//         StartCoroutine(ReturnToStartSceneAfterDelay());
//     }

//     private IEnumerator ReturnToStartSceneAfterDelay()
//     {
//         yield return new WaitForSeconds(returnDelay);

//         SceneManager.LoadScene(startSceneName);
//     }
// }
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI; // for UI Text
// using System.Collections;
// using TMPro;

// public class EscapeRoomWinManager : MonoBehaviour
// {
//     [Header("Sockets & Win")]
//     [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets; 
//     [SerializeField] private GameObject winMessage;       
//     [SerializeField] private float returnDelay = 5f;      
//     [SerializeField] private string startSceneName = "StartScreen"; 

//     [Header("Timer & Lose")]
//     [SerializeField] private float timeLimit = 60f;      // 1 minute
//     [SerializeField] private TMP_Text timerText;             // assign a UI Text in scene
//     [SerializeField] private GameObject loseMessage;     // assign "You Lose" panel/text

//     private bool hasWon = false;
//     private bool hasLost = false;
//     private float currentTime;

//     void Start()
//     {
//         // Setup messages
//         if (winMessage != null) winMessage.SetActive(false);
//         if (loseMessage != null) loseMessage.SetActive(false);

//         // Setup sockets
//         foreach (var socket in sockets)
//         {
//             socket.selectEntered.AddListener(OnSocketChanged);
//             socket.selectExited.AddListener(OnSocketChanged);
//         }

//         // Initialize timer
//         currentTime = timeLimit;
//         UpdateTimerUI();
//     }

//     void Update()
//     {
//         if (hasWon || hasLost) return;

//         // Countdown timer
//         currentTime -= Time.deltaTime;
//         UpdateTimerUI();

//         if (currentTime <= 0f)
//         {
//             currentTime = 0f;
//             TriggerLose();
//         }
//     }

//     private void UpdateTimerUI()
//     {
//         if (timerText != null)
//             timerText.text = $"Time: {Mathf.CeilToInt(currentTime)}s";
//     }

//     private void OnSocketChanged(SelectEnterEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     private void OnSocketChanged(SelectExitEventArgs args)
//     {
//         CheckWinCondition();
//     }

//     private void CheckWinCondition()
//     {
//         if (hasWon || hasLost) return;

//         foreach (var socket in sockets)
//         {
//             if (socket.firstInteractableSelected == null)
//                 return; // at least one socket empty
//         }

//         // All sockets filled → win
//         hasWon = true;
//         if (winMessage != null) winMessage.SetActive(true);
//         Debug.Log("You Win!");

//         StartCoroutine(ReturnToStartSceneAfterDelay());
//     }

//     private void TriggerLose()
//     {
//         if (hasWon || hasLost) return;

//         hasLost = true;
//         if (loseMessage != null) loseMessage.SetActive(true);
//         Debug.Log("You Lose!");

//         StartCoroutine(ReturnToStartSceneAfterDelay());
//     }

//     private IEnumerator ReturnToStartSceneAfterDelay()
//     {
//         yield return new WaitForSeconds(returnDelay);
//         SceneManager.LoadScene(startSceneName);
//     }
// }
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using TMPro; // for TextMeshPro
using System.Collections;

public class EscapeRoomGameManager : MonoBehaviour
{
    [Header("Sockets & Win")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets; 
    [SerializeField] private GameObject winMessage;       
    [SerializeField] private float returnDelay = 5f;      
    [SerializeField] private string startSceneName = "StartScreen"; 

    [Header("Timer & Lose")]
    [SerializeField] private float timeLimit = 60f;      
    [SerializeField] private TMP_Text timerText;       
    [SerializeField] private GameObject loseMessage;     

    [Header("Progress UI")]
    [SerializeField] private TMP_Text progressText;   // NEW

    private bool hasWon = false;
    private bool hasLost = false;
    private float currentTime;

    void Start()
    {
        if (winMessage != null) winMessage.SetActive(false);
        if (loseMessage != null) loseMessage.SetActive(false);

        foreach (var socket in sockets)
        {
            socket.selectEntered.AddListener(OnSocketChanged);
            socket.selectExited.AddListener(OnSocketChanged);
        }

        currentTime = timeLimit;
        UpdateTimerUI();
        UpdateProgressUI(); // update at start
    }

    void Update()
    {
        if (hasWon || hasLost) return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            TriggerLose();
        }
    }

    private void OnSocketChanged(SelectEnterEventArgs args)
    {
        CheckWinCondition();
    }

    private void OnSocketChanged(SelectExitEventArgs args)
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (hasWon || hasLost) return;

        UpdateProgressUI(); // update progress every time

        foreach (var socket in sockets)
        {
            if (socket.firstInteractableSelected == null)
                return; // at least one socket empty
        }

        // All sockets filled → win
        hasWon = true;
        if (winMessage != null) winMessage.SetActive(true);
        Debug.Log("You Win!");

        StartCoroutine(ReturnToStartSceneAfterDelay());
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = $"Time: {Mathf.CeilToInt(currentTime)}s";
    }

    private void UpdateProgressUI()
    {
        if (progressText != null)
        {
            int count = 0;
            foreach (var socket in sockets)
            {
                if (socket.firstInteractableSelected != null)
                    count++;
            }

            progressText.text = $"Clues placed: {count} / {sockets.Length}";
        }
    }

    private void TriggerLose()
    {
        if (hasWon || hasLost) return;

        hasLost = true;
        if (loseMessage != null) loseMessage.SetActive(true);
        Debug.Log("You Lose!");

        StartCoroutine(ReturnToStartSceneAfterDelay());
    }

    private IEnumerator ReturnToStartSceneAfterDelay()
    {
        yield return new WaitForSeconds(returnDelay);
        SceneManager.LoadScene(startSceneName);
    }
}
