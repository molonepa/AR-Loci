using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSensitivity = 300.0f;
    public Transform playerTransform;
    public GameObject prefab;

    float pitchAngle = 0.0f;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        Look();
        CastRay();
    }

    void Look() {
       float mouseX =  Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
       float mouseY =  Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

       pitchAngle -= mouseY;
       pitchAngle = Mathf.Clamp(pitchAngle, -90.0f, 90.0f);

       transform.localRotation = Quaternion.Euler(pitchAngle, 0.0f, 0.0f);
       playerTransform.Rotate(Vector3.up * mouseX);
    }

    void CastRay() {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f)) {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
        }
        if (Input.GetButtonDown("Fire1")) {
            CreateObjectAtRay();
        }
    }

    void CreateObjectAtRay() {
        if (hit.collider.name=="Main Walls") {
            Instantiate(prefab, hit.point, Quaternion.identity);
            Debug.Log("Hit");
        }
        else {
            Debug.Log("Miss");
        }
    }
}
