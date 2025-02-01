using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiVisible : MonoBehaviour
{
    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement1.SetActive(true);
            uiElement2.SetActive(true);
            uiElement3.SetActive(true);
            uiElement4.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement1.SetActive(false);
            uiElement2.SetActive(false);
            uiElement3.SetActive(false);
            uiElement4.SetActive(false);
        }
    }
}
