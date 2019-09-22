using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    private GameObject target;

    //初期位置
    private Vector3 DefaultPos;

    // Start is called before the first frame update
    void Start()
    {
        DefaultPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 vector = new Vector3(
                this.transform.position.x, target.transform.position.y, this.transform.position.z);

            if (vector.y <= DefaultPos.y)
                vector = new Vector3(vector.x, DefaultPos.y, vector.z);

            this.transform.position = vector;
            
        }
    }
}
