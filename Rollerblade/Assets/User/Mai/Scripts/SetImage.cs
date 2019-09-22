using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    public Image image;
    private Sprite sprite;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Z キーが押された時
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sprite = Resources.Load<Sprite>("yuka3");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}