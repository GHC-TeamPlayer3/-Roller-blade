using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SelectObject
{
    public Sprite Charaimage;
    public Character character;
    public bool IsAttach;
}

public class MainSelect : MonoBehaviour
{
    public List<SelectObject> SelectObjects;
    public List<SubSelect> subSelects;
    public int nSelect = 0;
    public GameObject submit = null;

    public Image selecter;
    private float time;
    private float cooltime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int oldSelect = nSelect;
        float input = Input.GetAxisRaw("Vertical");

        if (time >= cooltime)
        {
            if (input >= 1.0f) nSelect--;
            if (input <= -1.0f) nSelect++;

            if (nSelect >= subSelects.Count) nSelect = 0;
            if (nSelect < 0) nSelect = subSelects.Count - 1;
        }
        if (oldSelect != nSelect) time = 0f;
        

        subSelects[nSelect].SelectElement(SelectObjects);
        selecter.transform.position = subSelects[nSelect].transform.position;
        time += Time.deltaTime;

        CheakList();
    }

    void CheakList()
    {
        bool IsSubmit = true;
        foreach(SelectObject select in SelectObjects)
        {
            IsSubmit = IsSubmit && select.IsAttach;
        }

        submit.SetActive(IsSubmit);
    }
}
