using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject GoalText;
    public ScrollSystem scroll;

    void Start()
    {
        // GOALテキストを非表示
        GoalText.SetActive(false);
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
        }
    }
}

 
   // public GameObject baseStage;

       // if (collider.gameObject.tag == "Player")
       // {
           // Destroy(gameObject.GetComponent<scroll>());
          // scroll.abled = !scroll.enabled;
       // }
       // if (baseStage.activeInHierarchy)
       // {
       //     scroll.enabled = !scroll.enabled;
       // }