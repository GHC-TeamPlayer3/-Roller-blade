using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleSkill : Skill
{
    [Header("Parameter")]
    [SerializeField]
    private float InvincibleTime = 3.0f;

    public override void Activate(PlayerController2D playerController2D)
    {
        Debug.Log("Skill：無敵");
        playerController2D.SetInvincibleTime(InvincibleTime);
    }
}
