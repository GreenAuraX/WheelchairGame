using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator : MonoBehaviour
{
    [SerializeField] private Animator myElevator = null;
    public bool canOpen = false;
    public bool open = false;
    public bool inUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
        }

    }
    public void changeAnimation()
    {
        if (!open && canOpen == true)
        {
            myElevator.Play("elevator_open)", 0, 0.0f);
            open = true;
        }
        else if (open && inUse)
        {
            myElevator.Play("elevator_close", 0, 0.0f);
            open = false;
        }
        else if(!open && !inUse && canOpen == false)
        {
            myElevator.Play("elevator_open", 0, 0.0f);
            open = true;
        }
    }
}
