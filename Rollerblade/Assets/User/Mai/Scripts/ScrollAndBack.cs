using UnityEngine;
using System.Collections;

public class ScrollAndBack : MonoBehaviour
{

    public float speed_ = 5f;
    public float startPositionX_ = 12.8f;
    public float endPositionX_ = -12.8f;

    private void FixedUpdate()
    {
        // 左にスクロールします。
        this.transform.Translate(-speed_ * Time.fixedDeltaTime, 0, 0);

        // 目標の x 座標を通過した場合
        if (transform.position.x <= endPositionX_)
        {
            // 開始の x 座標に戻します。
            transform.position = new Vector3(startPositionX_, transform.position.y, transform.position.z);
        }
    }
}