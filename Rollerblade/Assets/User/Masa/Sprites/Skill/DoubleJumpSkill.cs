using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpSkill : Skill
{
    public override void Update()
    {
        base.Update();
    }

    public override bool Activate(PlayerController2D playerController2D)
    {
        Debug.Log("二段ジャンプ");
        if (!base.Activate(playerController2D)) return false;
        playerController2D.Jump();
        Debug.Log("成功！！");
        return true;
    }
}
