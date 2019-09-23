using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSystem : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField,Header("最低速度")]
    private float LowSpeed = 0.1f;
    [SerializeField, Header("最高速度")]
    private float MaxSpeed = 20.0f;
    [SerializeField,Header("基本速度")]
    private float BaseSpeed = 5f;
    [SerializeField]
    private GameObject ScrollObject;

    [Header("Status")]
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float addSpeed = 0f;
    [SerializeField]
    private bool IsStop = false;

    private void Update()
    {
        if (IsStop)
        {
            speed = 0.0f;
            return;
        }

        speed = BaseSpeed + addSpeed;
        if (speed < LowSpeed)
        {
            speed = LowSpeed;
            addSpeed = speed - BaseSpeed;
        }
        if (speed > MaxSpeed)
        {
            speed = MaxSpeed;
            addSpeed = speed - BaseSpeed;
        }
    }
    private void FixedUpdate()
    {
        ScrollObject.transform.Translate(-speed * Time.fixedDeltaTime,0,0);
    }

    public void AddSpeed(float add)
    {
        this.addSpeed += add;
    }

    public void SetAddSpeed(float addSpeed)
    {
        this.addSpeed = addSpeed;
    }

    public void SetSpeed(float speed)
    {
        this.addSpeed = speed - this.BaseSpeed;
    }

    public void SetBaseSpeed(float baseSpeed)
    {
        this.BaseSpeed = baseSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Stop()
    {
        IsStop = true;
    }
}
