using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField,Tooltip("再利用までの時間")]
    private float m_CoolTime = 0.0f;

    [Header("Status")]
    [SerializeField]
    private float m_TimeCount = 0.0f;
    [SerializeField]
    private bool m_IsUse = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        m_IsUse = m_TimeCount >= m_CoolTime;
        m_TimeCount += Time.deltaTime;
    }

    //スキル発動
    public virtual void Activate(PlayerController2D playerController2D)
    {
        if (!this.m_IsUse) return;
        m_TimeCount = 0f;
        Debug.Log("発動！！");
    }
}
