using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rotate : MonoBehaviour
{
   /* public Transform firstPos;
	public float rotateTime = 3.0f;
	public float rotateDegrees = 90.0f;
	private bool rotating = false;

	void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			Debug.Log("miau");
			Rotate(transform, firstPos, Vector3.up, rotateDegrees, rotateTime);
		}
	}

    public IEnumerator Rotate(Transform thisTransform, Transform otherTransform, Vector3 rotateAxis, float degrees, float totalTime)
    {
        if (rotating)
            yield return null;
        rotating = true;

        Debug.Log("miaumiau");
        var startRotation = thisTransform.rotation;
        var startPosition = thisTransform.position;
        transform.RotateAround(otherTransform.position, rotateAxis, degrees);
        var endRotation = thisTransform.rotation;
        var endPosition = thisTransform.position;
        thisTransform.rotation = startRotation;
        thisTransform.position = startPosition;

        var rate = degrees / totalTime;

        for (float i = 0.0f; i < degrees; i += Time.deltaTime * rate)
        {
            yield return null;
            thisTransform.RotateAround(otherTransform.position, rotateAxis, Time.deltaTime * rate);
        }

        thisTransform.rotation = endRotation;
        thisTransform.position = endPosition;
        rotating = false;
    }
   */
	


    /*
     
    [SerializeField]
	float rotationspeed;

    public Vector3 targetAngle = new Vector3(0f, 90f, 0f);

    private Vector3 currentAngle;

	bool ok = true;

    public void Start()
    {
            currentAngle = transform.eulerAngles;
			
    }

    void Update()
    {
		if(ok)
		{
			currentAngle += new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetAngle.y, 1), 0) * Time.deltaTime * rotationspeed;
			//Debug.Log(currentAngle.x + ',' + currentAngle.y + ',' + currentAngle.z);
			transform.localEulerAngles = currentAngle;
			if(transform.localEulerAngles.y > 0)
		}
		
    }
	*/


    /*[SerializeField] private float rotationSpeed = 100f;

    private float targetAngle = 90f;
    private float startAngle;
    private bool rotating = false;

    void Start()
    {
        startAngle = transform.eulerAngles.y;
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
			rotating = true;

        if (rotating)
        {
            float newAngle = Mathf.MoveTowards(transform.eulerAngles.y, startAngle + targetAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, newAngle, 0);

            if (Mathf.Approximately(newAngle, startAngle + targetAngle))
            {
                rotating = false; 
            }
        }
    }

	void Rotate()
	*/

    /*
     * [SerializeField] private float rotationSpeed = 100f;
    private float targetAngle = 90f;
    private bool isOpen = false;

    public void ToggleDoor()
    {
        StopAllCoroutines(); // Stop any existing rotation coroutine
        StartCoroutine(RotateDoor(isOpen ? -targetAngle : targetAngle));
        isOpen = !isOpen;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // 
        {
            ToggleDoor();
        }
    }

    private IEnumerator RotateDoor(float angle)
    {
        float startAngle = transform.eulerAngles.y;
        float endAngle = startAngle + angle;

        while (!Mathf.Approximately(transform.eulerAngles.y, endAngle))
        {
            float newAngle = Mathf.MoveTowards(transform.eulerAngles.y, endAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, newAngle, 0);
            yield return null; 
        }
    }
    */
    [SerializeField] private float rotationSpeed = 100f;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;
    private bool canOpen = false;

    void Start()
    {
        closedRotation = transform.localRotation; 
        openRotation = closedRotation * Quaternion.Euler(0, 90, 0);
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor(isOpen ? closedRotation : openRotation));
        isOpen = !isOpen;
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    { 
        while (!Mathf.Approximately(Quaternion.Angle(transform.localRotation, targetRotation), 0))
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

