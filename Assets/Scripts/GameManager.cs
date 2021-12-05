using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;


public class GameManager : MonoBehaviour
{

    public Text timerText;
    public Text scoring;
    private float seconds;
    private int minute;
    private float puDuration;
    BaseBullet kills;
    float totalKills = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerUI();
        

    }
    void tKills()
    {
        totalKills = kills.kills;
        scoring.text = totalKills.ToString("00") + "/00";
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
