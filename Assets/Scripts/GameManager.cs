using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;


public class GameManager : MonoBehaviour
{

    public Text timerText;
    public Text scoreText;
    private float score = 1;
    private float seconds;
    private int minute;
    private int hour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerUI();
        if (Input.GetKeyDown("space"))
        {
            scoreText.text = score.ToString("0") + "/10";
        }
    }
    void TimerUI()
    {
        seconds += Time.deltaTime;
        timerText.text =  minute.ToString("00") + ":" + seconds.ToString("00");
        if (seconds >= 60)
        {
            minute++;
            seconds = 0;
        }

    }
}
