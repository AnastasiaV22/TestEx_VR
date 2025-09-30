using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UIController : MonoBehaviour
{

    [SerializeField] GameObject messageField;
    public ControllerButton activationButton;

    bool messageFieldIsActive = false;
    int messagesInQueue = 0;

    List<string> messages = new List<string>();

    /*
    
    private void AddNewMessageInQueue(Tips tip)
    {
        switch (tip)
        {
            case (Tips.Interaction):
                messages.Add("Нажмите любую клавишу");
                break;
            
            case (Tips.InteractionR):
                messages.Add($"Чтобы нажать на кнопку пульта управления, нажмите Trigger на правом контролере");
                break;

            case (Tips.InteractionL):
                messages.Add($"Нажмите Trigger на правом контролере");
                break;
        }
    }
    


    private void OpenMessageField()
    {
        messageFieldIsActive = true;
        messageField.SetActive(true);


    }

    private void ShowMessage()
    {
        if (!messageFieldIsActive)
        {
            OpenMessageField();
        }
        else
        {
            messagesInQueue++;


        }
    }

    private void CloseMessage()
    {
        if (messagesInQueue == 0)
        {
            CloseMessageField();
        }
        else
        {
            ShowMessage();
        }
    }

    private void CloseMessageField()
    {
        messageFieldIsActive = false;
        messageField.SetActive(false);
        messagesInQueue = 0;

    }

   
    if (ViveInput.GetAnyPress(HandRole.LeftHand, activationButton) || )

    public
   */
}
