using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator : MonoBehaviour
{
    [SerializeField] private Animator myElevator = null;
    public bool canOpen = false;
    public bool open = false;
    public bool inUse = false;
    //public BoxCollider collider;

    private void Start()
    {
        /*Transform child = transform.Find("elevator doors");
        if (child != null)
        {
            BoxCollider collider = child.GetComponent<BoxCollider>();
            Debug.LogError("CHILD NOT FOUND");
        }

        //FOR THE COLLIDERS TO WORK I NEED THEM TO BE IN THE WALL LAYER!!@!!!!!
        //ADD MESH COLLIDER
        */

    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            changeAnimation();
            Debug.Log("pressed E");

        }
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
            if(inUse == false)
            {
                changeAnimation();
            }
            canOpen = false;
        }

    }
  
    public void changeAnimation()
    {
        if (!open && canOpen == true)
        {
            myElevator.Play("elevator_close", 0, 0.0f);
            Debug.Log("Door Opened");
            open = true;
            canOpen = false;
        }
        else if (open && inUse) 
        {
            myElevator.Play("elevator_open", 0, 0.0f);
            open = false;
            //collider.enabled = true;
        }
        else if(!open && !inUse && canOpen == false)
        {
            myElevator.Play("elevator_close", 0, 0.0f);
            open = true;
           // collider.enabled = false;
        }
        else if (open && !inUse) 
        {
            myElevator.Play("elevator_open", 0, 0.0f);
            open = false;
            //collider.enabled = true;
        }
    }
}
