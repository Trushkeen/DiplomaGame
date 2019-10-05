using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 5F * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -5F * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 5F * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -5F * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var rigid = GetComponent<Rigidbody>();
            rigid.AddForce(transform.up * 500F, ForceMode.Acceleration);
        }
    }
}
