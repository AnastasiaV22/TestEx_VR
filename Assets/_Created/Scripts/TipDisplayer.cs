using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TipDisplayer : MonoBehaviour
{

    GameObject messageField;
    public ControllerButton activationButton;

    bool messageShown = false;


    private void Start()
    {
        messageField = transform.gameObject;
        ZoneTrigger zoneTrigger = GetComponentInParent<ZoneTrigger>();
        if (zoneTrigger != null) 
        { 
            zoneTrigger.OnTriggerZoneEnter.AddListener(OpenMessageField);
            zoneTrigger.OnTriggerZoneExit.AddListener(CloseMessageField);
        }
    }

    private void OpenMessageField()
    {
        
        if (!messageShown && !messageField.activeSelf)
        {
            messageField.SetActive(true);
        }

    }

    private void CloseMessageField()
    {
        if (messageField.activeSelf)
        {
            messageField.SetActive(false);
        }

    }
    
    public void OnButtonClick()
    {
        CloseMessageField();
        messageShown = true;
    }


}
