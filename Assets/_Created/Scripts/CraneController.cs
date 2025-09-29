using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    [SerializeField] public Transform beamHolder; // мост 
    [SerializeField] public Transform Crane; // Кран
    [SerializeField] public Transform hook; //крюк с катушкой

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


    private void Start()
    {
        CraneButtonEvent[] buttonEvents = FindObjectsOfType<CraneButtonEvent>();

        foreach (var buttonEvent in buttonEvents)
        {
            buttonEvent.OnCraneAction.AddListener(ChangeCraneActionState);
        }
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
    }

    private void CraneMoving()
    {
        if (isMovingUp)
        {
            Vector3 newPosition = hook.localPosition + Vector3.up * LiftSpeed * Time.deltaTime;

            if (newPosition.y >= maxHeight)
            {
                newPosition.y = maxHeight;
                isMovingUp = false;
            }

            hook.localPosition = newPosition;
        }
        if (isMovingDown)
        {
            Vector3 newPosition = hook.localPosition + Vector3.down * LiftSpeed * Time.deltaTime;

            if (newPosition.y <= minHeight)
            {
                newPosition.y = minHeight;
                isMovingDown = false;
            }

            hook.localPosition = newPosition;
        }

        if (isMovingEast)
        {
            Vector3 newPosition = Crane.localPosition + Vector3.right * StrafeSpeed * Time.deltaTime;

            if (newPosition.x >= maxCraneDistance)
            {
                newPosition.x = maxCraneDistance;
                isMovingEast = false;
            }

            Crane.localPosition = newPosition;
        }
        if (isMovingWest)
        {
            Vector3 newPosition = Crane.localPosition + Vector3.left * StrafeSpeed * Time.deltaTime;

            if (newPosition.x <= minCraneDistance)
            {
                newPosition.x = minCraneDistance;
                isMovingWest = false;
            }

            Crane.localPosition = newPosition;
        }

        if (isMovingNorth)
        {
            Vector3 newPosition = beamHolder.localPosition + Vector3.forward * ForwardSpeed * Time.deltaTime;

            if (newPosition.z >= maxBeamDistance)
            {
                newPosition.z = maxBeamDistance;
                isMovingNorth = false;
            }

            beamHolder.localPosition = newPosition;
        }
        if (isMovingSouth)
        {
            Vector3 newPosition = beamHolder.localPosition + Vector3.back * ForwardSpeed * Time.deltaTime;

            if (newPosition.z <= minBeamDistance)
            {
                newPosition.z = minBeamDistance;
                isMovingSouth = false;
            }

            beamHolder.localPosition = newPosition;
        }
    }

}
