using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsCanvasScaler : MonoBehaviour
{ 
    private Transform playerCamera;
    private Transform canvasTransform;
    
    private float maxScale = 0.01f;
    private float minScale = 0.001f;

    private float maxVisibleDistance = 10f;

    void Start()
    {
        playerCamera = FindObjectOfType<Camera>().transform;
        canvasTransform = transform;
    }

    void Update()
    {
        if (playerCamera != null)
        {
            UpdateCanvasSize();
            UpdateRotation();
        }
    }
    
    private void UpdateCanvasSize()
    {
        float distance = Mathf.Clamp(Vector3.Distance(transform.position, playerCamera.position), 0, maxVisibleDistance);

        float scale = Mathf.Lerp(minScale, maxScale, distance / maxVisibleDistance);

        transform.localScale = Vector3.one * scale;
    }


    private void UpdateRotation()
    {
        Vector3 lookDirection =  transform.position - playerCamera.position ;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
 
}
