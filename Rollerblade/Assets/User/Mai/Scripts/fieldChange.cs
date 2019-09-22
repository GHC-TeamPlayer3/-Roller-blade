using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldChange : MonoBehaviour
{

  SpriteRenderer MainSpriteRenderer;
        // publicで宣言し、inspectorで設定可能にする
        public Sprite StandbySprite;
        public Sprite HoldSprite;
        public Sprite SlashSprite;

    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(Change());

        Coroutine retC = StartCoroutine(Change());

        StopCoroutine(retC);
    }

    // 何かしらのタイミングで呼ばれる
    void ChangeStateToHold()
    {
        MainSpriteRenderer.sprite = HoldSprite;
    }

    // 芝生　→　コンクリ
    IEnumerator Change()
    {
        // roop
        //       while (frame > 0)
        //        {
        //            if (transform.position.x >= 12f)
        //            {
        //                ChangeStateToHold();
        //            }

        while (true)
        {
            Debug.Log("loop Coroutine");
            yield return new WaitForSeconds(100f);
        }

        yield return null;
            Debug.Log("Change");
//            frame--;
        }
    }
//}
