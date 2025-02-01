using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public TriggerDoor triggerDoor;
    public TriggerElevator triggerElevator;
    public doorslide triggerSlidingDoor;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggerDoor.changeAnimation();
            triggerElevator.changeAnimation();
            triggerSlidingDoor.changeAnimation();
        }
    }
}
