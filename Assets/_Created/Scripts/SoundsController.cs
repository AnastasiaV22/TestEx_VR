using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{


    private SoundsController() { }
    private static SoundsController instanse;

    public static SoundsController GetInstance()
    {
        if (instanse == null)
            instanse = new SoundsController();
        return instanse;
    }
    private void Awake()
    {
        instanse = this;
    }

    [SerializeField] private AudioSource hookAudioSource;
    [SerializeField] private AudioSource beamholderAudioSource;
    [SerializeField] private AudioSource craneAudioSource;

    [SerializeField] AudioClip movingHookSound;
    [SerializeField] AudioClip movingBeamholderSound;
    [SerializeField] AudioClip movingCraneSound;

    [SerializeField, Range(0,1)] float volume = 0.5f;

    private void Start()
    {

        SetAudioSourseSettings(craneAudioSource, movingCraneSound);
        SetAudioSourseSettings(hookAudioSource, movingHookSound);
        SetAudioSourseSettings(beamholderAudioSource, movingBeamholderSound);

    }

    private void SetAudioSourseSettings(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
    }

    public void PlaySound(CraneActionType actionType)
    {
        AudioSource targetSource = GetAudioSourceForAction(actionType);

        if (targetSource != null && !targetSource.isPlaying)
        {
            targetSource.Play();
        }
    }

    public void StopSound(CraneActionType actionType)
    {
        AudioSource targetSource = GetAudioSourceForAction(actionType);

        if (targetSource != null && targetSource.isPlaying)
        {
            targetSource.Stop();
        }
    }

    private AudioSource GetAudioSourceForAction(CraneActionType actionType)
    {
        switch (actionType)
        {
            case CraneActionType.MovementUp:
            case CraneActionType.MovementDown:
                return hookAudioSource;

            case CraneActionType.MovementNorth:
            case CraneActionType.MovementSouth:
                return beamholderAudioSource;

            case CraneActionType.MovementEast:
            case CraneActionType.MovementWest:
                return craneAudioSource;

            default:
                return null;
        }
    }

}
