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
    // 音楽
    public AudioSource audioSource;
    // リザルト制御
    public GameObject Result_Success;
    public GameObject Result_False;

    void Start()
    {
        // GOALテキストを非表示
        GoalText.SetActive(false);
        // リザルト画像を非表示
        Result_Success.SetActive(false);
        Result_False.SetActive(false);
        // BGMを開始
        audioSource.Play();
    }

    void Update()
    {

    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // ScrollSystemコンポーネントを削除
            Destroy(scroll);
            // 時間内にゴールしたら
            if ( timer)
            {
                // BGMを停止
                audioSource.Stop();
                // GOALテキストを表示
                GoalText.SetActive(true);
                // リザルトSuccess画像を表示
                Result_Success.SetActive(true);
            }

            // 時間内にゴールできなかったら
            else
            {
                // リザルトSuccess画像を表示
                Result_False.SetActive(true);

            }

        }
    }
}