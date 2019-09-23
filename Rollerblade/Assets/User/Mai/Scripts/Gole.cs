using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class Gole : MonoBehaviour
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
            
        }
    }
}
