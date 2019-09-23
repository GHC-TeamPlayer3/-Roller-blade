using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("地上として判定するレイヤー")]
    public LayerMask m_Groundlayer;
    [SerializeField, Tooltip("地上との判定距離")]
    public float m_rayDistance = 0.4f;

    [SerializeField]
    private float m_InvincibleTime = 0.0f; //無敵時間

    public List<Character> characters;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
