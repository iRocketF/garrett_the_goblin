using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    public float forwardOffSet = 2f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;

        float inputMovement = Input.GetAxis("Horizontal");

        desiredPosition.x += forwardOffSet * inputMovement;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * (Time.deltaTime));
        transform.position = smoothedPosition;

        //transform.LookAt(target.position);
    }
}
