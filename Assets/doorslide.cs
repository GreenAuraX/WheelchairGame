using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class doorslide : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public bool canOpen = false;
    private bool open = false;

    public Animator myButton;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            changeAnimation();
            Debug.Log("pressed E");

        }
    }

    public void changeAnimation()
    {
        if (!open && canOpen == true)
        {
            myDoor.Play("main_door_open", 0, 0.0f);
            myButton.Play("button_press", 0, 0.0f);

            open = true;
        }
        else if (open && canOpen == true)
        {
            myDoor.Play("main_door_close", 0, 0.0f);
            myButton.Play("button_press", 0, 0.0f);

            open = false;
        }
    }
}
