using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NewTimerScript : MonoBehaviour
{
    public NewPlayerMove player;
    [SerializeField] private int tickCount = 0;
    [SerializeField] private int tickTime = 2;
    public TMP_Text timerText;

    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;
   // public GameObject uiElement5;
   // public GameObject uiElement6;

    // Start is called before the first frame update
    void Start()
    {
        tickCount = 489;
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while (tickCount < 510)
        {
            tickCount++;
            Debug.Log("Tick" + tickCount + ": Timer is ticking");

            yield return new WaitForSeconds(tickTime);

            if (timerText != null )
            {
                float minutes = Mathf.FloorToInt(tickCount / 60);
                float seconds = Mathf.FloorToInt(tickCount % 60);
                timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            }
        }



        // player.canMove = false;
        OBJStop();
        OBJStart();

        timerText.text = "Time Over!";
        // Debug.Log("Timer stopped after 10 ticks");

    }
    public void OBJStop()
    {
        uiElement1.SetActive(false);
        uiElement2.SetActive(false);
        uiElement3.SetActive(false);
    }    public void OBJStart()
    {
        uiElement4.SetActive(true);
       // uiElement5.SetActive(false);
       // uiElement6.SetActive(false);
    }
}
