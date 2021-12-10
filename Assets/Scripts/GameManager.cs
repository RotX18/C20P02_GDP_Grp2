using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;


public class GameManager : MonoBehaviour
{
    public static GameManager i = null;

    //timer
    public Text timerText;
    public Text scoring;
    private float seconds;
    private int minute;

    //score
    public float totalKills;

    //introduction
    public float page;
    public Button next;
    public Text start, intro, outro;
    public Button back;
    public GameObject vax1,vax2, vax3, menu, deathUI,health1, health2, health3;
    

    // Start is called before the first frame update
    void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimerUI();
        tKills();
        tHealth();
    }

    void tHealth()
    {
        switch (PlayerController.instance.Health)
        {
            case 0:
                health1.SetActive(false);
                deathUI.SetActive(true);
                break;
            case 1:
                health2.SetActive(false);
                break;
            case 2:
                health3.SetActive(false);
                break;
        }
    }
    void tKills()
    {
        scoring.text = totalKills.ToString("00") + "/12";
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
    public void Next()
    {
        page++;
        switch (page)
        {
            case 1:
                intro.gameObject.SetActive(false);
                vax1.SetActive(true);
                back.gameObject.SetActive(true);
                break;
            case 2:
                vax1.SetActive(false);
                vax2.SetActive(true);
                break;
            case 3:
                vax2.SetActive(false);
                vax3.SetActive(true);
                
                break;
            case 4:
                vax3.SetActive(false);
                outro.gameObject.SetActive(true);
                start.text = "Start";
                break;
            case 5:
                //start game, intro will close
                menu.SetActive(false);

                Time.timeScale = 1;
                break;
        }
    }
    public void Back()
    {
        page--;
        switch (page)
        {
            case 0:
                intro.gameObject.SetActive(true);
                vax1.SetActive(false);
                back.gameObject.SetActive(false);
                break;
            case 1:
                vax1.SetActive(true);
                vax2.SetActive(false);
                break;
            case 2:
                vax2.SetActive(true);
                vax3.SetActive(false);
                
                break;
            case 3:
                vax3.SetActive(true);
                outro.gameObject.SetActive(false);
                start.text = "Next";
                break;
        }

    }
}
