using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float totalTime;
    int seconds;

    void Start()
    {
        totalTime = 60f;
    }

    void Update()
    {
        totalTime -= Time.deltaTime; //毎フレームの時間を減算.

        int second = (int)totalTime % 60;//秒.timeを60で割った余り.
        int msecond = (int)(totalTime * 100 % 100);
        string minText, secText, msecText;//分・秒を用意.
        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();

        if (msecond < 10)
            msecText = "0" + msecond.ToString();

        else if (msecond < 100)
            msecText = msecond.ToString();
        else
            msecText = msecond.ToString();


        timerText.text = secText + ":" + msecText;

        Debug.Log(totalTime);

    }
}