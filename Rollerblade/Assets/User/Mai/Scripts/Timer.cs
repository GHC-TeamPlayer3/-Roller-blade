using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // タイマーテキストを表示
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText_Result;

    // 制限時間
    public float totalTime;
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
        totalTime = 10f;
        // リザルト画像を非表示
        Result_False.SetActive(false);
        timerText_Result.text = " ";
        // リザルト音楽を非表示
        audioMiss.Stop();

        // タイマーを停止
        StartCoroutine("StopTimer");
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
            // ScrollSystemコンポーネントを削除
            Destroy(scroll);
            Destroy(player1);
            Destroy(player2);
            Destroy(player3);

            // BGMを停止
            audioBack.Stop();

            // Miss効果音を再生
            audioMiss.Play();

            // リザルトFlase画像を表示
            Result_False.SetActive(true);
            timerText_Result.text = "00:00";
        }
        else
        {
            timerText.text = secText + ":" + msecText;
            transform.Translate(1.0f * Time.deltaTime, 0, 0);
        }
        Debug.Log(totalTime);
    }

        // タイマー停止用のコルーチン
        IEnumerator SampleCoroutine()
        {
            yield return new WaitForSeconds(100f);
        }    
}