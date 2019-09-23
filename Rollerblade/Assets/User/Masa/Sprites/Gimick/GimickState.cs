using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickState : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    public float DownSpeed = 1.0f;

    public float GetDownSpeed()
    {
        this.enabled = false;
        return DownSpeed;
    }
}
