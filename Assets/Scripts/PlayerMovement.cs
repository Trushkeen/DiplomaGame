using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed = 5F;
    private Rigidbody Rigid;
    private bool SprintEnabled;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SprintEnabled = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * (SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -(SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2F, 11 << 8, QueryTriggerInteraction.Ignore))
            {
                Rigid.AddForce(transform.up * 500F, ForceMode.Acceleration);
            }
        }


    }
}
