using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    private const float Y_angle_min = 0f;
    private const float Y_angle_max = 85f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 3f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sensitivityX = 5f;
    private float sensitivityY = 5f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_angle_min, Y_angle_max);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}

