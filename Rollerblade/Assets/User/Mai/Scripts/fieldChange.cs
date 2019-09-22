using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldChange : MonoBehaviour
{
    public GameObject sprite;

    IEnumerator coroutineMethod;
    bool isRunning = false;

    //  コルーチン停止
    public void StopRunTime()
    {
        StopAllCoroutines();
    }

    SpriteRenderer MainSpriteRenderer;
        // publicで宣言し、inspectorで設定可能にする
        public Sprite StandbySprite;
        public Sprite HoldSprite;
        public Sprite SlashSprite;

   public void Start()
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
  public IEnumerator Change()
    {

        /* 右クリックしたとき、オブジェクト非表示 */
        if (sprite.transform.position.x >= 50)
        {
          //  gameObject.SetActive(false);
        }
        /*---------------------------------------*/

        while (true)
            {
            Debug.Log("loop Coroutine");
            yield return new WaitForSeconds(100f);
            }

        yield return null;
            Debug.Log("Change");  
    }
}

