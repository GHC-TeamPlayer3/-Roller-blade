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

        StartCoroutine("Change");
    }

    // 何かしらのタイミングで呼ばれる
    void ChangeStateToHold()
    {
        MainSpriteRenderer.sprite = HoldSprite;
    }
 

    IEnumerator Change()
    {
        // 芝生　→　コンクリ


        yield return new WaitForSeconds(40f);
    }
}
