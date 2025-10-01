using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerZoneEvent : UnityEvent { }

public class ZoneTrigger : MonoBehaviour
{
    public TriggerZoneEvent OnTriggerZoneEnter = new TriggerZoneEvent();
    public TriggerZoneEvent OnTriggerZoneExit = new TriggerZoneEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            OnTriggerZoneEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hands"))
        {
            OnTriggerZoneExit?.Invoke();
        }
    }

}
