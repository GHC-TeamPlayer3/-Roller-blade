using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour
{

    public Sprite spriteGrass;
    public Sprite spriteConcrete;

    public void changeSprite()
    {

        this.gameObject.GetComponent<Image>().sprite = spriteConcrete;

    }

}
