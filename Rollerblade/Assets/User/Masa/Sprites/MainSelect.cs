using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharaObject
{
    public Sprite image;
    public Character character;
    public int nAttach;
}

[System.Serializable]
public class SkillObject
{
    public Sprite image;
    public Skill skill;
    public int nAttach;
}

public class MainSelect : MonoBehaviour
{
    public static List<Character> InstanceObjects = new List<Character>();

    public List<CharaObject> charaObjects;
    public List<SkillObject> skillObjects;

    public List<SubSelect> subSelects;
    public GameObject selecter;
    public GameObject startLabel;

    public SceneTransition sceneTransition;

    private int nSubSelect = 0;
    private int nSelect = 0;
    private float Subtime = 0f;
    private float time = 0f;
    private float cooltime = 0.2f;

    public void Start()
    {
        sceneTransition = GetComponent<SceneTransition>();

        foreach(SubSelect subSelect in subSelects)
        {
            subSelect.SetCharacter(charaObjects);
            subSelect.SetSkill(skillObjects);
        }
    }

    public void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        int old;
        old = nSubSelect;
        if (Subtime >= cooltime)
        {
            if (vertical > 0.5f) nSubSelect--;
            if (vertical < -0.5f) nSubSelect++;
            if (nSubSelect < 0) nSubSelect = subSelects.Count-1;
            if (nSubSelect > subSelects.Count-1) nSubSelect = 0;
        }
        if (old != nSubSelect) Subtime = 0f;
        Subtime += Time.deltaTime;

        SubSelect subSelect = subSelects[nSubSelect];
        float horizontal = Input.GetAxis("Horizontal");
        old = nSelect;
        if(time >= cooltime)
        {
            if (horizontal > 0.5f) nSelect--;
            if (horizontal < -0.5f) nSelect++;
            if (nSelect < 0) nSelect = 1;
            if (nSelect > 1) nSelect = 0;
        }
        if (old != nSelect) time = 0f;
        time += Time.deltaTime;

        if (nSelect == 0)
        {
            selecter.transform.position = subSelect.charaImage.transform.position;
            subSelect.SetCharacter(charaObjects);
        }
        else
        {
            selecter.transform.position = subSelect.skillImage.transform.position;
            subSelect.SetSkill(skillObjects);
        }

        if (ChackList())
        {
            startLabel.SetActive(true);
            if (Input.GetButtonDown("Fire2"))
            {
                InstanceObjects.Clear();
                foreach(SubSelect select in subSelects)
                {
                    Character character = select.charaObject.character;
                    character.skill = select.skillObject.skill;
                    InstanceObjects.Add(character);
                }
                sceneTransition.SceneChange();
            }
        }
        else
        {
            startLabel.SetActive(false);
        }
    }

    public bool ChackList()
    {
        bool enable = true;

        foreach(CharaObject charaObject in charaObjects)
            enable = enable && (charaObject.nAttach == 1);

        foreach (SkillObject skillObject in skillObjects)
            enable = enable && (skillObject.nAttach == 1);

        return enable;
    }
}
