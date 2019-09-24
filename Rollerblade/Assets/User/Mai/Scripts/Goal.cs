using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    // 時間の取得
    public Timer timer;
    //　テキスト制御
    public GameObject GoalText;
    // スクロール制御
    public ScrollSystem scroll;
    public GameObject backGround;
    // 音楽
    public AudioSource audioBack;
    // リザルト制御
    public GameObject Result_Success;

    void Start()
    {
        // GOALテキストを非表示
        GoalText.SetActive(false);
        // リザルト画像を非表示
        Result_Success.SetActive(false);
        // BGMを開始
        audioBack.Play();
    }

    void StopTimer()
    {
        
//        yield return new WaitForSecondsRealtime(50);

    }

    void Update()
    {
    }

    // ぶつかった瞬間に呼び出される(時間内にゴールした)
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //
            timer.StopTimer = true;
            // ScrollSystemコンポーネントを削除
            Destroy(scroll);
            // BGMを停止
            audioBack.Stop();
            // 背景のスクロールを停止
            Destroy(backGround);
            // GOALテキストを表示
            GoalText.SetActive(true);
            // リザルトSuccess画像を表示
            Result_Success.SetActive(true);
        }
    }
}