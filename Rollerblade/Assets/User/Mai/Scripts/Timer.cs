using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Goal goal;
    public PlayerController2D playerCtrl;

    // タイマーテキストを表示
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText_Result;

    // 制限時間
    public float totalTime;
    public bool StopTimer;
    // 音楽
    public AudioSource audioBack;
    public AudioSource audioMiss;
    // スクロール制御
    public ScrollSystem scroll;
    // リザルト制御
    public GameObject Result_False;
    // プレイヤーの動き制御
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;



    void Start()
    {
        totalTime = 50f;
        // リザルト画像を非表示
        Result_False.SetActive(false);
        timerText_Result.text = " ";
        // リザルト音楽を非表示
        audioMiss.Stop();
    }

    void Update()
    {

        string minText, secText, msecText;//分・秒を用意

        if (goal.goalFlag == true )
        {
            totalTime -= Time.deltaTime; //毎フレームの時間を減算.
            int second = (int)totalTime % 60;//秒.timeを60で割った余り.
            int msecond = (int)(totalTime * 100 % 100);

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
            StopTimer = true;
            timerText_Result.text = secText + ":" + msecText;
            transform.Translate(1.0f * Time.deltaTime, 0, 0);
        }


        if (StopTimer == false)
        {
            totalTime -= Time.deltaTime; //毎フレームの時間を減算.
            int second = (int)totalTime % 60;//秒.timeを60で割った余り.
            int msecond = (int)(totalTime * 100 % 100);
           
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
            transform.Translate(1.0f * Time.deltaTime, 0, 0);


            //　制限時間が0秒以下なら何もしない
            if (totalTime <= 0f || playerCtrl.IsEnd == true)
            {
                timerText.text = "00:00";
                // ScrollSystemコンポーネントを削除
                Destroy(scroll);
                Destroy(player1);
                Destroy(player2);
                Destroy(player3);

                // BGMを停止
                audioBack.Stop();

                MissMusic();

                // リザルトFlase画像を表示
                Result_False.SetActive(true);
                timerText_Result.text = "00:00";
            }
            
          
        }
        Debug.Log(totalTime);
    }
    void MissMusic()
    {
            // Miss効果音を再生
            audioMiss.Play();
    }  
}