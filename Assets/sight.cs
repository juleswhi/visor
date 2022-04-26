using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    private float mouseX, mouseY, xRotation;
    public float sensitivity;
    public Transform playerBody;
    

    // Start is called before the first frame update
    void Start()
    {
        sensitivity = 80;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
