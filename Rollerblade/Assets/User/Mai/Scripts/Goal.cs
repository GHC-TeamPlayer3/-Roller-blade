using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject GoalText;
    public ScrollSystem scrollSystem;

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
        if (collider.gameObject.tag == "Player")
        {
          //  scrollSystem.enabled = !scrollSystem.enabled;
            GoalText.SetActive(true);
        }
    }

}