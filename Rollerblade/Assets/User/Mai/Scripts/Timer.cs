using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // タイマーテキストを表示
    public TextMeshProUGUI timerText;
    // 制限時間
    public float totalTime;
    // ゴールしたかどうか
    bool goalFlag;
    // 
    private GameObject Result_Success;



    void Start()
    {
        goalFlag = false;
        totalTime = 50f;
        // リザルト画像を非表示
        Result_Success.SetActive(false);
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


        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            timerText.text = "00:00";
            goalFlag　= true;
            return;
        }
        else
        {
            timerText.text = secText + ":" + msecText;
        }

        if ( goalFlag == true )
        {
            // リザルト画像を表示
            Result_Success.SetActive(true);
        }

        Debug.Log(totalTime);

    }
}