using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("地上として判定するレイヤー")]
    public LayerMask m_Groundlayer;
    [SerializeField,Tooltip("スピードアップするタグ")]
    public string m_SpeedTag;
    [SerializeField, Tooltip("地上との判定距離")]
    public float m_rayDistance = 2.0f;

    public bool m_IsInvincible { get; private set; }

    [SerializeField]
    private float m_InvincibleTime = 0.0f; //無敵時間

    // Start is called before the first frame update
    void Start()
    {
        m_IsInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_IsInvincible = m_InvincibleTime >= 0.0f;
        m_InvincibleTime -= m_IsInvincible ? Time.deltaTime:0.0f;
    }

    //time秒間無敵にする
    public void SetInvincible(float time)
    {
        m_InvincibleTime = time;
    }
}
