using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NewTipsEvent : UnityEvent<string> { }

public class TriggerZoneEvent : MonoBehaviour
{
    [SerializeField] private string ObjectType;
    public ControllerButton activationButton;
    public string message;

    public NewTipsEvent OnTriggerZoneInteraction = new NewTipsEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
        }
    }
    
}
