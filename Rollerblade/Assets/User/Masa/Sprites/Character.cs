using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("プレイヤーステータス")]
    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //無敵状態でないかつ、障害物に触れた
        if (!playerState.m_IsInvincible && collision.CompareTag("Obstacle"))
        {
            IsHit_Obstacle();
        }
    }

    //障害物に当たった
    public void IsHit_Obstacle()
    {
        //無敵状態を付与
        playerState.SetInvincible(4.0f);
        Destroy(this.gameObject);
    }
}
