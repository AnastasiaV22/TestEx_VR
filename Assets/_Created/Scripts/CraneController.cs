using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraneController : MonoBehaviour
{
    [SerializeField] public Transform beamHolder; // Мост 
    [SerializeField] public Transform Crane; // Кран
    [SerializeField] public Transform hook; // Крюк 

    [SerializeField] public Transform spool; // Катушка

    [SerializeField, Range(1, 3)] public float LiftSpeed = 1.0f;
    [SerializeField, Range(1, 3)] public float ForwardSpeed = 1.0f;
    [SerializeField, Range(1, 3)] public float StrafeSpeed = 1.0f;

    // z
    private float minBeamDistance = 3f;
    private float maxBeamDistance = 20f;
    
    // x
    private float minCraneDistance = -40f;
    private float maxCraneDistance = 40f;

    // y
    private float minHeight = -6f;
    private float maxHeight = -1f;

    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private bool isMovingNorth = false;
    private bool isMovingSouth = false;
    private bool isMovingEast = false;
    private bool isMovingWest = false;

    public UnityEvent<CraneActionType> ObjectStartMoving;
    public UnityEvent<CraneActionType> ObjectEndMoving;

    SoundsController _SoundsController;

    private void Start()
    {
        _SoundsController = SoundsController.GetInstance();

        CraneButtonEvent[] buttonEvents = FindObjectsOfType<CraneButtonEvent>();

        foreach (var buttonEvent in buttonEvents)
        {
            buttonEvent.OnCraneAction.AddListener(ChangeCraneActionState); // Нажатия кнопок пульта
        }

        ObjectStartMoving.AddListener(_SoundsController.PlaySound); // вызов звука начала
        ObjectEndMoving.AddListener(_SoundsController.StopSound); // остановка звука

    }

    private void Update()
    {
        CraneMoving();
    }

    private void ChangeCraneActionState(CraneActionType actionType, bool isActive)
    {
        switch (actionType)
        {
            case CraneActionType.MovementUp:
                isMovingUp = isActive;
                break;
            
            case CraneActionType.MovementDown:
                isMovingDown = isActive;
                break;

            case CraneActionType.MovementEast:
                isMovingEast = isActive;
                break;

            case CraneActionType.MovementWest:
                isMovingWest = isActive;
                break;

            case CraneActionType.MovementNorth:
                isMovingNorth = isActive;
                break;

            case CraneActionType.MovementSouth:
                isMovingSouth = isActive;
                break;
            
        }

        if (isActive)
        {
            ObjectStartMoving.Invoke(actionType);
        }
        else
        {
            ObjectEndMoving.Invoke(actionType);
        }
    }




    private void CraneMoving()
    {
        if (isMovingUp)
        {
            Vector3 newPosition = hook.localPosition + Vector3.up * LiftSpeed * Time.deltaTime;
            spool.transform.Rotate(Vector3.right * 360 * LiftSpeed * Time.deltaTime);

            if (newPosition.y >= maxHeight)
            {
                newPosition.y = maxHeight;
                ChangeCraneActionState(CraneActionType.MovementUp, false);
            }

            hook.localPosition = newPosition;
        }
        if (isMovingDown)
        {
            Vector3 newPosition = hook.localPosition + Vector3.down * LiftSpeed * Time.deltaTime;
            spool.transform.Rotate(Vector3.left * 360 * LiftSpeed * Time.deltaTime);

            if (newPosition.y <= minHeight)
            {
                newPosition.y = minHeight;
                ChangeCraneActionState(CraneActionType.MovementDown, false);
            }

            hook.localPosition = newPosition;
        }

        if (isMovingEast)
        {
            Vector3 newPosition = Crane.localPosition + Vector3.right * StrafeSpeed * Time.deltaTime;

            if (newPosition.x >= maxCraneDistance)
            {
                newPosition.x = maxCraneDistance;
                ChangeCraneActionState(CraneActionType.MovementEast, false);
            }

            Crane.localPosition = newPosition;
        }
        if (isMovingWest)
        {
            Vector3 newPosition = Crane.localPosition + Vector3.left * StrafeSpeed * Time.deltaTime;

            if (newPosition.x <= minCraneDistance)
            {
                newPosition.x = minCraneDistance;
                ChangeCraneActionState(CraneActionType.MovementWest, false);
            }

            Crane.localPosition = newPosition;
        }

        if (isMovingNorth)
        {
            Vector3 newPosition = beamHolder.localPosition + Vector3.forward * ForwardSpeed * Time.deltaTime;

            if (newPosition.z >= maxBeamDistance)
            {
                newPosition.z = maxBeamDistance;
                ChangeCraneActionState(CraneActionType.MovementNorth, false);
            }

            beamHolder.localPosition = newPosition;
        }
        if (isMovingSouth)
        {
            Vector3 newPosition = beamHolder.localPosition + Vector3.back * ForwardSpeed * Time.deltaTime;

            if (newPosition.z <= minBeamDistance)
            {
                newPosition.z = minBeamDistance;
                ChangeCraneActionState(CraneActionType.MovementSouth, false);
            }

            beamHolder.localPosition = newPosition;
        }
    }



}
