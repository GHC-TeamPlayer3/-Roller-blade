using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField]
    private PlayerController2D playerController2D;
    [SerializeField]
    private Goal goal;
    [SerializeField]
    private GameObject NextLabel;

    private SceneTransition sceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        sceneTransition = GetComponent<SceneTransition>();
        NextLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController2D.IsEnd || goal.goalFlag)
        {
            NextLabel.SetActive(true);
            if (Input.GetButtonUp("Fire1"))
                sceneTransition.SceneChange();
        }
    }
}
