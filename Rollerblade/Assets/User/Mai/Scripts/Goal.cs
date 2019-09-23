using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject GoalText;
    public ScrollSystem scroll;
    public AudioSource audioSource;

    void Start()
    {
        // GOALテキストを非表示
        GoalText.SetActive(false);
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
            // GOALテキストを表示
            GoalText.SetActive(true);
            // BGMを停止
            audioSource.Stop();
        }
    }
}