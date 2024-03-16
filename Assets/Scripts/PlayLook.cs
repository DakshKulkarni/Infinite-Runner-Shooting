using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 12f;
    public float minX = -1200f;
    public float maxX = 120f;
    public float minY = -120f; 
    public float maxY = 120f; 
    private float rotationX = 0f;
    private float rotationY = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minX, maxX); 
        rotationY += mouseX;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
