﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("プレイヤーステータス")]
    public PlayerState m_playerState;
    [Space(8)]

    [SerializeField, Tooltip("ベース速度")]
    public float m_Speed = 10.0f;
    [SerializeField, Tooltip("スクロール加速度")]
    public float m_AddSpeed = 0.1f;
    [SerializeField, Tooltip("スクロール減速度")]
    public float m_DownSpeed = -0.1f;
    [SerializeField, Tooltip("速度制限")]
    public float m_MaxVelocity = 10.0f;

    [SerializeField, Tooltip("重さ")]
    public float m_Mass = 1.0f;
    [SerializeField, Tooltip("ジャンプ力")]
    public float m_JumpPower = 200.0f;
    [Space(8)]
    [SerializeField]
    public Skill skill;

    [Header("Status")]
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField, Tooltip("Animator")]
    private Animator m_animator;
    [SerializeField]
    public CircleCollider2D m_CircleCol;
    [SerializeField]
    public Collider2D GoundCollider;

    public enum State
    {
        Idle,
        Run,
        Jump
    }

    //新規ステータス
    public bool IsActiveCharacter = false;
    public State state = State.Idle;

    public bool IsDoubleJump = false;   //二段ジャンプしたか
    public bool CanDoubleJump = false;  //二段ジャンプできるか
    public bool OnGround = false;
    public ScrollSystem scrollSystem;
    public GameObject forwardChara;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_CircleCol = this.transform.GetComponentInChildren<CircleCollider2D>();

        this.m_rigidbody2D.mass = m_Mass;
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = Check_OnGround();
        if (OnGround)
            IsDoubleJump = false;

        //ステート
        if (!OnGround)
            state = State.Jump;
        else if (scrollSystem.GetSpeed() == 0.0f)
            state = State.Idle;
        else
            state = State.Run;

        //アニメーション
        switch (state)
        {
            case State.Idle:
                m_animator.SetBool("Jumping",false);
                m_animator.SetBool("Running",false);
                break;
            case State.Jump:
                m_animator.SetBool("Jumping", true);
                break;
            case State.Run:
                m_animator.SetBool("Running",true);
                m_animator.SetBool("Jumping",false);
                break;
        }
    }

    void FixedUpdate()
    {
        m_CircleCol.enabled = OnGround;
        if (!IsActiveCharacter)
        {
            Vector2 vector = this.forwardChara.transform.position - this.transform.position;
            m_rigidbody2D.AddForce(vector,ForceMode2D.Impulse);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsActiveCharacter) return;
        //障害物に触れた
        if (collision.CompareTag("Obstacle"))
        {
            float speed = 0.0f;
            GimickState gimickstate = collision.GetComponent<GimickState>();
            if (gimickstate != null) speed = gimickstate.GetDownSpeed();
            scrollSystem.AddSpeed(speed);
        }
    }

    //地上に居るか
    public bool Check_OnGround()
    {
        Vector3 offset = new Vector3(0.0f,-1.0f,0.0f);
        Ray2D ray2d = new Ray2D(offset + this.transform.position, Vector2.down);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(ray2d.origin, ray2d.direction, m_playerState.m_rayDistance,m_playerState.m_Groundlayer);
        Debug.DrawRay(ray2d.origin, ray2d.direction * m_playerState.m_rayDistance, Color.red);
        GoundCollider = raycastHit2D.collider;
        return raycastHit2D.collider != null && raycastHit2D.point.y < this.transform.position.y;
    }
}