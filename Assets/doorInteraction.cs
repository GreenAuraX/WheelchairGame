using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class doorInteraction : MonoBehaviour
{
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

    void Update()
    {
        if(canOpen)
            if (Input.GetKeyDown(KeyCode.E))
                changeAnimation();
    }

    public void changeAnimation()
    {
        if (!open)
        {
            this.transform.Rotate(0, -90, 0);
            open = true;
        }
        else if (open)
        {
            this.transform.Rotate(0, 90, 0);
            open = false;
        }
    }
}
