using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSelect : MonoBehaviour
{
    public Image charaImage;
    public Image skillImage;

    public Color enableColor = Color.gray;

    private int nCharaSelect = 0;
    private int nSkillSelect = 0;

    public CharaObject charaObject = null;
    public SkillObject skillObject = null;

    public void SetCharacter(List<CharaObject> charaObjects)
    {
        int old = nCharaSelect;
        if (Input.GetButtonDown("SelectLeft")) nCharaSelect--;
        if (Input.GetButtonDown("SelectRight")) nCharaSelect++;
        if (nCharaSelect < 0) nCharaSelect = charaObjects.Count-1;
        if (nCharaSelect > charaObjects.Count-1) nCharaSelect = 0;

        if (charaObject != null) charaObject.nAttach--;
        charaObject = charaObjects[nCharaSelect];
        charaObject.nAttach++;
        charaImage.sprite = charaObjects[nCharaSelect].image;
        
    }

    public void SetSkill(List<SkillObject> skillObjects)
    {
        int old = nSkillSelect;
        if (Input.GetButtonDown("SelectLeft")) nSkillSelect--;
        if (Input.GetButtonDown("SelectRight")) nSkillSelect++;
        if (nSkillSelect < 0) nSkillSelect = skillObjects.Count - 1;
        if (nSkillSelect > skillObjects.Count - 1) nSkillSelect = 0;

        if (skillObject != null) skillObject.nAttach--;
        skillObject = skillObjects[nSkillSelect];
        skillObject.nAttach++;
        skillImage.sprite = skillObjects[nSkillSelect].image;
    }

    public void Update()
    {
        if (charaObject.nAttach > 1)
            charaImage.color = enableColor;
        else
            charaImage.color = Color.white;

        if (skillObject.nAttach > 1)
            skillImage.color = enableColor;
        else
            skillImage.color = Color.white;
    }
}
