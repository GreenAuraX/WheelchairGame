using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public bool canOpen = false;
    private bool open = false;

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
            myDoor.Play("DoorOpen", 0, 0.0f);
            open = true;
        }
        else if (open && canOpen == true)
        {
            myDoor.Play("DoorClose", 0, 0.0f);
            open = false;
        }
    }
}
