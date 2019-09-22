using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class chgSprite : MonoBehaviour
{
    public GameObject grass;

    void Start()
    {
    }

    void Update()
    {

    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            // grassを削除
            Destroy(grass);
        }
    }
}