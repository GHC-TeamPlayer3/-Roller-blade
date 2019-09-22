using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("移動時の速度")]
    private float m_runSpeed = 10f;
    [SerializeField, Tooltip("ジャンプ時の力")]
    private float m_jumpPower = 200f;
    [SerializeField, Tooltip("最高速度")]
    private float m_maxVelocity_X = 10.0f;
    [SerializeField, Tooltip("地上として判定するレイヤー")]
    private LayerMask m_Groundlayer;
    [SerializeField, Tooltip("地上との判定距離")]
    private float m_rayDistance = 2.0f;
    [SerializeField, Tooltip("Animator")]
    private Animator m_animator;
    [SerializeField, Tooltip("X位置の変更をさせない")]
    private bool m_IsNotChangePos = false;

    [Header("Status")]
    [SerializeField]
    private float horizontalMove = 0f;
    [SerializeField]
    private bool m_isJump = false;
    [SerializeField]
    private bool m_onGround = false;
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField]
    private Vector2 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.m_rigidbody2D = this.GetComponent<Rigidbody2D>();
        if (this.m_IsNotChangePos)
            this.m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
       
    }

    // Update is called once per frame
    void Update()
    {
        this.m_onGround = Check_OnGround();
        if (!m_IsNotChangePos)
        {
            this.horizontalMove = this.GetHorizontal() * m_runSpeed;
            this.m_isJump = Input.GetButtonDown("Jump") && m_onGround;
            this.m_animator.SetFloat("Speed", Mathf.Abs(m_velocity.x));
        }
        else
        {
            this.m_isJump = Input.GetButtonDown("Jump") && m_onGround;
            this.m_animator.SetFloat("Speed",0.1f);
        }
    }

    //物理挙動
    private void FixedUpdate()
    {
        if (m_isJump)
        {
            this.m_rigidbody2D.AddForce(Vector2.up * m_jumpPower);
            m_isJump = false;
        }
        this.m_rigidbody2D.AddForce(Vector2.right * horizontalMove);
        m_velocity = this.m_rigidbody2D.velocity;
        m_velocity.x = Mathf.Clamp(m_velocity.x, -m_maxVelocity_X, m_maxVelocity_X);
        this.m_rigidbody2D.velocity = m_velocity;
    }

    //地上に居るか
    bool Check_OnGround()
    {
        Ray2D ray2d = new Ray2D(this.transform.position, Vector2.down);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(ray2d.origin, ray2d.direction, m_rayDistance, m_Groundlayer);
        Debug.DrawRay(ray2d.origin, ray2d.direction * m_rayDistance, Color.red);
        return raycastHit2D.collider != null;
    }

    //水平入力を取得
    float GetHorizontal()
    {
        float horizontal = 0f;
        horizontal = Input.GetAxis("Horizontal");
        //horizontal = Input.GetAxisRaw("Horizontal");
        return horizontal;
    }

    //垂直入力を取得
    float GetVertical()
    {
        float vertical = 0f;
        vertical = Input.GetAxis("Vertical");
        //vertical = Input.GetAxisRaw("Vertical");
        return vertical;
    }
}