using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    private Skill m_skill;

    [Header("Status")]
    [SerializeField]
    private float horizontalMove = 0f;
    [SerializeField]
    private bool m_isJump = false;
    [SerializeField]
    private bool m_isDoubleJump = false;
    [SerializeField]
    private bool m_onGround = false;
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField]
    private Vector2 m_velocity;
    [SerializeField]
    private Character m_character;

    // Start is called before the first frame update
    void Start()
    {
        this.m_rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.m_character = this.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        //ステータス更新
        this.m_onGround = m_character.Check_OnGround();

        //入力取得
        this.horizontalMove = this.GetHorizontal();
        this.m_isJump = Input.GetButtonDown("Jump") && m_onGround;

        if (Input.GetButtonDown("Fire3"))
            m_skill.Activate();
    }


    //物理挙動
    private void FixedUpdate()
    {
        if (m_isJump)
        {
            this.m_rigidbody2D.AddForce(Vector2.up *m_character.m_JumpPower);
            m_isJump = false;
        }
        this.m_rigidbody2D.AddForce(Vector2.right * horizontalMove * m_character.m_Speed);

        //最高速度制限
        m_velocity = this.m_rigidbody2D.velocity;
        m_velocity.x = Mathf.Clamp(m_velocity.x, -m_character.m_MaxVelocity, m_character.m_MaxVelocity);
        this.m_rigidbody2D.velocity = m_velocity;
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