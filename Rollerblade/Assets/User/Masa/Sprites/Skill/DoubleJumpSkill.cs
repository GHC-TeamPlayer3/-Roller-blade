using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpSkill : Skill
{
    public override void Activate(PlayerController2D playerController2D)
    {
        playerController2D.Jump();
    }
}
