using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform LookAt;
    public float Distance;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Update()
    {
        currentY = Mathf.Clamp(currentY + Input.GetAxis("Mouse Y"), 1, 70);
        currentX += Input.GetAxis("Mouse X");

    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Distance); //set distance between LookAt and camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = LookAt.position + rotation * dir; //rotate camera around player
        transform.LookAt(LookAt); //camera face player
        LookAt.transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); //rotate player
    }

}
