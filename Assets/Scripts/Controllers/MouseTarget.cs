using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private GameObject crosshair;
    
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector3 screenMousePosition = Input.mousePosition;
        
        Ray ray = camera.ScreenPointToRay(screenMousePosition);
        if (Physics.Raycast(ray,out RaycastHit raycastHit,999f,aimColliderLayerMask))
        {
            crosshair.transform.position = screenMousePosition;
            mouseWorldPosition = raycastHit.point;
        }
    
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 10f);
    }   
}
