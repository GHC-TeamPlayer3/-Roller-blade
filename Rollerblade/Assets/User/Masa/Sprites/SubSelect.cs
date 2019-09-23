using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSelect : MonoBehaviour
{
    public Image selectImage;
    public int nSelect = 0;
    public SelectObject selectObject = null;

    public void SelectElement(List<SelectObject> sprites)
    {
        if (Input.GetButtonUp("SelectLeft")) nSelect--;
        if (Input.GetButtonUp("SelectRight")) nSelect++;

        if (nSelect >= sprites.Count) nSelect = 0;
        if (nSelect < 0) nSelect = sprites.Count - 1;

        if (selectObject != sprites[nSelect]) selectObject.IsAttach = false;
        selectObject = sprites[nSelect];
        selectImage.sprite = selectObject.Charaimage;
    }

    public void Update()
    {
        selectObject.IsAttach = true;
    }
}
