using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float SensX = 3F;
    public float SensY = 3F;

    public float MinX = -360;
    public float MaxX = 360;
    public float MaxY = -60;
    public float MinY = 60;

    private Quaternion OriginalRot;
    private Quaternion ParentRot; 
    public float RotX = 0;
    public float RotY = 0;

    private static bool IsFrozen = false;

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
        if (!IsFrozen)
        {
            RotX += Input.GetAxis("Mouse X") * SensX;
            RotY += Input.GetAxis("Mouse Y") * SensY;

            RotX = RotX % 360;
            RotY = RotY % 360;

            RotX = Mathf.Clamp(RotX, MinX, MaxX);
            RotY = Mathf.Clamp(RotY, MinY, MaxY);

            Quaternion xQuaternion = Quaternion.AngleAxis(RotX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(RotY, Vector3.left);

            transform.localRotation = OriginalRot * yQuaternion;
            transform.root.localRotation = xQuaternion;
        }
    }

    public static void Freeze()
    {
        IsFrozen = true;
    }

    public static void Unfreeze()
    {
        IsFrozen = false;
    }
}
