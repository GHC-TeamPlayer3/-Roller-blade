using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField, Tooltip("次のシーン名")]
    private string m_NextScene = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Option"))
            SceneChange();
    }

    public void SceneChange()
    {
        Debug.Log("LoadScene:"+m_NextScene);
        SceneManager.LoadScene(m_NextScene);
    }
}
