using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;


public class GameManager : MonoBehaviour
{
    public static GameManager i = null;

    public Text timerText;
    public Text scoring;
    private float seconds;
    private int minute;
    public float totalKills;


    // Start is called before the first frame update
    void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerUI();
        tKills();

    }
    void tKills()
    {
        scoring.text = totalKills.ToString("00") + "/12";
    }
    void TimerUI()
    {
        seconds += Time.deltaTime;
        timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
        if (seconds >= 60)
        {
            minute++;
            seconds = 0;
        }

    }
}