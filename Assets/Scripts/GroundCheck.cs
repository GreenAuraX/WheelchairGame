using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    float groundCheckDistance;
    [SerializeField] float groundCheckBuffer = -0.5f;
    public LayerMask groundMask;
    public bool isGrounded = false;

    

    // Update is called once per frame
    void Update()
    {
        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2 + groundCheckBuffer);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, isGrounded ? Color.green : Color.red);

    }

    
}
