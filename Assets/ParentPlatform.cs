using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
        Debug.Log("on platform");
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null); 
    }
    // collision exit never happens since the player model is stuck
    //also elevator doors dont open when the elevator reaches up
}
