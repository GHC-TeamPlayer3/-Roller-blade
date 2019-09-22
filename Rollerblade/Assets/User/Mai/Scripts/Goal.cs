using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject GoalText;
    public ScrollSystem scroll;
    public GameObject baseStage;


    // Use this for initialization
    void Start()
    {

        GoalText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
            if (collider.gameObject.CompareTag("Player"))
            {
                // grassを削除
                Destroy(scroll);
                GoalText.SetActive(true);
            }
       // if (collider.gameObject.tag == "Player")
       // {
           // Destroy(gameObject.GetComponent<scroll>());
          // scroll.abled = !scroll.enabled;
       // }
       // if (baseStage.activeInHierarchy)
       // {
       //     scroll.enabled = !scroll.enabled;
       // }
    }

}