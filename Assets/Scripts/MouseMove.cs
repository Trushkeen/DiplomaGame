using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensX = 3F;
    public float sensY = 3F;

    public float minX = -360;
    public float maxX = 360;
    public float maxY = -60;
    public float minY = 60;

    private Quaternion OriginalRot;
    private Quaternion ParentRot; 
    public float rotX = 0;
    public float rotY = 0;

    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.freezeRotation = true;
        }
        OriginalRot = transform.localRotation;
        ParentRot = transform.root.localRotation;
    }

    private void Update()
    {
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        rotX = rotX % 360;
        rotY = rotY % 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotX,Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = OriginalRot * yQuaternion;
        transform.root.localRotation = xQuaternion; 
    }
}
