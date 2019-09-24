using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    private float time = 0f;
    [SerializeField]
    private float life = 2f;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= life)
            Destroy(this.gameObject);

        time += Time.deltaTime;
    }
}
