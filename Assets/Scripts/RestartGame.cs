using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference restartAction;

    private void OnEnable()
    {
        if (restartAction != null)
        {
            restartAction.action.Enable();
            restartAction.action.performed += OnRestart;
        }
    }

    private void OnDisable()
    {
        if (restartAction != null)
        {
            restartAction.action.performed -= OnRestart;
            restartAction.action.Disable();
        }
    }

    private void OnRestart(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
