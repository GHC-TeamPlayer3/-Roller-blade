using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleSkill : Skill
{
    [Header("Parameter")]
    [SerializeField]
    private PlayerState playerState;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Activate()
    {
        Debug.Log("Skill：無敵");
    }
}
