using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiVisible : MonoBehaviour
{
    // Reference to the UI element
    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            // Enable the UI element
            uiElement1.SetActive(true);
            uiElement2.SetActive(true);
            uiElement3.SetActive(true);
            uiElement4.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger
        if (other.CompareTag("Player"))
        {
            // Disable the UI element
            uiElement1.SetActive(false);
            uiElement2.SetActive(false);
            uiElement3.SetActive(false);
            uiElement4.SetActive(false);
        }
    }
}
