using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSensitivity = 100.0f;

    public Transform playerTransform;

    float pitchAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       float mouseX =  Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
       float mouseY =  Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

       pitchAngle -= mouseY;
       pitchAngle = Mathf.Clamp(pitchAngle, -90.0f, 90.0f);

       transform.localRotation = Quaternion.Euler(pitchAngle, 0.0f, 0.0f);
       playerTransform.Rotate(Vector3.up * mouseX);
    }
}
