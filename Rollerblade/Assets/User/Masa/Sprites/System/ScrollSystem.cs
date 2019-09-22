using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSystem : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private GameObject ScrollObject;

    private void FixedUpdate()
    {
        ScrollObject.transform.Translate(-speed * Time.fixedDeltaTime,0,0);
    }
}
