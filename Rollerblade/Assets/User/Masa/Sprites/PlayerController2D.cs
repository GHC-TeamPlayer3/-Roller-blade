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
    [SerializeField, Tooltip("地上として判定するレイヤー")]
    private LayerMask m_Groundlayer;
    [SerializeField, Tooltip("地上との判定距離")]
    private float m_rayDistance = 2.0f;

    [Header("Status")]
    [SerializeField]
    private float horizontalMove = 0f;
    [SerializeField]
    private bool m_isJump = false;
    [SerializeField]
    private bool m_onGround = false;
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        this.m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.horizontalMove = this.GetHorizontal() * m_runSpeed;
        this.m_onGround = Check_OnGround();
        this.m_isJump = Input.GetButtonDown("Jump") && m_onGround;
    }

    //物理挙動
    private void FixedUpdate()
    {
        this.m_rigidbody2D.AddForce(Vector2.right * horizontalMove);
        if (m_isJump)
        {
            this.m_rigidbody2D.AddForce(Vector2.up * m_jumpPower);
            m_isJump = false;
        }
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