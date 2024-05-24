using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* 
 * Timer made with this tutorial www.youtube.com/watch?v=u_n3NEi223E
 * Followed full thing so this can be used in future projects
 */


public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown; //Should always be false for this project

    [Header("Limit Settings")] //Not needed for this project
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats timerFormats;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        //If countDown is true do currentTime -= else do current +=

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))) 
        {
            currentTime = timerLimit;
            SetTimerText();
            //timerText color = Color red; Not needed for this project
            enabled = false;
        }

        SetTimerText();

    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[timerFormats]) : currentTime.ToString();
        //If hasFormat is true then a format is applied else the full string is shown
    }

}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal

}
