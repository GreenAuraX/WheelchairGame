using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool canOpen = false;
    private bool open = false;

    private void Update()
    {
        Debug.Log(canOpen);
        changeAnimation();
    }

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
        if (Input.GetKeyDown(KeyCode.E) && canOpen == true)
        {

            if (!open)
            {
                myDoor.Play("DoorOpen");
                open = true;
            }
            else if (open)
            {
                myDoor.Play("DoorClose");
                open = false;
            }
        }
    }
}
