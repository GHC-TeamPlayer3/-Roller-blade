using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpSkill : Skill
{
    [SerializeField]
    private float addSpeed = 4.0f;

    public override bool Activate(PlayerController2D playerController2D)
    {
        Debug.Log("スピードアップ");
        if (!base.Activate(playerController2D)) return false;
        playerController2D.scrollSystem.AddSpeed(addSpeed);
        return true;
    }
}
