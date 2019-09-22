using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("プレイヤーステータス")]
    public PlayerState m_playerState;
    [Space(8)]
    [SerializeField, Tooltip("速度")]
    public float m_Speed = 10.0f;
    [SerializeField, Tooltip("速度上限")]
    public float m_MaxVelocity = 10.0f;
    [SerializeField, Tooltip("重さ")]
    public float m_Mass = 1.0f;
    [SerializeField, Tooltip("ジャンプ力")]
    public float m_JumpPower = 200.0f;
    [SerializeField, Tooltip("浮遊力")]
    public float m_FloatPower = 0.0f;

    [Header("Status")]
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField, Tooltip("Animator")]
    private Animator m_animator;

    SpriteRenderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();

        this.m_rigidbody2D.mass = m_Mass;
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("Speed", 0.1f);
        //ジャンプアニメーション
        m_animator.SetBool("Jumping", !Check_OnGround());
    }

    private void FixedUpdate()
    {
        
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //無敵状態でないかつ、障害物に触れた
        if (!m_playerState.m_IsInvincible && collision.CompareTag("Obstacle"))
        {
            IsHit_Obstacle();
        }
    }

    //障害物に当たった
    public void IsHit_Obstacle()
    {
        //無敵状態を付与
        m_playerState.SetInvincible(4.0f);
        Destroy(this.gameObject);
    }

    //地上に居るか
    public bool Check_OnGround()
    {
        Ray2D ray2d = new Ray2D(this.transform.position, Vector2.down);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(ray2d.origin, ray2d.direction, m_playerState.m_rayDistance,m_playerState.m_Groundlayer);
        Debug.DrawRay(ray2d.origin, ray2d.direction * m_playerState.m_rayDistance, Color.red);
        return raycastHit2D.collider != null;
    }
}
