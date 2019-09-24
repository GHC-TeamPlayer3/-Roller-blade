using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("地上として判定するレイヤー")]
    public LayerMask m_Groundlayer;
    [SerializeField, Tooltip("地上との判定距離")]
    public float m_rayDistance = 0.4f;

    [SerializeField]
    private float m_InvincibleTime = 0.0f; //無敵時間
    [SerializeField]
    private GameObject pivot;

    public List<Character> characters;

    // Start is called before the first frame update
    void Start()
    {
        int n = 0;
        foreach(Character character in MainSelect.InstanceObjects)
        {
            character.m_playerState = this;
            character.scrollSystem = this.GetComponent<PlayerController2D>().scrollSystem;
            GameObject instance = GameObject.Instantiate(character.gameObject,new Vector3(-1.5f * n + pivot.transform.position.x,0.0f,pivot.transform.position.z),Quaternion.identity,pivot.transform);
            GameObject skillobject = GameObject.Instantiate(character.skill.gameObject);
            instance.GetComponent<Character>().skill = skillobject.GetComponent<Skill>();
            characters.Add(instance.GetComponent<Character>());
            n++;
        }

        this.GetComponent<PlayerController2D>().SetAcitiveCharacter(characters[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
