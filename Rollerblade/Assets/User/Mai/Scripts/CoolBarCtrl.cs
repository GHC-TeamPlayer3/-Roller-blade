using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoolBarCtrl : MonoBehaviour
{

   public Slider slider;

    // trueならリキャスト
    // falseならゲージがたまる
    public bool SkillFlag;

    void Start()
    {
        float maxCool = 3.5f;
        float nowCool = 1f;


        //スライダーの最大値の設定
        slider.maxValue = maxCool;

        //スライダーの現在値の設定
        slider.value = nowCool;


    }

    float cool = 0;
    void Update()
    {
        // ゲージ上昇
        cool += 0.01f;

        // ゲージがたまった場合
        if ( cool >1 )
        {
            // スキルが発動した場合
            if ( SkillFlag == true)
            {
                cool = 0;
            }
        }
        slider.value = cool;
    }


}