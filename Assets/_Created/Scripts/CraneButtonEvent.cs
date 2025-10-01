using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.Events;


public enum CraneActionType
{
    MovementUp, 
    MovementDown,
    MovementNorth,
    MovementSouth,
    MovementEast,
    MovementWest,
    None
}

public class CraneActionEvent : UnityEvent<CraneActionType, bool> { }

public class CraneButtonEvent : MonoBehaviour
{
    [SerializeField] public CraneActionType actionType = CraneActionType.None;
    private bool isPressed = false;
    
    public ControllerButton activationButton;
    public Transform buttonObject;
    private Vector3 defaultPosition;

    public HandRole handRole;

    public CraneActionEvent OnCraneAction = new CraneActionEvent();

    private bool isTouched = false;

    private void Start()
    {
        defaultPosition = buttonObject.localPosition;
    }

    private void Update()
    {
        ProcessingButtonInput();
    }

    void ProcessingButtonInput()
    {
        if (ViveInput.GetPressDown(handRole, activationButton) && !isPressed && isTouched)
        {
            Debug.Log($"pressed {actionType} button");
            isPressed = true;
            buttonObject.localPosition = new Vector3(defaultPosition.x, defaultPosition.y, defaultPosition.z - 0.003f);
            OnCraneAction?.Invoke(actionType, true);
        }

        if ((ViveInput.GetPressUp(handRole, activationButton) || !isTouched)  && isPressed )
        {
            Debug.Log($"released {actionType} button");
            isPressed = false;
            buttonObject.localPosition = defaultPosition;
            OnCraneAction?.Invoke(actionType, false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            isTouched = false;
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            isTouched = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            isTouched = false;
        }
    }

    */
}
