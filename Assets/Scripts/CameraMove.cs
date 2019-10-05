using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float sensX = 1.0f;

    [SerializeField]
    private float sensY = 1.0f;

    [SerializeField]
    private float minX = -90.0f;

    [SerializeField]
    private float maxX = -90.0f;

    [SerializeField]
    private float minY = 90.0f;

    private Quaternion targetRot;
    private Quaternion parentRot;
    private static bool IsFrozen = false;

    void Start()
    {
        targetRot = transform.rotation;
        parentRot = transform.root.rotation;
    }

    void Update()
    {
        float rotY = Input.GetAxis("Mouse X") * sensX;
        float rotX = Input.GetAxis("Mouse Y") * sensY;

        if (!IsFrozen)
        {
            targetRot *= Quaternion.Euler(-rotX, 0.0f, 0.0f);
            parentRot *= Quaternion.Euler(0.0f, rotY, 0.0f);
        }

        transform.localRotation = targetRot;
        transform.root.localRotation = parentRot;
    }

    public static void FreezeCamera()
    {
        IsFrozen = true;
    }

    public static void UnfreezeCamera()
    {
        IsFrozen = false;
    }
}