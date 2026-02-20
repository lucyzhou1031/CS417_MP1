using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light light;
    public InputActionReference changeColorAction;
    void Start()
    {
        light = GetComponent<Light>();
        changeColorAction.action.Enable();
        changeColorAction.action.performed += OnChangeColor;
    }
    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            RandomizeColor();
        }
    }
    void OnDestroy()
    {
        changeColorAction.action.performed -= OnChangeColor;
        changeColorAction.action.Disable();
    }

    void OnChangeColor(InputAction.CallbackContext ctx)
    {
        RandomizeColor();
    }

    void RandomizeColor()
    {
        light.color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.7f, 1f);
    }
}