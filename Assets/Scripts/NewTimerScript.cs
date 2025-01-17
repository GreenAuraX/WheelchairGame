using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTimerScript : MonoBehaviour
{
    public NewPlayerMove player;
    [SerializeField] private int tickCount = 0;
    [SerializeField] private int tickTime = 2;
    public TMP_Text timerText;

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
        timerText.text = "Time Over!";
        // Debug.Log("Timer stopped after 10 ticks");
    }
}
