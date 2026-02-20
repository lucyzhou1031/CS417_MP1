using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    public InputActionReference action;

    void Start()
    {
        action.action.Enable();
        action.action.performed += OnQuit;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            QuitGame();
        }
    }

    void OnDestroy()
    {
        action.action.performed -= OnQuit;
        action.action.Disable();
    }

    void OnQuit(InputAction.CallbackContext ctx)
    {
        QuitGame();
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}