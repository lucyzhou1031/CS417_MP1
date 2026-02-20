using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GateUnlock : MonoBehaviour
{
    [Header("References")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public EscapeManager manager;
    public GameObject correctKey;

    [Header("Behavior")]
    public GameObject doorObjectToHide;

    private bool solved = false;

    void Reset()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    void OnEnable()
    {
        if (socket == null) socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        if (socket != null) socket.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDisable()
    {
        if (socket != null) socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (solved) return;

        var insertedObj = args.interactableObject.transform.gameObject;

        if (insertedObj == correctKey)
        {
            solved = true;

            if (doorObjectToHide != null) doorObjectToHide.SetActive(false);
            else gameObject.SetActive(false);

            if (manager != null) manager.RegisterDoorUnlocked();

            // insertedObj.GetComponent<Rigidbody>()?.Sleep();
        }
    }
}
