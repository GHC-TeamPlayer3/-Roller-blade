using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpSkill : Skill
{
    [SerializeField]
    private float addSpeed = 4.0f;

    public override void Activate(PlayerController2D playerController2D)
    {
        playerController2D.scrollSystem.AddSpeed(addSpeed);
    }
}
