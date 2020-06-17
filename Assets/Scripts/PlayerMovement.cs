using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed = 25F;
    private Rigidbody Rigid;
    private bool SprintEnabled;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        SprintEnabled = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(Controls.ForwardBtn))
        {
            transform.position += transform.forward * (SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }
        else if (Input.GetKey(Controls.BackwardBtn))
        {
            transform.position += transform.forward * -Speed * Time.deltaTime;
        }
        if (Input.GetKey(Controls.RightBtn))
        {
            transform.position += transform.right * (SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }
        else if (Input.GetKey(Controls.LeftBtn))
        {
            transform.position += transform.right * -(SprintEnabled ? Speed * 2 : Speed) * Time.deltaTime;
        }

        if (Input.GetKeyDown(Controls.JumpBtn))
        {
            Debug.DrawRay(transform.position, Vector3.down * 15F, Color.red, 5F);
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 15F, LayerMask., QueryTriggerInteraction.Ignore))
            {
                Rigid.AddForce(transform.up * 300F, ForceMode.Acceleration);
            }
        }

        if (transform.position.y < 0)
        {
            var pos = transform.position;
            transform.position = new Vector3(pos.x, 50, pos.z);
        }
    }
}
